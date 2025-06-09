using BackEnd.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IMongoDatabase database)
        {
            _users = database.GetCollection<User>("Users");
        }

        public async Task IncrementMatchStatsAsync(string playerId, bool isWinner)
        {
            var update = Builders<User>.Update
                .Inc(u => u.MatchPlayed, 1);

            if (isWinner)
                update = update.Inc(u => u.MatchWon, 1);

            await _users.UpdateOneAsync(
                u => u.Id == ObjectId.Parse(playerId),
                update
            );
        }
        public async Task<User?> GetByIdAsync(string id)
        {
            return await _users.Find(u => u.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();
        }
    }
}
