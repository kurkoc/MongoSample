using MongoDB.Driver;
using MongoSample.Application.Services.Abstractions;
using MongoSample.Domain.Entities;

namespace MongoSample.Application.Services.Concretes;

public class BookService : IBookService
{
    private readonly IMongoCollection<Book> _booksCollection;

    public BookService(IMongoDatabase database)
    {
        _booksCollection = database.GetCollection<Book>("Books") 
                           ?? throw new ArgumentNullException(nameof(database), "Books collection could not be retrieved.");
    }
    
    public async Task<List<string>> GetBooks()
    {
        var books = await _booksCollection.Find(_ => true).ToListAsync();
        return books.Select(book => book.Name).ToList();
    }
}