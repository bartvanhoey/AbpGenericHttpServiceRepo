namespace BookStoreMaui.Services.Authors.Dtos;

public class CreateAuthorDto
{
    public string? Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string? ShortBio { get; set; }
}