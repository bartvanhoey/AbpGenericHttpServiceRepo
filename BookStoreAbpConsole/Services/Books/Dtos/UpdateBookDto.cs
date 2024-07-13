
namespace BookStoreAbpConsole.Services.Books.Dtos;

public class UpdateBookDto(Guid id, string? name, BookType type, DateTime publishDate, float price, Guid authorId)
{
    public Guid Id { get; set; } = id;
    public BookType Type { get; set; } = type;
    public float Price { get; set; } = price;
    public DateTime PublishDate { get; set; } = publishDate;
    public string? Name { get; set; } = name;
    public Guid AuthorId { get; set; } = authorId;
}