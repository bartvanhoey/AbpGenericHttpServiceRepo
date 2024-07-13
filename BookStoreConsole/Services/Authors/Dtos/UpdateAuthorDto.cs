namespace BookStoreConsole.Services.Authors.Dtos;

public class UpdateAuthorDto(Guid id, string name, DateTime birthDate, string shortBio)
{
    public Guid Id { get; set; } = id;
    public string? Name { get; set; } = name;
    public DateTime BirthDate { get; set; } = birthDate;
    public string? ShortBio { get; set; } = shortBio;
}