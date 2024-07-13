using BookStoreMaui.Services.Authors;
using BookStoreMaui.Services.Authors.Dtos;
using BookStoreMaui.Services.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BookStoreMaui.Pages.Authors.Add;

public partial class AddAuthorViewModel(IAuthorService authorService, INavigationService navigate) : ObservableObject
{
    [ObservableProperty] private string? _name;
    [ObservableProperty] private DateTime _birthDate;
    [ObservableProperty] private string? _shortBio;
    
    [RelayCommand]
    private async Task SaveAuthor()
    {
        await authorService.CreateAuthorAsync(new CreateAuthorDto
            { Name = Name, BirthDate = BirthDate, ShortBio = ShortBio });
        await navigate.ToAuthorsPage();
    }
}