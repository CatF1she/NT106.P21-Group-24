namespace BackEnd.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System.Collections.Generic;
    public class GameSession
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonRepresentation(BsonType.ObjectId)]
        public string Player1Id { get; set; } = null!;

        [BsonRepresentation(BsonType.ObjectId)]
        public string Player2Id { get; set; } = null!;

        public string[,] Board { get; set; } = new string[15, 15];  // 15x15 board

        public string CurrentTurnPlayerId { get; set; } = null!;
        public bool IsFinished { get; set; } = false;
        public string? WinnerPlayerId { get; set; }
    }
}
