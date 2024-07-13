

namespace BookStoreAbpConsole.Services.Books.Dtos;

public class BookDto
{
    public BookDto()
    {
    }

    public BookDto(string? name, DateTime publishDate, float price)
    {
        Name = name;
        PublishDate = publishDate;
        Price = price;
    }

    public Guid Id { get; set; }
    
    public string? Name { get; set; }

    public BookType Type { get; set; }

    public DateTime PublishDate{ get; set;  }

    public float Price { get; set; }
    public Guid AuthorId { get; set; }
}