using LibraryManagement.Models;

namespace LibraryManagement.Repositories;

public interface IBookRepository
{
    Task<List<Book>> GetAllBookAsync();

    Task<Book?> GetBookByIdAsync(int id);

    Task<Book> AddBookAsync(Book book);

    Task<Book?> GetBookByTitleAsync(string title);

    Task<List<Book>> GetBookByAuthorAsync(string author);

    Task<Book?> UpdateBookAsync(int id, Book book);

    Task<bool> DeleteBookAsync(int id);
}
