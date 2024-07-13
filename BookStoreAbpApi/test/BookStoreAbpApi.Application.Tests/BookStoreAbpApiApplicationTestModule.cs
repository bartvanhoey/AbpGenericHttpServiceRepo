using Volo.Abp.Modularity;

namespace BookStoreAbpApi;

[DependsOn(
    typeof(BookStoreAbpApiApplicationModule),
    typeof(BookStoreAbpApiDomainTestModule)
)]
public class BookStoreAbpApiApplicationTestModule : AbpModule
{

}
