using BookStoreMaui.Services.OpenIddict;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BookStoreMaui.Pages;

public partial class LogoutViewModel : ObservableObject
{
    private readonly IOpenIddictService _openIddictService;
  
    public LogoutViewModel(IOpenIddictService openIddictService) => _openIddictService = openIddictService;

    [RelayCommand]
    public async Task Logout()
    {
        await _openIddictService.LogoutAsync();
        await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");
    }
        
}