using MongoDB.Driver;
using MongoSample.Application.DTOs;
using MongoSample.Application.Services.Abstractions;
using MongoSample.Domain.Embeddings;
using MongoSample.Domain.Entities;
using MongoSample.Infrastructure.Persistence;

namespace MongoSample.Application.Services.Concretes;

public class BookService : IBookService
{
    private readonly IMongoCollection<Book> _booksCollection;

    public BookService(MongoContext context)
    {
        _booksCollection = context.GetCollection<Book>() ?? throw new ArgumentNullException(nameof(_booksCollection));
    }

    public async Task<List<BookDto>> GetBooks()
    {
        var books = await _booksCollection.Find(_ => true).ToListAsync();

        return books.Select(book => new BookDto
        {
            Id = book.Id,
            Name = book.Name,
            Price = book.Price,
            Categories = book.Categories != null ? book.Categories.Select(q => q.Name).ToList() : []
        }).ToList();
    }

    public async Task InsertBook(BookSaveDto bookSaveDto)
    {
        var book = new Book
        {
            Name = bookSaveDto.Name,
            Price = bookSaveDto.Price,
            Author = bookSaveDto.Author,
            Categories = bookSaveDto.Categories.Select(c => new CategoryEmbedding { Id = c.Id, Name = c.Name }).ToList()
        };

        await _booksCollection.InsertOneAsync(book);
    }
}