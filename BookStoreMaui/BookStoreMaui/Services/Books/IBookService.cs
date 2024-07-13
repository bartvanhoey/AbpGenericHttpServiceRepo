using BookStoreMaui.Services.Books.Dtos;

namespace BookStoreMaui.Services.Books;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetBooksAsync();
    Task<BookDto?> UpdateBookAsync(UpdateBookDto book);
    Task DeleteBookAsync(Guid bookDtoId);
    Task CreateManyBooksAsync(IEnumerable<CreateBookDto> bookDtos);
    Task<BookDto?> CreateBookAsync(CreateBookDto bookDto);
    Task<BookDto?> GetBookAsync(string bookId);
}