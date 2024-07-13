using BookStoreMaui.Models;
using BookStoreMaui.Services.Books;
using BookStoreMaui.Services.Books.Dtos;
using BookStoreMaui.Services.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BookStoreMaui.Pages.Books.Add;

public partial class AddBookViewModel(IBookService bookService, INavigationService navigate) : ObservableObject
{
    [ObservableProperty] private string? _name;
    [ObservableProperty] private DateTime _publishDate;
    [ObservableProperty] private float _price;
    
    
    [ObservableProperty]  BookType _selectedBookType = BookType.Undefined;

    public IReadOnlyList<string> BookTypes { get; } = Enum.GetNames(typeof(BookType));
    
    [RelayCommand]
    private async Task SaveBook()
    {
        await bookService.CreateBookAsync(new CreateBookDto(Name, SelectedBookType, PublishDate, Price));
        // var createBooDto1 = new CreateBooDto("JustATest1", SelectedBookType, PublishDate, Price);
        // var createBooDto2 = new CreateBooDto("JustATest2", SelectedBookType, PublishDate, Price);
        // await bookService.CreateManyBooksAsync(new List<CreateBooDto> { createBooDto1, createBooDto2 });
        await navigate.ToBooksPage();
    }
}