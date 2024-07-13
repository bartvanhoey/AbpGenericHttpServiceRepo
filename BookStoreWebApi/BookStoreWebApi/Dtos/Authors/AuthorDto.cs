namespace BookStoreWebApi.Dtos.Authors;

public class AuthorDto
{
    public AuthorDto()
    {
    }

    public AuthorDto(string? name, DateTime birthDate, string? shortBio, Guid id)
    {
        Name = name;
        BirthDate = birthDate;
        ShortBio = shortBio;
        Id = id;
    }

    public Guid Id { get; set; }
    public string? Name { get; set; }

    public DateTime BirthDate { get; set; }

    public string? ShortBio { get; set; }
}