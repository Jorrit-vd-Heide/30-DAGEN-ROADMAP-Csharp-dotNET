using Day15_WebApi.Models;
using Day15_WebApi.Database;
using Microsoft.EntityFrameworkCore;

namespace Day15_WebApi.Services;

public class BookService
{
    private readonly BookContext _context;

    // Inject the database context
    public BookService(BookContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetAllAsync() => await _context.Books.ToListAsync();

    public async Task<Book?> GetAsync(int id) => await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

    public async Task AddAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var book = await GetAsync(id);
        if (book is null)
            return;

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Book book)
    {
        var existingBook = await GetAsync(book.Id);
        if (existingBook is null)
            return;

        // Update properties or attach the entity
        _context.Entry(existingBook).CurrentValues.SetValues(book);
        await _context.SaveChangesAsync();
    }
}