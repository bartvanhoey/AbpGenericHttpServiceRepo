using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace BookStoreAbpApi.Books
{
    public class AuthorLookupDto :  EntityDto<Guid>
    {
        public string? Name { get; set; }
    }
}