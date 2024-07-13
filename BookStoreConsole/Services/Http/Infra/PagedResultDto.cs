namespace BookStoreConsole.Services.Http.Infra;

public class PagedResultDto<T> : ListResultDto<T>, IPagedResult<T>
{
    public long TotalCount { get; set; }

    public PagedResultDto()
    {

    }

    public PagedResultDto(long totalCount, IReadOnlyList<T> items) : base(items)
    {
        TotalCount = totalCount;
    }

}