using BackEnd.Models;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class GameSessionService
    {
        private readonly IMongoCollection<GameSession> _games;

        public GameSessionService(IMongoDatabase database)
        {
            _games = database.GetCollection<GameSession>("GameSessions");
        }

        public async Task<GameSession?> GetByGameCodeAsync(string gameCode)
        {
            var game = await _games.Find(g => g.GameCode == gameCode).FirstOrDefaultAsync();
            Console.WriteLine($"[MongoDB] GetByGameCodeAsync: {(game == null ? "not found" : "found")}, GameCode: {gameCode}");
            return game;
        }

        public async Task SaveAsync(GameSession session)
        {
            try
            {
                session.UpdatedAt = DateTime.UtcNow;
                var result = await _games.ReplaceOneAsync(
                    g => g.GameCode == session.GameCode,
                    session,
                    new ReplaceOptions { IsUpsert = true });

                Console.WriteLine($"[MongoDB] SaveAsync: MatchedCount={result.MatchedCount}, ModifiedCount={result.ModifiedCount}, UpsertedId={result.UpsertedId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MongoDB] SaveAsync ERROR: {ex.Message}");
            }
        }
    }
}
