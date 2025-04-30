namespace BackEnd.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    public class Friend
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonRepresentation(BsonType.ObjectId)]
        public string User1Id { get; set; } = null!;

        [BsonRepresentation(BsonType.ObjectId)]
        public string User2Id { get; set; } = null!;
    }
}