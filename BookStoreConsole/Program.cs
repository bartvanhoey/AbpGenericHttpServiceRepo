using BookStoreConsole.Services.Books;
using BookStoreConsole.Services.Books.Dtos;
using BookStoreConsole.Services.Http;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// Books
services.AddTransient<IHttpService<BookDto, CreateBookDto, UpdateBookDto, GetBooksDto, Guid>,
    HttpService<BookDto, CreateBookDto, UpdateBookDto, GetBooksDto, Guid>>();

services.AddTransient<IBookService, BookService>();

var bookService = services.BuildServiceProvider().GetRequiredService<IBookService>();

var createdBook = await bookService.CreateBookAsync(new CreateBookDto("New Book3", BookType.Adventure, DateTime.Now, 10.0f));

var books = await bookService.GetBooksAsync();

Console.ReadLine();

// var updatedBook = await bookService.UpdateBookAsync(new UpdateBookDto(createdBook!.Id, "New Book3 Updated",
//     BookType.ScienceFiction, DateTime.Now.AddMonths(5), 10.0f));
// var getBook = await bookService.GetBookAsync(createdBook.Id.ToString());
// await bookService.DeleteBookAsync(createdBook.Id);
//
// // Authors
// const string authorApiUrl = "https://localhost:44336/api/app/author";
// services.AddTransient<IHttpService<AuthorDto, CreateAuthorDto, UpdateAuthorDto, GetAuthorsPagedRequestDto, Guid>,
//     HttpService<AuthorDto, CreateAuthorDto, UpdateAuthorDto, GetAuthorsPagedRequestDto, Guid>>();
//
// services.AddTransient<IAuthorService, AuthorService>(options
//     => new AuthorService(
//         options
//             .GetRequiredService<
//                 IHttpService<AuthorDto, CreateAuthorDto, UpdateAuthorDto, GetAuthorsPagedRequestDto, Guid>>(),
//         authorApiUrl));
//
// var authorService = services.BuildServiceProvider().GetRequiredService<IAuthorService>();
// var getAuthors1 = await authorService.GetAuthorsAsync();
// var createdAuthor =
//     await authorService.CreateAuthorAsync(new CreateAuthorDto("Author 5", DateTime.Now.AddYears(-50), "Short Bio"));
// var updatedAuthor = await authorService.UpdateAuthorAsync(new UpdateAuthorDto(createdAuthor!.Id, "Author 5 Updated",
//      DateTime.Now.AddYears(-5), "ShortBio Updated"));
// var getAuthor = await authorService.GetAuthorAsync(createdAuthor.Id.ToString());
// var getAuthors2 = await authorService.GetAuthorsAsync();
// await authorService.DeleteAuthorAsync(createdAuthor.Id);
//
// Console.ReadLine();

