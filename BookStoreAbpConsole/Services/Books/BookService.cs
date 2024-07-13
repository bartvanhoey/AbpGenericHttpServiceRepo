using BookStoreAbpConsole.Services.Books.Dtos;
using BookStoreAbpConsole.Services.Http;

namespace BookStoreAbpConsole.Services.Books;

public class BookService(
    IHttpService<BookDto, CreateBookDto, UpdateBookDto, GetBooksPagedRequestDto, Guid> httpService,
    string bookApiUrl)
    : IBookService
{
    public async Task<IEnumerable<BookDto>> GetBooksAsync() 
        => (await httpService.GetListAsync($"{bookApiUrl}", new GetBooksPagedRequestDto())).Items;

    public async Task<BookDto?> UpdateBookAsync(UpdateBookDto book) 
        => (await httpService.UpdateAsync($"{bookApiUrl}/{book.Id}", book)).Items.FirstOrDefault();

    public async Task DeleteBookAsync(Guid bookDtoId) 
        => await httpService.DeleteAsync($"{bookApiUrl}", bookDtoId);

    public async Task CreateManyBooksAsync(IEnumerable<CreateBookDto> bookDtos) 
        => await httpService.CreateManyAsync($"{bookApiUrl}", bookDtos);

    public async Task<BookDto?> CreateBookAsync(CreateBookDto bookDto) 
        => await httpService.CreateAsync($"{bookApiUrl}", bookDto);

 
    public async Task<BookDto?> GetBookAsync(string bookId) 
        => await httpService.GetAsync($"{bookApiUrl}/{bookId}");
}