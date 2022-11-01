using MongoDB.Bson.Serialization.Attributes;

namespace Project_NetCore_MongoDB.Dto
{
    public class AuthsDto
    {
        
        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("password")]
        public string? Password { get; set; }
    }
}
