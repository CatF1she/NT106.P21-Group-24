namespace BackEnd.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    public class ChatMessage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonRepresentation(BsonType.ObjectId)]
        public string GameSessionId { get; set; } = null!; // Link to the game

        [BsonRepresentation(BsonType.ObjectId)]
        public string SenderUserId { get; set; } = null!;

        public string MessageType { get; set; } = "text"; // "text" or "emote"
        public string Content { get; set; } = null!;      // The message or emote identifier

        public DateTime SentAt { get; set; } = DateTime.UtcNow;
    }
}
