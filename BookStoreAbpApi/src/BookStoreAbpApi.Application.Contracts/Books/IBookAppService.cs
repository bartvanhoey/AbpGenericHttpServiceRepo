using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookStoreAbpApi.Books
{
  public interface IBookAppService : ICrudAppService<BookDto, Guid, PagedAndSortedResultRequestDto, CreateBookDto, UpdateBookDto>, IApplicationService
  {
    Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync();
  }
}