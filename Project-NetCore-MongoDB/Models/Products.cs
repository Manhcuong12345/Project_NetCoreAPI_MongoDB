using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Project_NetCore_MongoDB.Models
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("description")]
        public string? Description { get; set; }

        [BsonElement("content")]
        public string? Content { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("quantity")]
        public double Quantity { get; set; }

        [BsonElement("categoriesId")]
        public string? CategoriesId { get; set; }

        [BsonElement("categories")]
        public Categories? Categories { get; set; }
    }
}
