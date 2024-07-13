namespace BookStoreConsole.Services.Http.Infra;

public interface IPagedResult<T> : IListResult<T>, IHasTotalCount
{
}