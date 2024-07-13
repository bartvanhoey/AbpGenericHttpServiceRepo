namespace BookStoreAbpConsole.Services.Http.Infra;

public interface IPagedResult<T> : IListResult<T>, IHasTotalCount
{
}