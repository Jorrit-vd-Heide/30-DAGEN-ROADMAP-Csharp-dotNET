using Day15_WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Day15_webapi.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books => Set<Book>();
    }
}
