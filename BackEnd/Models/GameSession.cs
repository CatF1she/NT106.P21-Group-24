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
        public string Id { get; set; } = null!;

        // Store the MongoDB ObjectIds of registered users
        [BsonRepresentation(BsonType.ObjectId)]
        public string PlayerXId { get; set; } = null!;

        [BsonRepresentation(BsonType.ObjectId)]
        public string PlayerOId { get; set; } = null!;

        // true = X's turn, false = O's turn
        public bool CurrentTurn { get; set; } = true;

        public bool IsFinished { get; set; } = false;

        [BsonRepresentation(BsonType.ObjectId)]
        public string? WinnerPlayerId { get; set; }

        // The game board; 0 = empty, 1 = X, 2 = O
        public int[,] Board { get; set; } = new int[Constants.chessboard_height, Constants.chessboard_width];

        // Optional: move history (can help with replays, debugging, auditing)
        public List<Move> Moves { get; set; } = new List<Move>();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // A short code players use to join the game (e.g. ABC123)
        public string GameCode { get; set; } = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
    }

    public class Move
    {
        public int X { get; set; }
        public int Y { get; set; }

        // The player who made the move
        [BsonRepresentation(BsonType.ObjectId)]
        public string PlayerId { get; set; } = null!;

        public DateTime Time { get; set; } = DateTime.UtcNow;
    }
}
