

namespace BookStoreAbpConsole.Services.Books.Dtos;

public class CreateBookDto(string? name, BookType bookType, DateTime publishDate, float price, Guid authorId)
{
    public BookType Type { get; set; } = bookType;
    public float Price { get; set; } = price;
    public DateTime PublishDate { get; set; } = publishDate;
    public string? Name { get; set; } = name;
    public Guid AuthorId { get; set; } = authorId;
}