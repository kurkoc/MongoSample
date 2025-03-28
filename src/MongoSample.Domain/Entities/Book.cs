using MongoDB.Bson.Serialization.Attributes;
using MongoSample.Domain.Attributes;
using MongoSample.Domain.Embeddings;

namespace MongoSample.Domain.Entities;

[BsonIgnoreExtraElements]
[MongoCollection("books")]
public class Book : BaseEntity
{
    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("author")]
    public string Author { get; set; }

    [BsonElement("price")]
    public decimal Price { get; set; }

    [BsonElement("description")]
    public string Description { get; set; }

    [BsonElement("categories")]
    public List<CategoryEmbedding> Categories { get; set; }
    
}