namespace BookStoreAbpConsole.Services.Http.Infra;

public interface IHasTotalCount
{
    long TotalCount { get; set; }
}