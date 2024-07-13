namespace BookStoreMaui.Services.Authors.Dtos;

public class UpdateAuthorDto(Guid id, string? name, DateTime birthDate, string? shortBio)
{
    public string? Name { get; } = name;
    public DateTime BirthDate { get; } = birthDate;
    public string? ShortBio { get; } = shortBio;
    public Guid Id { get; set; } = id;
}