using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace Project_NetCore_MongoDB.Models
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("password")]
        public string? Password { get; set; }

    }
}
