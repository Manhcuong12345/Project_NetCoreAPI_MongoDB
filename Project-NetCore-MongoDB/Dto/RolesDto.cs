using MongoDB.Bson.Serialization.Attributes;

namespace Project_NetCore_MongoDB.Dto
{
    public class RolesDto
    {
        [BsonElement("userRole")]
        public string? Role { get; set; }

        [BsonElement("permission")]
        public string? Permission { get; set; }
    }
}
