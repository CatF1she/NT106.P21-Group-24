using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Services;

namespace BackEnd.Hubs
{
    public class GameHub : Hub
    {
        private readonly GameSessionService _gameService;
        private readonly UserService _userService;
        public GameHub(GameSessionService gameService, UserService userService)
        {
            _gameService = gameService;
            _userService = userService;
        }

        private string? GetUserId()
        {
            var userId = Context.GetHttpContext()?.Request.Query["userId"].ToString();
            Console.WriteLine($"[Debug] Extracted userId: {userId}");
            return userId;
        }

        public async Task JoinGame(string gameCode)
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                Console.WriteLine("[JoinGame] No userId found in query string.");
                return;
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, gameCode);
            Console.WriteLine($"[JoinGame] User {userId} joined group {gameCode}");

            var game = await _gameService.GetByGameCodeAsync(gameCode);

            if (game == null)
            {
                Console.WriteLine("[JoinGame] No existing game found. Creating new one...");
                game = new GameSession
                {
                    GameCode = gameCode,
                    PlayerXId = userId,
                    CurrentTurn = true
                };
            }
            else if (string.IsNullOrEmpty(game.PlayerOId) && game.PlayerXId != userId)
            {
                Console.WriteLine("[JoinGame] Assigning user as PlayerO.");
                game.PlayerOId = userId;
            }
            else
            {
                Console.WriteLine("[JoinGame] User already in game or slots full.");
            }

            await _gameService.SaveAsync(game);
            Console.WriteLine($"[JoinGame] Game state saved. X: {game.PlayerXId}, O: {game.PlayerOId}");
        }

        public async Task MakeMove(string gameCode, int x, int y, string playerId)
        {
            Console.WriteLine($"[MakeMove] Move request from {playerId} at ({x}, {y}) for game {gameCode}");

            var game = await _gameService.GetByGameCodeAsync(gameCode);
            if (game == null || game.IsFinished)
            {
                Console.WriteLine("[MakeMove] Game not found or already finished.");
                return;
            }

            if (game.Board[y, x] != 0)
            {
                Console.WriteLine("[MakeMove] Invalid move, cell already occupied.");
                return;
            }

            string expectedPlayerId = game.CurrentTurn ? game.PlayerXId : game.PlayerOId;
            if (playerId != expectedPlayerId)
            {
                Console.WriteLine("[MakeMove] Not this player's turn.");
                return;
            }

            int symbol = game.CurrentTurn ? 1 : 2;
            game.Board[y, x] = symbol;

            game.Moves.Add(new Move { X = x, Y = y, PlayerId = playerId });
            Console.WriteLine($"[MakeMove] Move registered. Turn: {(game.CurrentTurn ? "X" : "O")}");

            await Clients.Group(gameCode).SendAsync("ReceiveMove", x, y, game.CurrentTurn ? "PlayerX" : "PlayerO");

            if (CheckWin(game.Board, x, y, symbol))
            {
                game.IsFinished = true;
                game.WinnerPlayerId = playerId;
                await Clients.Group(gameCode).SendAsync("GameWon", game.CurrentTurn ? "PlayerX" : "PlayerO");
                Console.WriteLine($"[MakeMove] Game won by {playerId}");
                var loserId = game.CurrentTurn ? game.PlayerOId : game.PlayerXId;
                await _userService.IncrementMatchStatsAsync(playerId, true);     // Winner
                await _userService.IncrementMatchStatsAsync(loserId, false);     // Loser
            }
            else
            {
                game.CurrentTurn = !game.CurrentTurn;
            }

            await _gameService.SaveAsync(game);
        }

        private bool CheckWin(int[,] board, int x, int y, int player)
        {
            return (Count(board, x, y, 1, 0, player) + Count(board, x, y, -1, 0, player) + 1 >= 5) ||
                   (Count(board, x, y, 0, 1, player) + Count(board, x, y, 0, -1, player) + 1 >= 5) ||
                   (Count(board, x, y, 1, 1, player) + Count(board, x, y, -1, -1, player) + 1 >= 5) ||
                   (Count(board, x, y, 1, -1, player) + Count(board, x, y, -1, 1, player) + 1 >= 5);
        }

        private int Count(int[,] board, int x, int y, int dx, int dy, int player)
        {
            int count = 0;
            int w = board.GetLength(1);
            int h = board.GetLength(0);

            for (int i = 1; i < 5; i++)
            {
                int nx = x + dx * i, ny = y + dy * i;
                if (nx < 0 || ny < 0 || nx >= w || ny >= h || board[ny, nx] != player)
                    break;
                count++;
            }

            return count;
        }
    }
}
