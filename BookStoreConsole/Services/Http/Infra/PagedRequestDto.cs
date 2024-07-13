namespace BookStoreConsole.Services.Http.Infra;

public class PagedRequestDto : IPagedRequestDto
{
    public int SkipCount { get; set; } 
    public int MaxResultCount { get; set; } = 1000;
    public string? Sorting { get; set; }
}