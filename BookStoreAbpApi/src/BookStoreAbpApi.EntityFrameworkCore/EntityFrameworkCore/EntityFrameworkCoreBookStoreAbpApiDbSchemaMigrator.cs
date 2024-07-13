﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookStoreAbpApi.Data;
using Volo.Abp.DependencyInjection;

namespace BookStoreAbpApi.EntityFrameworkCore;

public class EntityFrameworkCoreBookStoreAbpApiDbSchemaMigrator
    : IBookStoreAbpApiDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreBookStoreAbpApiDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the BookStoreAbpApiDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BookStoreAbpApiDbContext>()
            .Database
            .MigrateAsync();
    }
}
