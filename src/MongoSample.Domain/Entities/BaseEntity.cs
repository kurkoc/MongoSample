using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoSample.Domain.Entities;

public class BaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
}