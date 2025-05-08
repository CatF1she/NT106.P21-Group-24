using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using BackEnd.Models;
using System.IO;
using BackEnd.Models;
using MongoDB.Bson;

namespace BackEnd.Services
{
    public class DatabaseConnection
    {
        private readonly IMongoDatabase database;

        public DatabaseConnection()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var settings = config.GetSection("MongoDBSettings").Get<MongoDBSettings>();

            var client = new MongoClient(settings.ConnectionString);
            database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<BsonDocument> GetUsersCollection()
        {
            return database.GetCollection<BsonDocument>("Users");
        }
    }
}
