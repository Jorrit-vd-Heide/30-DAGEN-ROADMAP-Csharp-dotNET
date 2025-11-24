using Day15_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Day15_WebApi.Database
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
