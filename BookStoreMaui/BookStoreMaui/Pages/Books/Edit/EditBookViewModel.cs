using BookStoreMaui.Models;
using BookStoreMaui.Services.Books;
using BookStoreMaui.Services.Books.Dtos;
using BookStoreMaui.Services.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BookStoreMaui.Pages.Books.Edit;

[QueryProperty(nameof(BookId), nameof(BookId))]
public partial class EditBookViewModel(IBookService bookService, INavigationService navigate) : ObservableObject
{
    [ObservableProperty] private string? _bookId;

    [ObservableProperty] private BookDto? _book;

    public IReadOnlyList<string> BookTypes { get; } = Enum.GetNames(typeof(BookType));

    public async Task OnAppearing()
    {
        if (BookId != null) 
            Book = await bookService.GetBookAsync(BookId);
    }

    [RelayCommand]
    private async Task SaveBook()
    {
        if (Book == null) return;
        await bookService.UpdateBookAsync(new UpdateBookDto(Book.Id, Book.Type, Book.Price, Book.PublishDate,
            Book.Name));
        await navigate.ToBooksPage();
    }
}