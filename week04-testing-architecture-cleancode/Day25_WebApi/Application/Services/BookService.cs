using Day15_webapi.Application.Interfaces;
using Day15_WebApi.Domain.Entities;

namespace Day15_webapi.Application.Services;

public class BookService
{
    private readonly IBookRepository _repo;

    public BookService(IBookRepository repo)
    {
       _repo = repo;
    }

    public Task<IEnumerable<Book>> GetAllAsync() => _repo.GetAllAsync();
    public Task<Book?> GetAsync(int id) => _repo.GetAsync(id);
    public Task AddAsync(Book book) => _repo.AddAsync(book);
    public Task UpdateAsync(Book book) => _repo.UpdateAsync(book);
    public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
}