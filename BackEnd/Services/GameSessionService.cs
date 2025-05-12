using BackEnd.Models;
using MongoDB.Driver;
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
            return await _games.Find(g => g.GameCode == gameCode).FirstOrDefaultAsync();
        }

        public async Task SaveAsync(GameSession session)
        {
            await _games.ReplaceOneAsync(
                g => g.GameCode == session.GameCode,
                session,
                new ReplaceOptions { IsUpsert = true });
        }
    }
}
