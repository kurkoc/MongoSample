using Microsoft.Extensions.DependencyInjection;
using MongoSample.Application.Services.Abstractions;
using MongoSample.Application.Services.Concretes;

namespace MongoSample.Application.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<ICategoryService, CategoryService>();
        
        return services;
    }
}