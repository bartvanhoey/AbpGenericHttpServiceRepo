using Volo.Abp.Modularity;

namespace BookStoreAbpApi;

[DependsOn(
    typeof(BookStoreAbpApiDomainModule),
    typeof(BookStoreAbpApiTestBaseModule)
)]
public class BookStoreAbpApiDomainTestModule : AbpModule
{

}
