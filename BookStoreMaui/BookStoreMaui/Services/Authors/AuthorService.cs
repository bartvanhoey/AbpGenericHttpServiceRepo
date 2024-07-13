using BookStoreMaui.Services.Authors.Dtos;
using BookStoreMaui.Services.Http;
using BookStoreMaui.Services.OpenIddict.Infra;
using Microsoft.Extensions.Configuration;

namespace BookStoreMaui.Services.Authors;

public class AuthorService(IHttpService<AuthorDto, CreateAuthorDto, UpdateAuthorDto, GetAuthorsPagedRequestDto, Guid> httpService,
    IConfiguration config) : IAuthorService
{
    public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync() => 
        (await httpService.GetListAsync($"{config.GetAuthorApiUrl()}", new GetAuthorsPagedRequestDto())).Items;

    public async Task<AuthorDto?> UpdateAuthorAsync(UpdateAuthorDto author) 
        => (await httpService.UpdateAsync($"{config.GetAuthorApiUrl()}/{author.Id}", author)).Items.FirstOrDefault();

    public async Task DeleteAuthorAsync(Guid authorDtoId)
        => await httpService.DeleteAsync($"{config.GetAuthorApiUrl()}", authorDtoId);

    public async Task CreateManyAuthorsAsync(IEnumerable<CreateAuthorDto> authorDtos)
        => await httpService.CreateManyAsync($"{config.GetAuthorApiUrl()}", authorDtos);

    public async Task<AuthorDto?> CreateAuthorAsync(CreateAuthorDto authorDto)
        => await httpService.CreateAsync($"{config.GetAuthorApiUrl()}", authorDto);

    public async Task<AuthorDto?> GetAuthorAsync(string authorId)
        => await httpService.GetAsync($"{config.GetAuthorApiUrl()}/{authorId}");
}