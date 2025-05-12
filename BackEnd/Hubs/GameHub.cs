using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Services;

namespace BackEnd.Hubs
{
    public class GameHub : Hub
    {
        private readonly GameSessionService _gameService;

        public GameHub(GameSessionService gameService)
        {
            _gameService = gameService;
        }

        private string? GetUserId()
        {
            return Context.GetHttpContext()?.Request.Query["userId"].ToString();
        }

        public async Task JoinGame(string gameCode)
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId)) return;

            await Groups.AddToGroupAsync(Context.ConnectionId, gameCode);

            var game = await _gameService.GetByGameCodeAsync(gameCode);

            if (game == null)
            {
                game = new GameSession
                {
                    GameCode = gameCode,
                    PlayerXId = userId,
                    CurrentTurn = true
                };
            }
            else if (string.IsNullOrEmpty(game.PlayerOId) && game.PlayerXId != userId)
            {
                game.PlayerOId = userId;
            }

            await _gameService.SaveAsync(game);
        }

        public async Task MakeMove(string gameCode, int x, int y, string playerId)
        {
            var game = await _gameService.GetByGameCodeAsync(gameCode);
            if (game == null || game.IsFinished || string.IsNullOrEmpty(playerId)) return;

            // Prevent overwriting
            if (game.Board[y, x] != 0) return;

            // Validate turn
            string currentPlayerId = game.CurrentTurn ? game.PlayerXId : game.PlayerOId;
            if (playerId != currentPlayerId) return;

            int playerSymbol = game.CurrentTurn ? 1 : 2;
            game.Board[y, x] = playerSymbol;

            game.Moves.Add(new Move
            {
                X = x,
                Y = y,
                PlayerId = playerId
            });

            await Clients.Group(gameCode).SendAsync("ReceiveMove", x, y, game.CurrentTurn ? "PlayerX" : "PlayerO");

            if (CheckWin(game.Board, x, y, playerSymbol))
            {
                game.IsFinished = true;
                game.WinnerPlayerId = playerId;

                await Clients.Group(gameCode).SendAsync("GameWon", game.CurrentTurn ? "PlayerX" : "PlayerO");
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
