namespace BackEnd.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    public class Friend
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; } = ObjectId.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId User1Id { get; set; } = ObjectId.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId User2Id { get; set; } = ObjectId.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        public string status { get; set; } = null!;
    }
}