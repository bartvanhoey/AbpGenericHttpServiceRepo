# How to create a Generic HTTP Service to consume a Web API

## Generics: Write Once, Use Every Time

This article will guide you through the process of **creating a Generic HTTP service in C#** that consumes a **.NET Core Web API**.

To simplify things, we will create a **.NET Core WEB API** (BookStoreWebApi) and a **.NET Core Console** (BookStoreConsole) application to implement a **generic HTTP Service** that consumes a **C# CRUD API**.

You can find the **BookStoreWebApi** and **BookStoreConsole** sample applications in the [GitHub repo](https://github.com/bartvanhoey/AbpGenericHttpServiceRepo)

To consume an **ABP Framework API**, have a look at the [mobile .NET MAUI app](https://github.com/bartvanhoey/AbpGenericHttpServiceRepo) and [.NET Core Console app](https://github.com/bartvanhoey/AbpGenericHttpServiceRepo)
in the Repo

## Prerequisites

- .NET 8.0 SDK
- VsCode, Visual Studio 2022 or another compatible IDE

## Development

### Setting Up the .NET Core Web API

First, create a simple .NET Core Web API with a BooksController with the standard CRUD endpoints.

```bash
    dotnet new webapi --use-controllers -o BookStoreWebApi
```

### Copy Data/Infra/Dtos folders

Copy/paste the Data/Infra and Dtos folder of the BookstoreWebApi sample project into the root of your project.
The Data Transfer Objects (DTOs) are POCO classes that send/receive data to/from the API.

### Add a BooksController class to the Controllers folder

```csharp
using BookStoreWebApi.Dtos.Books;
using BookStoreWebApi.Infra;
using Microsoft.AspNetCore.Mvc;
using static BookStoreWebApi.Data.BooksResolver;

namespace BookStoreWebApi.Controllers
{
    [Route("api/app/book")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public PagedResultDto<BookDto> Get([FromQuery]GetBooksDto getBooksDto) => new() { Items = BookItems, TotalCount = BookItems.Count };

        [HttpGet("{id}")]
        public BookDto? Get(Guid id) => BookItems.FirstOrDefault(x => x.Id == id);

        [HttpPost]
        public BookDto Create([FromBody] CreateBookDto createBookDto)
        {
            BookItems.Add(new BookDto(createBookDto.Name,createBookDto.Type,createBookDto.Price,  createBookDto.PublishDate, createBookDto.Id));
            return BookItems.Single(x => x.Id == createBookDto.Id);
        }

        [HttpPut("{id}")]
        public BookDto? Put(Guid id, [FromBody] UpdateBookDto updateBookDto)
        {
            var bookDto = BookItems.FirstOrDefault(x => x.Id == id);
            if (bookDto == null) return bookDto;
            bookDto.Name = updateBookDto.Name;
            bookDto.Price = updateBookDto.Price;
            bookDto.PublishDate = updateBookDto.PublishDate;
            bookDto.Type = updateBookDto.Type;
            return bookDto;
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var bookDto = BookItems.FirstOrDefault(x => x.Id == id);
            if (bookDto != null) BookItems.Remove(bookDto);
        }
    }
}
```

### Run the API

Press `F5` to run the API. It will be hosted on `https://localhost:xxxxx`.

![Swagger Api Endpoints BooksController](../images/swagger_bookscontroller.png)

## Creating a Generic HTTP Service

### Create a new Console app

Open a terminal and run the command below to create a new console app.

```bash
dotnet new console -o BookStoreConsole
```

### Add Dependency Injection Nuget Package

Open a terminal in the root of the `Console app` and install the `Microsoft.Extensions.DependencyInjection` NuGet package.

```bash
dotnet add package Microsoft.Extensions.DependencyInjection
```

## IHttpService interface

Copy/Paste the **Infra** folder of the **BookStoreConsole** sample application into the **Services/Http** folder.

Create a **IHttpService.cs** interface with the standard CRUD method definitions in the **Services/Http** folder.

```csharp
using BookStoreConsole.Services.Http.Infra;

namespace BookStoreConsole.Services.Http;

public interface IHttpService<T, in TC, in TU, in TG, in TD>
{
    Task<ListResultDto<T>> GetListAsync(string uri, TG? getListRequestDto = default);
    Task<ListResultDto<T>> UpdateAsync(string uri, TU updateInputDto);
    Task<T> CreateAsync(string uri, TC createInputDto);
    Task CreateManyAsync(string uri, IEnumerable<TC> createManyInputDto);
    Task<T> GetAsync(string uri);
    Task DeleteAsync(string uri, TD id);
}
```

Create a **HttpService.cs** class in the **Http** folder that implements the **IHttpService interface**

```csharp
using System.Net.Http.Json;
using BookStoreConsole.Services.Http.Infra;

namespace BookStoreConsole.Services.Http;

public class HttpService<T, TC, TU, TL, TD> : HttpServiceBase<TL>, IHttpService<T, TC, TU, TL, TD>
    where T : class 
    where TC : class
    where TU : class
    where TL : class
{
    public async Task<ListResultDto<T>> GetListAsync(string uri, TL? getListRequestDto = default)
    {
        if (getListRequestDto == null) return new ListResultDto<T>();
        var httpResponse = await (await GetHttpClientAsync()).Value.GetAsync(ComposeUri(uri, getListRequestDto));
        httpResponse.EnsureSuccessStatusCode();
        var json = await httpResponse.Content.ReadAsStringAsync();
        if (json == "[]" || json.IsNullOrWhiteSpace()) return new ListResultDto<T>();
        if (getListRequestDto is IPagedRequestDto)
        {
            var pagedResultDto = json.ToType<PagedResultDto<T>>();
            return new PagedResultDto<T>(pagedResultDto.TotalCount,pagedResultDto.Items);
        }
        return new ListResultDto<T>(json.ToType<List<T>>());
    }

    public async Task<ListResultDto<T>> UpdateAsync(string uri, TU updateInputDto)
    {
        var httpResponse = await (await GetHttpClientAsync()).Value.PutAsJsonAsync($"{uri}", updateInputDto);
        var json = await httpResponse.Content.ReadAsStringAsync();
        if (json == "[]" || json.IsNullOrWhiteSpace()) return new ListResultDto<T>();

        if (json.StartsWith("{") && json.EndsWith("}"))
            return new ListResultDto<T>(new List<T> { json.ToType<T>() });

        return new ListResultDto<T>(json.ToType<List<T>>());
    }

    public async Task<T> CreateAsync(string uri, TC createInputDto)
    {
        var httpResponse = await (await GetHttpClientAsync()).Value.PostAsJsonAsync(uri, createInputDto);
        return (await httpResponse.Content.ReadAsStringAsync()).ToType<T>();
    }

    public async Task CreateManyAsync(string uri, IEnumerable<TC> createInputDto)
    {
        var httpResponse = await (await GetHttpClientAsync()).Value.PostAsJsonAsync($"{uri}/many", createInputDto);
    }

    public async Task<T> GetAsync(string uri)
    {
        var httpResponse = await (await GetHttpClientAsync()).Value.GetAsync(uri);
        return (await httpResponse.Content.ReadAsStringAsync()).ToType<T>();
    }

    public async Task DeleteAsync(string uri, TD id)
    {
        var httpResponse = await (await GetHttpClientAsync()).Value.DeleteAsync($"{uri}/{id}");
    }
}
```

### Create an IBookService interface

Copy/Paste the **Services/Books/Dtos** folder of the **BookStoreConsole** sample application into the **Services/Books/Dtos** folder.

Create an **IBookService.cs** interface in the **Services/Books** folder.

```csharp
using BookStoreConsole.Services.Books.Dtos;

namespace BookStoreConsole.Services.Books;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetBooksAsync();
    Task<BookDto?> CreateBookAsync(CreateBookDto bookDto);
    // Find other method definitions in the BookStoreConsole sample project ...
}
```

Create a **BookService class** in the **Services/Books** folder.
The BookService class gets the correct HttpService via Constructor Dependency Injection.
Attention: Change the port number to the port number your API is running on.

```csharp
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

    public async Task<BookDto?> CreateBookAsync(CreateBookDto bookDto) 
        => await httpService.CreateAsync($"{BookApiUrl}", bookDto);

    // Find other methods in the BookStoreConsole sample project ...

}
```

## Test the Generic HTTP Service

### Program.cs

Copy/Paste the content below in the Program.cs file and hit `F5` to run the console app.

```csharp
using BookStoreConsole.Services.Books;
using BookStoreConsole.Services.Books.Dtos;
using BookStoreConsole.Services.Http;
using Microsoft.Extensions.DependencyInjection;

// First set up the Dependency Injection System to register the Book Http Service and the BookService
var services = new ServiceCollection();

// Register the Book HttpService to the Dependency Injection system
services.AddTransient<IHttpService<BookDto, CreateBookDto, UpdateBookDto, GetBooksDto, Guid>,
    HttpService<BookDto, CreateBookDto, UpdateBookDto, GetBooksDto, Guid>>();

// Register the BookService to the Dependency Injection system
services.AddTransient<IBookService, BookService>();

// Get the BookService from the Dependency Injection System
// The Book service becomes via its constructor the Book HttpService (Constructor Dependency Injection) and is ready to use.
var bookService = services.BuildServiceProvider().GetRequiredService<IBookService>();

// Create a book
var createdBook = await bookService.CreateBookAsync(new CreateBookDto("New Book3", BookType.Adventure, DateTime.Now, 10.0f));

// Get a list of books
var books = await bookService.GetBooksAsync();

Console.ReadLine(); // Set here a breakpoint to see the results
```

## Another Use Case: Authors

When you have a working use case, the Generic Book HTTP Service, things get a lot easier because the heavy lifting is done.

Imagine, you have another use case where you need to Get or Create Authors from the API.

The only things you need to do are:

### Create the DTOS (CreateAuthorDto, GetAuthorsDto, DeleteAuthorDto and UpdateAuthorDto)

```csharp
namespace BookStoreWebApi.Dtos.Authors;

public class AuthorDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string? ShortBio { get; set; }
}
```

### Create an IAuthorService interface and AuthorService class

```csharp
public interface IAuthorService
{
    Task<IEnumerable<AuthorDto>> GetAuthorsAsync();
    Task<AuthorDto?> CreateAuthorAsync(CreateAuthorDto bookDto);
    // other method definitions here
}

public class AuthorService : IAuthorService
{
    // implementation here
}
```

### Register the Author Http Service to the Dependency Injection System

```csharp
services.AddTransient<IHttpService<AuthorDto, CreateAuthorDto, UpdateAuthorDto, GetAuthorsDto, Guid>,
    HttpService<AuthorDto, CreateAuthorDto, UpdateAuthorDto, GetAuthorsDto, Guid>>();
```

### Register the AuthorService to the Dependency Injection System

```csharp
services.AddTransient<IAuthorService, AuthorService>();
```

### Call the CRUD methods you need to call

```csharp
await authorService.CreateAuthorAsync(new CreateAuthorDto(){ ... });

var authors = await authorService.GetAuthorsAsync();
```

Get the [source code](https://github.com/bartvanhoey/AbpGenericHttpServiceRepo) on GitHub.

Enjoy and have fun!
