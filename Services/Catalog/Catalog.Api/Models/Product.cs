using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Api.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Created { get; set; }

        [BsonIgnore] public Category Category { get; set; }
    }
}