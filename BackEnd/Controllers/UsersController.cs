using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMongoCollection<BsonDocument> _users;

        public UsersController()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var settings = config.GetSection("MongoDBSettings").Get<MongoDBSettings>();
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<BsonDocument>("Users");
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var userDoc = _users.Find(filter).FirstOrDefault();

            if (userDoc == null) return NotFound();

            var result = new
            {
                Id = userDoc["_id"].ToString(),
                Username = userDoc.GetValue("username", ""),
                MatchPlayed = userDoc.GetValue("MatchPlayed", 0).ToInt32(),
                MatchWon = userDoc.GetValue("MatchWon", 0).ToInt32(),
                ELO = userDoc.GetValue("ELO", 0).ToInt32(),
                Email = userDoc.GetValue("email", ""),
                ProfilePicture = userDoc.GetValue("profilePicture", "")
            };

            return Ok(result);
        }
    }
}
