using Day15_WebApi.Models;
using Day15_WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day15_WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    // Declare a private field for the service
    private readonly BookService _bookService;

    // Constructor to receive the injected BookService
    public BooksController(BookService bookService)
    {
        _bookService = bookService;
    }

    // GET: api/books
    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetAll() =>
        await _bookService.GetAllAsync();

    // GET: api/books/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> Get(int id)
    {
        var book = await _bookService.GetAsync(id);
        if (book is null)
            return NotFound();
        return book;
    }

    // POST: api/books
    [HttpPost]
    public async Task<ActionResult<Book>> Create(Book book)
    {
        await _bookService.AddAsync(book);
        // Ensure you return the created item with its new ID
        return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
    }

    // PUT: api/books/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Book book)
    {
        if (id != book.Id)
            return BadRequest();

        var existingBook = await _bookService.GetAsync(id);
        if (existingBook is null)
            // Use NotFoundResult for a PUT to a non-existent resource
            return NotFound();

        await _bookService.UpdateAsync(book);
        return NoContent();
    }

    // DELETE: api/books/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _bookService.GetAsync(id);
        if (book is null)
            return NotFound();

        await _bookService.DeleteAsync(id);
        return NoContent();
    }
}