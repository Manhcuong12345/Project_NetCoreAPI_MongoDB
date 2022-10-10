using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Project_NetCore_MongoDB.Models;

namespace Project_NetCore_MongoDB.Dto
{
    public class ProductsDto
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

        [BsonElement("categories")]
        public Categories? Categories { get; set; }

    }
}
