using BookStoreConsole.Services.Authors.Dtos;
using BookStoreConsole.Services.Http;

namespace BookStoreConsole.Services.Authors;

public class AuthorService(
    IHttpService<AuthorDto, CreateAuthorDto, UpdateAuthorDto, GetAuthorsDto, Guid> httpService)
    : IAuthorService
{
    
    const string BookApiUrl = "https://localhost:44336/api/app/author";
    
    public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync() 
        => (await httpService.GetListAsync($"{BookApiUrl}", new GetAuthorsDto())).Items;

    public async Task<AuthorDto?> UpdateAuthorAsync(UpdateAuthorDto book) 
        => (await httpService.UpdateAsync($"{BookApiUrl}/{book.Id}", book)).Items.FirstOrDefault();

    public async Task DeleteAuthorAsync(Guid bookDtoId) 
        => await httpService.DeleteAsync($"{BookApiUrl}", bookDtoId);

    public async Task CreateManyAuthorsAsync(IEnumerable<CreateAuthorDto> bookDtos) 
        => await httpService.CreateManyAsync($"{BookApiUrl}", bookDtos);

    public async Task<AuthorDto?> CreateAuthorAsync(CreateAuthorDto bookDto) 
        => await httpService.CreateAsync($"{BookApiUrl}", bookDto);

 
    public async Task<AuthorDto?> GetAuthorAsync(string bookId) 
        => await httpService.GetAsync($"{BookApiUrl}/{bookId}");
}