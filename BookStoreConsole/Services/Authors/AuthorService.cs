using BookStoreConsole.Services.Authors.Dtos;
using BookStoreConsole.Services.Http;

namespace BookStoreConsole.Services.Authors;

public class AuthorService(
    IHttpService<AuthorDto, CreateAuthorDto, UpdateAuthorDto, GetAuthorsDto, Guid> httpService,
    string bookApiUrl)
    : IAuthorService
{
    public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync() 
        => (await httpService.GetListAsync($"{bookApiUrl}", new GetAuthorsDto())).Items;

    public async Task<AuthorDto?> UpdateAuthorAsync(UpdateAuthorDto book) 
        => (await httpService.UpdateAsync($"{bookApiUrl}/{book.Id}", book)).Items.FirstOrDefault();

    public async Task DeleteAuthorAsync(Guid bookDtoId) 
        => await httpService.DeleteAsync($"{bookApiUrl}", bookDtoId);

    public async Task CreateManyAuthorsAsync(IEnumerable<CreateAuthorDto> bookDtos) 
        => await httpService.CreateManyAsync($"{bookApiUrl}", bookDtos);

    public async Task<AuthorDto?> CreateAuthorAsync(CreateAuthorDto bookDto) 
        => await httpService.CreateAsync($"{bookApiUrl}", bookDto);

 
    public async Task<AuthorDto?> GetAuthorAsync(string bookId) 
        => await httpService.GetAsync($"{bookApiUrl}/{bookId}");
}