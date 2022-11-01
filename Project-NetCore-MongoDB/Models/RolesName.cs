using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Project_NetCore_MongoDB.Models
{
    public class RolesName
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("userRole")]
        public string? Role { get; set; }

        [BsonElement("permission")]
        public string? Permission { get; set; }
    }
}
