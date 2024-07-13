namespace BookStoreWebApi.Infra
{
    public interface IHasTotalCount
    {
        long TotalCount { get; set; }
    }
}
