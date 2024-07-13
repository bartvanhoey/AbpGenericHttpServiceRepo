namespace BookStoreMaui.Services.Http.Infra;

public interface IPagedRequestDto
{
    int SkipCount { get; set; }
    int MaxResultCount { get; set; } 
    string? Sorting { get; set; }
    
}

public class PagedRequestDto : IPagedRequestDto
{
    public int SkipCount { get; set; } 
    public int MaxResultCount { get; set; } = 1000;
    public string? Sorting { get; set; }
}