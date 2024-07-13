namespace BookStoreMaui.Services.OpenIddict;

public interface IOpenIddictService
{
    Task<bool> AuthenticationSuccessful();
    Task LogoutAsync();
    Task<bool> IsUserLoggedInAsync();
}