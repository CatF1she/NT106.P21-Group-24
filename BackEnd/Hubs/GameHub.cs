using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Services;

namespace BackEnd.Hubs
{
    public class GameHub : Hub
    {
        private readonly GameSessionService _gameService;
        private readonly UserService _userService;

        // Tracks which players are ready in a waiting room (keyed by temporary gameCode)
        static Dictionary<string, HashSet<string>> ReadyPlayers = new();

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

        public async Task JoinWaitingRoom(string gameCode)
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                Console.WriteLine("[JoinWaitingRoom] No userId found in query string.");
                return;
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, gameCode);
            Console.WriteLine($"[JoinWaitingRoom] User {userId} joined waiting room {gameCode}");
        }

        public async Task LeaveWaitingRoom(string gameCode)
        {
            var userId = GetUserId();
            if (userId == null) return;

            if (ReadyPlayers.ContainsKey(gameCode))
            {
                ReadyPlayers[gameCode].Remove(userId);
                Console.WriteLine($"[LeaveWaitingRoom] {userId} left room {gameCode}");

                await Clients.Group(gameCode).SendAsync("UpdateReadyStatus", ReadyPlayers[gameCode]);
            }

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, gameCode);
        }

        public async Task ToggleReady(string gameCode)
        {
            var userId = GetUserId();
            if (userId == null) return;

            if (!ReadyPlayers.ContainsKey(gameCode)) 
                ReadyPlayers[gameCode] = new HashSet<string>();

            if (ReadyPlayers[gameCode].Contains(userId))
            {
                ReadyPlayers[gameCode].Remove(userId);
                Console.WriteLine($"[ToggleReady] {userId} is now UNREADY in {gameCode}");
            }
            else
            {
                ReadyPlayers[gameCode].Add(userId);
                Console.WriteLine($"[ToggleReady] {userId} is now READY in {gameCode}");
            }

            await Clients.Group(gameCode).SendAsync("UpdateReadyStatus", ReadyPlayers[gameCode]);

            if (ReadyPlayers[gameCode].Count == 2)
            {
                await CreateGameSession(gameCode, ReadyPlayers[gameCode]);
                ReadyPlayers.Remove(gameCode);
            }
        }

        private async Task CreateGameSession(string gameCode, HashSet<string> players)
        {
            var playerList = new List<string>(players);
            if (playerList.Count != 2) return;

            var session = new GameSession
            {
                PlayerXId = playerList[0],
                PlayerOId = playerList[1],
                CurrentTurn = true,
                IsFinished = false,
                Board = new int[Constants.chessboard_height, Constants.chessboard_width],
                Moves = new List<Move>()
            };

            await _gameService.SaveAsync(session);

            foreach (var playerId in players)
            {
                await Clients.User(playerId).SendAsync("StartGame", session.Id.ToString());
            }

            Console.WriteLine($"[CreateGameSession] GameSession created with ID {session.Id} for players {session.PlayerXId} and {session.PlayerOId}");
        }

        public async Task JoinGame(string sessionId)
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                Console.WriteLine("[JoinGame] No userId found in query string.");
                return;
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, sessionId);
            Console.WriteLine($"[JoinGame] User {userId} joined group {sessionId}");
        }

        public async Task MakeMove(string sessionId, int x, int y, string playerId)
        {
            Console.WriteLine($"[MakeMove] Move request from {playerId} at ({x}, {y}) for session {sessionId}");

            var game = await _gameService.GetByIdAsync(sessionId);
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

            await Clients.Group(sessionId).SendAsync("ReceiveMove", x, y, game.CurrentTurn ? "PlayerX" : "PlayerO");

            if (CheckWin(game.Board, x, y, symbol))
            {
                game.IsFinished = true;
                game.WinnerPlayerId = playerId;
                await Clients.Group(sessionId).SendAsync("GameWon", game.CurrentTurn ? "PlayerX" : "PlayerO");
                Console.WriteLine($"[MakeMove] Game won by {playerId}");
                var loserId = game.CurrentTurn ? game.PlayerOId : game.PlayerXId;
                await _userService.IncrementMatchStatsAsync(playerId, true);
                await _userService.IncrementMatchStatsAsync(loserId, false);
            }
            else
            {
                game.CurrentTurn = !game.CurrentTurn;
            }

            await _gameService.SaveAsync(game);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = GetUserId();
            if (userId == null) return;

            foreach (var entry in ReadyPlayers)
            {
                if (entry.Value.Contains(userId))
                {
                    entry.Value.Remove(userId);
                    Console.WriteLine($"[OnDisconnected] Removed {userId} from ReadyPlayers in {entry.Key}");
                    await Clients.Group(entry.Key).SendAsync("UpdateReadyStatus", entry.Value);
                }
            }

            await base.OnDisconnectedAsync(exception);
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
