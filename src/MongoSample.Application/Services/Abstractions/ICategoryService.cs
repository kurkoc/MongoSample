using MongoSample.Application.DTOs;

namespace MongoSample.Application.Services.Abstractions;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetCategories();
}
