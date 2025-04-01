using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Apis.Entities
{
    public class Product
    {
        [BsonElement("Id")]
        [BsonRepresentation(BsonType.ObjectId)]//24 chars
        public String Id { get; set; }//Key
        [BsonElement("Name")]
        public String? Name { get; set; }

        public String? Category { get; set; }

        public String? Summary { get; set; }

        public String? Description { get; set; }

        public String? ImageFile { get; set; }

        public decimal Price { get; set; }
    }
}
