using MongoSample.Application.DTOs;

namespace MongoSample.Application.Services.Abstractions;

public interface IBookService
{
    Task<List<BookDto>> GetBooks();
    Task InsertBook(BookSaveDto bookSaveDto);
}