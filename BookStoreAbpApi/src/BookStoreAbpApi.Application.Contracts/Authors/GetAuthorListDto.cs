using Volo.Abp.Application.Dtos;

namespace BookStoreAbpApi.Authors
{
    public class GetAuthorListDto : PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; }
}
}