namespace BackEnd.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; } = ObjectId.Empty;

        [BsonElement("username")]
        public string Username { get; set; } = null!;

        [BsonElement("password")]
        public string Password { get; set; } = null!;

        public int MatchPlayed { get; set; }
        public int MatchWon { get; set; }

        [BsonElement("ELO")]
        public double ELO { get; set; }

        [BsonElement("email")]
        public string Email { get; set; } = null!;

        [BsonElement("profilePicture")]
        public string? ProfilePictureUrl { get; set; }
    }
}
