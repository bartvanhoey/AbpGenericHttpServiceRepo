using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BookStoreAbpApi.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class BookStoreAbpApiDbContextFactory : IDesignTimeDbContextFactory<BookStoreAbpApiDbContext>
{
    public BookStoreAbpApiDbContext CreateDbContext(string[] args)
    {
        BookStoreAbpApiEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<BookStoreAbpApiDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new BookStoreAbpApiDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BookStoreAbpApi.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
