namespace BookStoreAbpConsole.Services.Http.Infra;

public interface IListResult<T>
{
    IReadOnlyList<T> Items { get; set; }
}