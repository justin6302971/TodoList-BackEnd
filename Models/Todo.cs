
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace todoListBackEnd.Models
{
    public class Todo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Note")]
        public string Note { get; set; }
 
        [BsonElement("IsCompleted")]
        public bool IsCompleted{get;set;}

    }
}