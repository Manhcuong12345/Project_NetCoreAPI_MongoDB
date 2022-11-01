using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Project_NetCore_MongoDB;

namespace Project_NetCore_MongoDB.Models
{
    public class Comments
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("bodyText")]
        public string BodyText { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("articlesId")]
        public string ArticlesId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("authorId")]
        public string AuthorId { get; set; }

        [BsonElement("author")]
        public Users Users { get; set; }

        [BsonElement("articles")]
        public Articles Articles { get; set; }
    }
}
