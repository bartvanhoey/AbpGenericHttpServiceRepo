namespace BookStoreConsole.Services.Authors.Dtos;

public class CreateAuthorDto(string name, DateTime birthDate, string shortBio)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Name { get; set; } = name;

    public DateTime BirthDate { get; set; } = birthDate;

    public string? ShortBio { get; set; } = shortBio;
}