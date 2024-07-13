using Volo.Abp.Modularity;

namespace BookStoreAbpApi;

public abstract class BookStoreAbpApiApplicationTestBase<TStartupModule> : BookStoreAbpApiTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
