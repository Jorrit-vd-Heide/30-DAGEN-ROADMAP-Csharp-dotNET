using Day15_WebApi.Models;
using Day15_WebApi.Models.DTOs; // Import DTO's
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
    public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()
    {
        var books = await _bookService.GetAllAsync();

        var bookDtos = books.Select(b => new BookDto
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author,
            Year = b.Year
        }).ToList();

        return Ok(bookDtos);
    }
        

    // GET: api/books/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> Get(int id)
    {
        var book = await _bookService.GetAsync(id);
        if (book is null)
            return NotFound();


        // Map Entiteit to DTO
        var bookDto = new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Year = book.Year
        };

        return Ok(bookDto);
    }

    // POST: api/books
    [HttpPost]
    public async Task<ActionResult<BookDto>> Create(CreatedBookDto bookDto)
    {
        // Map DTO to Entity to save in the database
        var book = new Book
        {
            Title = bookDto.Title,
            Author = bookDto.Author,
            Year = bookDto.Year
        };

        await _bookService.AddAsync(book);

        // Map the made entity back to BookDto for response
        var createdBookDto = new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Year = book.Year
        };

        // Use createdBookDto in the CreatedAtAction resonse
        return CreatedAtAction(nameof(Get), new { id = createdBookDto.Id }, book);
    }

    // PUT: api/books/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreatedBookDto bookUpdateDto)
    {
        var existingBook = await _bookService.GetAsync(id);

        if (existingBook is null)
            // Use NotFoundResult for a PUT to a non-existent resource
            return NotFound();

        // Update properties of exisitng database-entity
        existingBook.Title = bookUpdateDto.Title;
        existingBook.Author = bookUpdateDto.Author;
        existingBook.Year = bookUpdateDto.Year;

        // Call service to execute the update in the database
        await _bookService.UpdateAsync(existingBook);
        
        // Return 204 no content, is the standard for a succeeded put request
        return NoContent();
    }

    // DELETE: api/books/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _bookService.GetAsync(id);
        if (book is null)
            return NotFound(); // Returns 404 if book not found

        await _bookService.DeleteAsync(id);
        // Return 204 no content, is the standard for a succeeded put request
        return NoContent();
    }
}