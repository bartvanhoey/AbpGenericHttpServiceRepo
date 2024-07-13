namespace BookStoreMaui.Services.Http.Infra;

public interface IPagedResult<T> : IListResult<T>, IHasTotalCount
{
}