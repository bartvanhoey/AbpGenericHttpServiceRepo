using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BookStoreAbpApi.Data;

/* This is used if database provider does't define
 * IBookStoreAbpApiDbSchemaMigrator implementation.
 */
public class NullBookStoreAbpApiDbSchemaMigrator : IBookStoreAbpApiDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
