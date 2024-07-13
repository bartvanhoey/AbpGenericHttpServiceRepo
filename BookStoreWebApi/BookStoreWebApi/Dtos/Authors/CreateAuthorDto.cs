namespace BookStoreWebApi.Dtos.Authors;

public class CreateAuthorDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public DateTime BirthDate { get; set; }

    public string? ShortBio { get; set; }
}