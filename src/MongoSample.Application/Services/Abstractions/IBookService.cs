namespace MongoSample.Application.Services.Abstractions;

public interface IBookService
{
    Task<List<string>> GetBooks();
}