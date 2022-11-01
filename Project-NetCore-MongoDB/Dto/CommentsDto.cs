using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Project_NetCore_MongoDB.Models;

namespace Project_NetCore_MongoDB.Dto
{
    public class CommentsDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("bodyText")]
        public string? BodyText { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("articlesId")]
        public string? ArticlesId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("authorId")]
        public string? AuthorId { get; set; }
    }
}
