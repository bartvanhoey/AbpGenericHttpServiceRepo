using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAbpApi.Books;
using BookStoreAbpApi.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;

using System.Linq.Dynamic.Core;
using Volo.Abp.EntityFrameworkCore;

namespace BookStoreAbpApi.Authors
{
    



public class AuthorRepository : EfCoreRepository<BookStoreAbpApiDbContext, Author, Guid>, IAuthorRepository
{
public AuthorRepository(IDbContextProvider<BookStoreAbpApiDbContext> dbContextProvider) : base(dbContextProvider)
{
}

        public async Task<Author?> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<Author>> GetListAsync(int skipCount, int maxResultCount, string sorting, string? filter = null)
        {
            var dbSet = await GetDbSetAsync();
            
            
            return await dbSet.
                WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    x => x.Name.Contains(filter))
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }






    


    
}