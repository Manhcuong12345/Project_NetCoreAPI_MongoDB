using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Project_NetCore_MongoDB.Dto
{
    public class UsersDto
    {
        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("password")]
        public string? Password { get; set; }
    }
}
