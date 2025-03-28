using MongoDB.Driver;
using MongoSample.Domain.Attributes;

namespace MongoSample.Infrastructure.Persistence;
public class MongoContext
{
    private readonly IMongoDatabase _database;

    public MongoContext(IMongoDatabase database)
    {
        _database = database;
    }

    public IMongoDatabase GetDatabase()=> _database;


    public IMongoCollection<T> GetCollection<T>(string collectionName, ReadPreference? readPreference = null) where T : class
    {
        return _database
          .WithReadPreference(readPreference ?? ReadPreference.Primary)
          .GetCollection<T>(collectionName);
    }

    public IMongoCollection<T> GetCollection<T>(ReadPreference? readPreference = null) where T : class
    {
        string collectionName = GetCollectionName<T>();

        return _database
          .WithReadPreference(readPreference ?? ReadPreference.Primary)
          .GetCollection<T>(collectionName);
    }

    private static string GetCollectionName<T>() where T : class
    {
        string? attributeValue =  (typeof(T).GetCustomAttributes(typeof(MongoCollectionAttribute), true).FirstOrDefault() as MongoCollectionAttribute)?.CollectionName;
        if(attributeValue is null) return typeof(T).Name.ToLower();

        return attributeValue;
    }
}
