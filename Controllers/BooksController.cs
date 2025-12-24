using LibraryManagement.Models;
using LibraryManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(BookService service) : ControllerBase
{
    private readonly BookService _service = service;

    // GET: api/books
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        var books = await _service.GetAllBookAsync();
        return Ok(books);
    }

    // GET: api/books/1
    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await _service.GetBookByIdAsync(id);
        if (book == null)
            return NotFound();
        return Ok(book);
    }

    // GET: api/books/search?title=...&author=...
    [HttpGet("search")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Book>>> SearchBooks(
        [FromQuery] string? title,
        [FromQuery] string? author
    )
    {
        if (!string.IsNullOrEmpty(title))
        {
            var book = await _service.GetBookByTitleAsync(title);
            if (book != null)
                return Ok(new List<Book> { book });
            return Ok(new List<Book>());
        }
        if (!string.IsNullOrEmpty(author))
        {
            var books = await _service.GetBookByAuthorAsync(author);
            return Ok(books);
        }
        return BadRequest("Provide title or author query parameter.");
    }

    // POST: api/books
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Book>> AddBook([FromBody] string title)
    {
        try
        {
            var book = await _service.AddBookAsync(title);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT: api/books/1
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateBook(int id, Book book)
    {
        if (id != book.Id)
            return BadRequest();

        var updatedBook = await _service.UpdateBookAsync(id, book);
        if (updatedBook == null)
            return NotFound();
        return NoContent();
    }

    // DELETE: api/books/1
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var result = await _service.DeleteBookAsync(id);
        if (!result)
            return NotFound();
        return NoContent();
    }
}
