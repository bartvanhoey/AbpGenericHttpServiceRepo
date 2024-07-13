namespace BookStoreWebApi.Infra;

public class ListResultDto<T> : IListResult<T>
{
    public IReadOnlyList<T> Items
    {
        get { return _items ??= new List<T>(); }
        set => _items = value;
    }

    

    private IReadOnlyList<T>? _items;

    public ListResultDto()
    {
    }

    public ListResultDto(IReadOnlyList<T> items)
    {
        Items = items;
    }

    public ListResultDto(IReadOnlyList<T> items, long totalCount)
    {
        Items = items;
    }
}