using BookStoreMaui.Pages.Authors.Edit;
using BookStoreMaui.Services.Authors;
using BookStoreMaui.Services.Authors.Dtos;
using BookStoreMaui.Services.Navigation;
using BookStoreMaui.Utilities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BookStoreMaui.Pages.Authors;

public  partial class AuthorsViewModel(IAuthorService authorService, INavigationService navigate) : ObservableObject
{
    // ReSharper disable once MemberCanBePrivate.Global
    public ObservableRangeCollection<AuthorDto> SourceItemDtos { get; set; } = new();

    public async Task OnAppearing() => await LoadAuthorsAsync();

    [RelayCommand]
    private async Task DeleteAuthor(AuthorDto authorDto)
    {
        await authorService.DeleteAuthorAsync(authorDto.Id);
        await LoadAuthorsAsync();
    }
    
    [RelayCommand]
    private async Task EditAuthor(AuthorDto authorDto) 
        => await Shell.Current.GoToAsync($"{nameof(EditAuthorPage)}?AuthorId={authorDto.Id }");

    [RelayCommand]
    private async Task GoToAddAuthorPage() => await navigate.ToAddAuthorPage();


    private async Task LoadAuthorsAsync()
    {
        SourceItemDtos.Clear();
        SourceItemDtos.AddRange(await authorService.GetAuthorsAsync());
    }
}