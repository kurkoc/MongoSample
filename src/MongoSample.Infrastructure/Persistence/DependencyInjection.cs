using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace MongoSample.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddMongoDB(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.GetSection("MongoDB").Get<MongoSettings>();
        
        Guard.IsNotNull(settings, nameof(settings));
        Guard.IsNotNullOrEmpty(settings.ConnectionString);
        Guard.IsNotNullOrEmpty(settings.DatabaseName);

        var mongoClient = new MongoClient(connectionString: settings.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(settings.DatabaseName);
        services.AddSingleton(mongoDatabase);
        return services;
    }
}