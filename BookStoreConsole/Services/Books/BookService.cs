using BookStoreConsole.Services.Books.Dtos;
using BookStoreConsole.Services.Http;

namespace BookStoreConsole.Services.Books;

public class BookService(
    IHttpService<BookDto, CreateBookDto, UpdateBookDto, GetBooksDto, Guid> httpService)
    : IBookService
{
    const string BookApiUrl = "https://localhost:44336/api/app/book";
    
    public async Task<IEnumerable<BookDto>> GetBooksAsync() 
        => (await httpService.GetListAsync($"{BookApiUrl}", new GetBooksDto())).Items;

    public async Task<BookDto?> UpdateBookAsync(UpdateBookDto book) 
        => (await httpService.UpdateAsync($"{BookApiUrl}/{book.Id}", book)).Items.FirstOrDefault();

    public async Task DeleteBookAsync(Guid bookDtoId) 
        => await httpService.DeleteAsync($"{BookApiUrl}", bookDtoId);

    public async Task CreateManyBooksAsync(IEnumerable<CreateBookDto> bookDtos) 
        => await httpService.CreateManyAsync($"{BookApiUrl}", bookDtos);

    public async Task<BookDto?> CreateBookAsync(CreateBookDto bookDto) 
        => await httpService.CreateAsync($"{BookApiUrl}", bookDto);

 
    public async Task<BookDto?> GetBookAsync(string bookId) 
        => await httpService.GetAsync($"{BookApiUrl}/{bookId}");
}