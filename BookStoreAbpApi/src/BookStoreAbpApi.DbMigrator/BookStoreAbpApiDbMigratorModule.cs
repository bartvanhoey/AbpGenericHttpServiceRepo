using BookStoreAbpApi.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace BookStoreAbpApi.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BookStoreAbpApiEntityFrameworkCoreModule),
    typeof(BookStoreAbpApiApplicationContractsModule)
    )]
public class BookStoreAbpApiDbMigratorModule : AbpModule
{
}
