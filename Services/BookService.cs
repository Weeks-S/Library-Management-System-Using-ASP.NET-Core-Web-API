using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using OpenLibraryNET;

namespace LibraryManagement.Services;

public class BookService(IBookRepository repo, OpenLibraryClient client)
{
    private readonly IBookRepository _repo = repo;
    private readonly OpenLibraryClient _client = client;

    public Task<List<Book>> GetAllBookAsync() => _repo.GetAllBookAsync();

    public Task<Book?> GetBookByIdAsync(int id) => _repo.GetBookByIdAsync(id);

    public Task<Book?> GetBookByTitleAsync(string title) => _repo.GetBookByTitleAsync(title);

    public Task<List<Book>> GetBookByAuthorAsync(string author) =>
        _repo.GetBookByAuthorAsync(author);

    public async Task<Book> AddBookAsync(string title)
    {
        var work =
            await _client.GetWorkAsync(title)
            ?? throw new Exception("Book not found in OpenLibrary.");
        if (work.Data == null || work.Data.AuthorKeys == null || work.Data.AuthorKeys.Count == 0)
        {
            throw new Exception("No authors found for the book.");
        }
        var author =
            await _client.Author.GetDataAsync(work.Data.AuthorKeys[0])
            ?? throw new Exception("Author data not found.");
        var newBook = new Book
        {
            Title = work.Data.Title ?? "Unknown Title",
            Author = author.Name ?? "Unknown Author",
            Stock = 1,
        };

        return await _repo.AddBookAsync(newBook);
    }

    public async Task<Book?> UpdateBookAsync(int id, Book book)
    {
        return await _repo.UpdateBookAsync(id, book);
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        return await _repo.DeleteBookAsync(id);
    }
}
