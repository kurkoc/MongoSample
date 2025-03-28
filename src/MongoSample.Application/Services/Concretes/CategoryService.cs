using MongoDB.Driver;
using MongoSample.Application.DTOs;
using MongoSample.Application.Services.Abstractions;
using MongoSample.Domain.Entities;
using MongoSample.Infrastructure.Persistence;

namespace MongoSample.Application.Services.Concretes;

public class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Category> _categoryCollection;

    public CategoryService(MongoContext context)
    {
        _categoryCollection = context.GetCollection<Category>("categories") ?? throw new ArgumentNullException(nameof(_categoryCollection));
    }

    public async Task<List<CategoryDto>> GetCategories()
    {
        var categories = await _categoryCollection.Find(_ => true).ToListAsync();
        return categories.Select(category => new CategoryDto(category.Id, category.Name, category.Description, category.ImageUrl)).ToList();
    }
}
