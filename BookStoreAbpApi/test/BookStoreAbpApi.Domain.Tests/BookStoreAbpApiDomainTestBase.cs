using Volo.Abp.Modularity;

namespace BookStoreAbpApi;

/* Inherit from this class for your domain layer tests. */
public abstract class BookStoreAbpApiDomainTestBase<TStartupModule> : BookStoreAbpApiTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
