using MongoDB.Bson.Serialization.Attributes;

namespace MongoSample.Domain.Entities;
public class Category : BaseEntity
{
    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("description")]
    public string Description { get; set; }
    
    [BsonElement("image_url")]
    public string ImageUrl { get; set; }

}
