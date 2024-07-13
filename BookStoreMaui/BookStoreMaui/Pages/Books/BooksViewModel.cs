using BookStoreMaui.Pages.Books.Edit;
using BookStoreMaui.Services.Books;
using BookStoreMaui.Services.Books.Dtos;
using BookStoreMaui.Services.Navigation;
using BookStoreMaui.Utilities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BookStoreMaui.Pages.Books;

public partial class BooksViewModel(IBookService bookService, INavigationService navigate) : ObservableObject
{
    // ReSharper disable once MemberCanBePrivate.Global
    public ObservableRangeCollection<BookDto> SourceItemDtos { get; set; } = new();

    public async Task OnAppearing() => await LoadBooksAsync();

    [RelayCommand]
    private async Task DeleteBook(BookDto bookDto)
    {
        await bookService.DeleteBookAsync(bookDto.Id);
        await LoadBooksAsync();
    }
    
    [RelayCommand]
    private async Task EditBook(BookDto bookDto) 
        => await Shell.Current.GoToAsync($"{nameof(EditBookPage)}?BookId={bookDto.Id }");

    [RelayCommand]
    private async Task GoToAddBookPage() => await navigate.ToAddBookPage();


    private async Task LoadBooksAsync()
    {
        SourceItemDtos.Clear();
        SourceItemDtos.AddRange(await bookService.GetBooksAsync());
    }
}