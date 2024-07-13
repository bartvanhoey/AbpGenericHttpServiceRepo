using BookStoreAbpConsole.Services.Books;
using BookStoreAbpConsole.Services.Books.Dtos;
using BookStoreAbpConsole.Services.Http;
using BookStoreAbpConsole.Services.SecureStorage;
using Microsoft.Extensions.DependencyInjection;

const string booksApiUrl = "https://localhost:44344/api/app/book";


var services = new ServiceCollection();

services.AddTransient<IHttpService<BookDto, CreateBookDto, UpdateBookDto, GetBooksPagedRequestDto, Guid>,
    HttpService<BookDto, CreateBookDto, UpdateBookDto, GetBooksPagedRequestDto, Guid>>();


services.AddTransient<ISecureStorageService, SecureStorageService>();

services.AddTransient<IBookService, BookService>(options
    => new BookService(
        options
            .GetRequiredService<IHttpService<BookDto, CreateBookDto, UpdateBookDto, GetBooksPagedRequestDto, Guid>>(),
        booksApiUrl));


var bookService = services.BuildServiceProvider().GetRequiredService<IBookService>();


IEnumerable<BookDto> getBooks = await bookService.GetBooksAsync();

Console.WriteLine("===GET BOOKS===");
foreach (var item in getBooks)
    Console.WriteLine(item.Name);
Console.WriteLine("======");

var createdBook =
    await bookService.CreateBookAsync(new CreateBookDto("Book 5", BookType.Adventure, DateTime.Now, 10.0f, getBooks!.FirstOrDefault()!.AuthorId));

BookDto updatedBook = await bookService.UpdateBookAsync(new UpdateBookDto(createdBook!.Id, "Book 5 Updated",
    BookType.ScienceFiction, DateTime.Now.AddMonths(5), 10.0f, getBooks!.FirstOrDefault()!.AuthorId ));

Console.WriteLine("===UpdateBook===");
Console.WriteLine(updatedBook.Name);
Console.WriteLine("======");


BookDto getBook = await bookService.GetBookAsync(createdBook.Id.ToString());

Console.WriteLine("===GET BOOK===");
Console.WriteLine(getBook.Name);
Console.WriteLine("======");

await bookService.DeleteBookAsync(createdBook.Id);


Console.Read();