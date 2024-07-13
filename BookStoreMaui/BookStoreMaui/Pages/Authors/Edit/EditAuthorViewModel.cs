using BookStoreMaui.Services.Authors;
using BookStoreMaui.Services.Authors.Dtos;
using BookStoreMaui.Services.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BookStoreMaui.Pages.Authors.Edit;

[QueryProperty(nameof(AuthorId), nameof(AuthorId))]
public partial class EditAuthorViewModel(IAuthorService authorService, INavigationService navigate) : ObservableObject
{
    [ObservableProperty] private string? _authorId;
    [ObservableProperty] private AuthorDto? _author;
    
    public async Task OnAppearing()
    {
        if (AuthorId!= null) 
            Author = await authorService.GetAuthorAsync(AuthorId);
    }
    
    [RelayCommand]
    private async Task SaveAuthor()
    {
        if (Author == null) return;
        await authorService.UpdateAuthorAsync(new UpdateAuthorDto(Author.Id, Author.Name, Author.BirthDate, Author.ShortBio));
        await navigate.ToAuthorsPage();
    }
}