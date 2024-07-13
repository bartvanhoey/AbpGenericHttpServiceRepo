using BookStoreMaui.Models;

namespace BookStoreMaui.Services.Books.Dtos;

public class UpdateBookDto(Guid id, BookType type, float price, DateTime publishDate, string? name)
{
    public Guid Id { get; set; } = id;
    public BookType Type { get; set; } = type;
    public float Price { get; set; } = price;
    public DateTime PublishDate { get; set; } = publishDate;
    public string? Name { get; set; } = name;
}