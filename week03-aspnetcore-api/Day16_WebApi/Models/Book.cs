namespace Day15_WebApi.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Year { get; set; }
}


// DTOs for create/update
public class BookCreateDto
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Year { get; set; }
}


public class BookUpdateDto
{
    // nullable to allow partial updates
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int? Year { get; set; }
}