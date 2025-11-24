using Day15_WebApi.Models;
using Day15_WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day15_WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    public BooksController()
    {

    }

    // GET: api/books
    [HttpGet]
    public ActionResult<List<Book>> GetAll() =>
           BookService.GetAll(); 
    

    // GET: api/books/{id}
    [HttpGet("{id}")]
    public ActionResult<Book> Get(int id)
    {
        var book = BookService.Get(id);
        if (book is null)
            return NotFound();
        return book;
    }

    // POST: api/books
    [HttpPost]
    public ActionResult<Book> Create(Book book)
    {
        BookService.Add(book);
        return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
    }

    // PUT: api/books/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, Book book)
    {
        if (id != book.Id)
            return BadRequest();
        var existingBook = BookService.Get(id);
        if (existingBook is null)
            return NotFound();
        BookService.Update(book);
        return NoContent();
    }


    // DELETE: api/books/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var book = BookService.Get(id);
        if (book is null) 
            return NotFound();
        BookService.Delete(id);
        return NoContent();
    }
}
