using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Services;
using System.Runtime.CompilerServices;

namespace BackEnd.Hubs
{
    public class GameHub : Hub
    {
        private readonly GameSessionService _gameService;
        private readonly UserService _userService;

        static Dictionary<string, Dictionary<string, bool>> RoomPlayers = new(); /*gamecode, playerId, readystatus*/


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
        public async Task<List<string>> GetActiveRooms()
        {
            return RoomPlayers.Keys.ToList();
        }
        public async Task<string?> CreateRoom()
        {
            var userId = GetUserId();
            if (userId == null) return null;    

            var random = new Random();
            string gameCode;
            int maxAttempts = 10;

            do
            {
                gameCode = random.Next(10000000, 99999999).ToString();
                if (!RoomPlayers.ContainsKey(gameCode)) break;
            } while (--maxAttempts > 0);

            if (RoomPlayers.ContainsKey(gameCode)) return null;

            RoomPlayers[gameCode] = new Dictionary<string, bool> { [userId] = false };
            await Groups.AddToGroupAsync(Context.ConnectionId, gameCode);
            await SendReadyStatusUpdate(gameCode);
            await Clients.All.SendAsync("RoomCreated", gameCode);
            return gameCode;
        }
        public async Task JoinWaitingRoom(string gameCode)
        {
            var userId = GetUserId();
            if (userId == null) return;

            if (!RoomPlayers.ContainsKey(gameCode))
                RoomPlayers[gameCode] = new Dictionary<string, bool>();

            RoomPlayers[gameCode][userId] = false;
            await Groups.AddToGroupAsync(Context.ConnectionId, gameCode);
            await SendReadyStatusUpdate(gameCode);
        }

        public async Task LeaveWaitingRoom(string gameCode)
        {
            var userId = GetUserId();
            if (userId == null) return;

            if (RoomPlayers.TryGetValue(gameCode, out var players))
            {
                players.Remove(userId);

                if (players.Count == 0)
                {
                    RoomPlayers.Remove(gameCode);
                    await Clients.All.SendAsync("RoomRemoved", gameCode);
                }
                else
                {
                    await SendReadyStatusUpdate(gameCode);
                }

                await Groups.RemoveFromGroupAsync(Context.ConnectionId, gameCode);
            }
        }


        public async Task ToggleReady(string gameCode)
        {
            var userId = GetUserId();
            if (userId == null) return;

            if (!RoomPlayers.ContainsKey(gameCode) || !RoomPlayers[gameCode].ContainsKey(userId)) return;

            // Toggle the ready status
            RoomPlayers[gameCode][userId] = !RoomPlayers[gameCode][userId];

            // Update all clients in the group
            await SendReadyStatusUpdate(gameCode);

            // Check if there are exactly 2 players AND both are ready
            var players = RoomPlayers[gameCode];
            if (players.Count == 2 && players.All(p => p.Value))
            {
                // Start the game
                await CreateGameSession(gameCode);

                // Notify lobby to remove the room
                await Task.Delay(500);
                RoomPlayers.Remove(gameCode);
                await Clients.All.SendAsync("RoomRemoved", gameCode);
            }
        }

        private async Task SendReadyStatusUpdate(string gameCode)
        {
            if (!RoomPlayers.ContainsKey(gameCode)) return;
            var status = new Dictionary<string, bool>();

            foreach (var (userId, isReady) in RoomPlayers[gameCode])
            {
                var user = await _userService.GetByIdAsync(userId);
                if (user != null)
                    status[user.Username] = isReady;
            }

            await Clients.Group(gameCode).SendAsync("UpdateReadyStatus", status);
        }


        private async Task CreateGameSession(string gameCode)
        {
            var players = RoomPlayers[gameCode].Keys.ToList();
            if (players.Count != 2) return;

            var playerXId = players[0];
            var playerOId = players[1];

            var playerX = await _userService.GetByIdAsync(playerXId);
            var playerO = await _userService.GetByIdAsync(playerOId);
            if (playerX == null || playerO == null) return;

            var session = new GameSession
            {
                PlayerXId = playerXId,
                PlayerOId = playerOId,
                CurrentTurn = true,
                IsFinished = false,
                Board = new int[25, 25],
                Moves = []
            };
            await _gameService.SaveAsync(session);
            await Clients.Group(gameCode).SendAsync("StartGame", new
            {
                SessionId = session.Id.ToString(),
                PlayerX = new PlayerInfo
                {
                    Id = playerXId,
                    Username = playerX.Username,
                    MatchPlayed = playerX.MatchPlayed,
                    MatchWon = playerX.MatchWon,
                    ProfilePic = playerX.ProfilePictureUrl
                },
                PlayerO = new PlayerInfo
                {
                    Id = playerOId,
                    Username = playerO.Username,
                    MatchPlayed = playerO.MatchPlayed,
                    MatchWon = playerO.MatchWon,
                    ProfilePic = playerO.ProfilePictureUrl
                }
            });
        }


        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = GetUserId();
            if (userId == null) return;

            foreach (var room in RoomPlayers.Keys.ToList())
            {
                if (RoomPlayers[room].ContainsKey(userId))
                {
                    RoomPlayers[room].Remove(userId);

                    if (RoomPlayers[room].Count == 0)
                    {
                        RoomPlayers.Remove(room);
                        await Clients.All.SendAsync("RoomRemoved", room);
                    }
                    else
                    {
                        await SendReadyStatusUpdate(room);
                    }
                }
            }

            // Handle disconnect from an active game
            var sessions = await _gameService.GetAllActiveSessionsForPlayerAsync(userId);
            foreach (var session in sessions)
            {
                if (!session.IsFinished)
                {
                    session.IsFinished = true;

                    var winnerId = session.PlayerXId == userId ? session.PlayerOId : session.PlayerXId;
                    session.WinnerPlayerId = winnerId;

                    // Log a final move to indicate disconnection (101,101)
                    session.Moves.Add(new Move
                    {
                        X = 101,
                        Y = 101,
                        PlayerId = userId,
                        Time = DateTime.UtcNow
                    });

                    await Clients.Group(session.Id.ToString()).SendAsync("GameWon", session.PlayerXId == winnerId ? "PlayerX" : "PlayerO");
                    await _userService.IncrementMatchStatsAsync(winnerId, true);
                    await _userService.IncrementMatchStatsAsync(userId, false);
                    await _gameService.SaveAsync(session);
                }

            }

            await base.OnDisconnectedAsync(exception);
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
            bool skip = false;
            if (x == 69 && y == 69) skip = true;
            Console.WriteLine($"[MakeMove] Move request from {playerId} at ({x}, {y}) for session {sessionId}");

            var game = await _gameService.GetByIdAsync(sessionId);
            if (game == null || game.IsFinished)
            {
                Console.WriteLine("[MakeMove] Game not found or already finished.");
                return;
            }

            if (!skip && (game.Board[y, x] != 0 || x>=25 || x<0 || y>=25 || y<0))
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
            if (!skip) game.Board[y, x] = symbol;

            game.Moves.Add(new Move { X = x, Y = y, PlayerId = playerId });
            Console.WriteLine($"[MakeMove] Move registered. Turn: {(game.CurrentTurn ? "X" : "O")}");

            await Clients.Group(sessionId).SendAsync("ReceiveMove", x, y, game.CurrentTurn ? "PlayerX" : "PlayerO");

            if (!skip && CheckWin(game.Board, x, y, symbol))
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
