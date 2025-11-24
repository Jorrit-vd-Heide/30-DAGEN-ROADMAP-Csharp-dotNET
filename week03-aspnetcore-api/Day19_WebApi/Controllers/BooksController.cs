using Day15_WebApi.Models;
using Day15_WebApi.Services;
using Day15_WebApi.Database;
using Microsoft.AspNetCore.Mvc;

namespace Day15_WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly BookContext _context;

    public BooksController(BookContext context)
    {
        _context = context;
    }

    // GET: api/books
    [HttpGet]
    public ActionResult<List<Book>> GetAll() =>
           => _context.Books.ToList();


    // GET: api/books/{id}
    [HttpGet("{id}")]
    public ActionResult<Book> Get(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null)
            return NotFound();
        return book;
    }

    // POST: api/books
    [HttpPost]
    public ActionResult<Book> Create(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges(); 

        return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
    }

    // PUT: api/books/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, Book book)
    {
        if (id != book.Id)
            return BadRequest();
        if (!_context.Books.Any(b => b.Id == id))
            return NotFound();

        _context.Update(book);
        _context.SaveChanges();
        return NoContent();
    }


    // DELETE: api/books/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var book = _context.Book.Find(id);
        if (book == null) 
            return NotFound();

        _context.Book.Remove(book);
        _context.SaveChanges();

        return NoContent();
    }
}
