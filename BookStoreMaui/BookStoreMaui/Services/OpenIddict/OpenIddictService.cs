using BookStoreMaui.Services.OpenIddict.Infra;
using BookStoreMaui.Services.SecureStorage;
using IdentityModel.OidcClient;
using Microsoft.Extensions.Configuration;
using static BookStoreMaui.Services.OpenIddict.Infra.AccessTokenValidator;
using DisplayMode = IdentityModel.OidcClient.Browser.DisplayMode;

namespace BookStoreMaui.Services.OpenIddict;

public class OpenIddictService(IConfiguration configuration, ISecureStorageService storageService)
    : IOpenIddictService
{
    public async Task<bool> AuthenticationSuccessful()
    {
        try
        {
            var login = await configuration.GetOidcSettings().CreateClient().LoginAsync(new LoginRequest());
            if (login.IsNotAuthenticated()) return false;
                
            await storageService.SetOpenIddictTokensAsync(login);
            return true;
            
            // TODO catch System.InvalidOperationException: Error loading discovery document: Error connecting to /.well-known/openid-configuration: Connection refused
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

   public async Task LogoutAsync()
    {
        try
        {
            var logout = await configuration.GetOidcSettings().CreateClient().LogoutAsync(new LogoutRequest
            {
                IdTokenHint = await storageService.GetIdentityTokenAsync(),
                BrowserDisplayMode = DisplayMode.Hidden,
            });

            if (logout.IsError) await Task.CompletedTask;
            else
            {
                await storageService.RemoveOpenIddictTokensAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> IsUserLoggedInAsync() 
        => IsAccessTokenValid(await storageService.GetAccessTokenAsync());
}