using BookStoreMaui.Services.Authors.Dtos;
using BookStoreMaui.Services.Books.Dtos;

namespace BookStoreMaui.Services.Authors;

public interface IAuthorService 
{
    Task<IEnumerable<AuthorDto>> GetAuthorsAsync();
    Task<AuthorDto?> UpdateAuthorAsync(UpdateAuthorDto author);
    Task DeleteAuthorAsync(Guid authorDtoId);
    Task CreateManyAuthorsAsync(IEnumerable<CreateAuthorDto> authorDtos);
    Task<AuthorDto?> CreateAuthorAsync(CreateAuthorDto authorDto);
    Task<AuthorDto?> GetAuthorAsync(string authorId);
}