using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public class GameSession
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("playerXId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PlayerXId { get; set; } = null!;

        [BsonElement("playerOId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? PlayerOId { get; set; } // Nullable — Player O may not exist initially

        [BsonElement("currentTurn")]
        public bool CurrentTurn { get; set; } = true; // true = X's turn

        [BsonElement("isFinished")]
        public bool IsFinished { get; set; } = false;

        [BsonElement("winnerPlayerId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? WinnerPlayerId { get; set; }

        [BsonElement("board")]
        public int[,] Board { get; set; } = new int[25,25];

        [BsonElement("moves")]
        public List<Move> Moves { get; set; } = new();

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public class Move
    {
        [BsonElement("x")]
        public int X { get; set; }

        [BsonElement("y")]
        public int Y { get; set; }

        [BsonElement("playerId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PlayerId { get; set; } = null!;

        [BsonElement("time")]
        public DateTime Time { get; set; } = DateTime.UtcNow;
    }
}
