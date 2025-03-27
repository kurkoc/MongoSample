namespace MongoSample.Infrastructure.Persistence;

public record MongoSettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}