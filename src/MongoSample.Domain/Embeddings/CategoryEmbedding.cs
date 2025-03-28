using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoSample.Domain.Embeddings;
public class CategoryEmbedding
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

}
