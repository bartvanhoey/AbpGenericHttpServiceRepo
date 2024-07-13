namespace BookStoreConsole.Services.Http.Infra;

public interface IListResult<T>
{
    IReadOnlyList<T> Items { get; set; }
}