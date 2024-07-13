namespace BookStoreWebApi.Infra;

public interface IPagedResult<T>: IListResult<T>, IHasTotalCount
{
        
}