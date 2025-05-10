namespace BackEnd.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; } = ObjectId.Empty;

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public int MatchPlayed { get; set; }
        public int MatchWon { get; set; }
        public double WinRate { get; set; }
    }
}