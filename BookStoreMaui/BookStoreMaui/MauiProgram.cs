using System.Reflection;
using BookStoreMaui.Pages;
using BookStoreMaui.Pages.Authors;
using BookStoreMaui.Pages.Authors.Add;
using BookStoreMaui.Pages.Authors.Edit;
using BookStoreMaui.Pages.Books;
using BookStoreMaui.Pages.Books.Add;
using BookStoreMaui.Pages.Books.Edit;
using BookStoreMaui.Services.Authors;
using BookStoreMaui.Services.Authors.Dtos;
using BookStoreMaui.Services.Books;
using BookStoreMaui.Services.Books.Dtos;
using BookStoreMaui.Services.Http;
using BookStoreMaui.Services.Navigation;
using BookStoreMaui.Services.OpenIddict;
using BookStoreMaui.Services.OpenIddict.Infra;
using BookStoreMaui.Services.SecureStorage;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace BookStoreMaui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.File("Logs/logs.txt"))
            .WriteTo.Async(c => c.Console())
            .CreateLogger();
        
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
             .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fa-solid-900.ttf", "FASolid");
                fonts.AddFont("fa-regular-400.ttf", "FARegular");
                fonts.AddFont("fa-brands-400.ttf", "FABrands");
            });
    
        // Add the appsettings.json file to the configuration
        var assembly = typeof(App).GetTypeInfo().Assembly;
        
        
        builder.Configuration.AddJsonFile(new EmbeddedFileProvider(assembly), "appsettings.json", optional: false,false);

        builder.Services.AddTransient<WebAuthenticatorBrowser>();
        
        builder.Services.AddTransient<ISecureStorageService, SecureStorageService>();
        builder.Services.AddTransient<IOpenIddictService, OpenIddictService>();
        
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<LoginViewModel>();
        
        builder.Services.AddTransient<LogoutPage>();
        builder.Services.AddTransient<LogoutViewModel>();
    
        // BOOKS
        builder.Services.AddTransient<BooksPage>();
        builder.Services.AddTransient<BooksViewModel>();
        
        builder.Services.AddTransient<AddBookPage>();
        builder.Services.AddTransient<AddBookViewModel>();
        
        builder.Services.AddTransient<EditBookPage>();
        builder.Services.AddTransient<EditBookViewModel>();

        builder.Services.AddTransient<IHttpService<BookDto, CreateBookDto, UpdateBookDto, GetBooksPagedRequestDto, Guid>, 
            HttpService<BookDto, CreateBookDto, UpdateBookDto, GetBooksPagedRequestDto, Guid>>();
        
        // AUTHORS
        builder.Services.AddTransient<AuthorsPage>();
        builder.Services.AddTransient<AuthorsViewModel>();
        
        builder.Services.AddTransient<AddAuthorPage>();
        builder.Services.AddTransient<AddAuthorViewModel>();
        
        builder.Services.AddTransient<EditAuthorPage>();
        builder.Services.AddTransient<EditAuthorViewModel>();
        
        builder.Services.AddTransient<IHttpService<AuthorDto, CreateAuthorDto, UpdateAuthorDto, GetAuthorsPagedRequestDto, Guid>, 
            HttpService<AuthorDto, CreateAuthorDto, UpdateAuthorDto, GetAuthorsPagedRequestDto, Guid>>();
        
        builder.Services.AddTransient<IBookService, BookService>();
        builder.Services.AddTransient<IAuthorService, AuthorService>();
        
        builder.Services.AddSingleton<INavigationService, NavigationService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}