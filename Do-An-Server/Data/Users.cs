using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Do_An_Server.Data
{
    public class Users
    {
        [BsonId]
        public ObjectId userID { get; set; }
        [BsonElement("username")]
        public string username { get; set; }
        [BsonElement("password")]
        public string password { get; set; }
        [BsonElement("Match Played")]
        public string Match_Played { get; set; }
        [BsonElement("MatchWon")]
        public string Match_Won { get; set; }
        [BsonElement("ELO")]
        public string ELO { get; set; }
    }
}
