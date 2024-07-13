using System.Threading.Tasks;

namespace BookStoreAbpApi.Data;

public interface IBookStoreAbpApiDbSchemaMigrator
{
    Task MigrateAsync();
}
