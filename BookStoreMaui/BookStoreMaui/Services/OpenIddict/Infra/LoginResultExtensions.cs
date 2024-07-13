using IdentityModel.OidcClient;
using static System.String;
using static BookStoreMaui.Services.OpenIddict.Infra.AccessTokenValidator;

namespace BookStoreMaui.Services.OpenIddict.Infra;

public static class LoginResultExtensions
{
    public static bool IsNotAuthenticated(this LoginResult loginResult)
    {
        if (IsNullOrWhiteSpace(loginResult.AccessToken)) return true;
        if (IsNullOrWhiteSpace(loginResult.IdentityToken)) return true;
        return IsNullOrWhiteSpace(loginResult.RefreshToken) || IsAccessTokenNotValid(loginResult.AccessToken);
    }
}