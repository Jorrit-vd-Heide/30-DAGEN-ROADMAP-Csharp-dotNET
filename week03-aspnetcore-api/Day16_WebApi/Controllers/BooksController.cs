using Day15_WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day15_WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private static readonly object _lock = new();
    private static readonly List<Book> _books = new()
    {
        new Book { Id = 1, Title = "Clean Code", Author = "Robert C. Martin", Year = 2008 },
        new Book { Id = 2, Title = "The Pragmatic Programmer", Author = "Andrew Hunt & David Thomas", Year = 1999 }
    };

    private static int _nextId = 3;

    // GET: api/books
    [HttpGet]
    public ActionResult<List<Book>> GetAll()
    {
        lock (_lock)
        {
            return _books.ToList();
        }
    }

    // GET: api/books/{id}
    [HttpGet("{id:int}")]
    public ActionResult<Book> GetById(int id)
    {
        lock (_lock)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book is null)
                return NotFound();
            return book;
        }
    }

    // POST: api/books
    [HttpPost]
    public ActionResult<Book> Create([FromBody] BookCreateDto dto)
    {
        if (dto == null) return BadRequest();
        lock (_lock)
        {
            var book = new Book
            {
                Id = _nextId,
                Title = dto.Title,
                Author = dto.Author,
                Year = dto.Year
            };
            _books.Add(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }
    }

    // PUT: api/books/{id}
    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] BookUpdateDto dto)
    {
        if (dto == null) return BadRequest();
        lock (_lock)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();
            // update fields
            book.Title = dto.Title ?? book.Title;
            book.Author = dto.Author ?? book.Author;
            if (dto.Year.HasValue) book.Year = dto.Year.Value;
            return NoContent();
        }
    }


    // DELETE: api/books/{id}
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        lock (_lock)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();
            _books.Remove(book);
            return NoContent();
        }
    }
}
