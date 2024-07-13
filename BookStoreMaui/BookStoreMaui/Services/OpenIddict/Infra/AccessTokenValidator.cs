using System.IdentityModel.Tokens.Jwt;

namespace BookStoreMaui.Services.OpenIddict.Infra;

public static class AccessTokenValidator
{
    public static bool IsAccessTokenNotValid(string accessToken)
        => !IsAccessTokenValid(accessToken);
    public static bool IsAccessTokenValid(string accessToken)
    {
        if (string.IsNullOrWhiteSpace(accessToken)) return false;
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(accessToken);
        var isValid = token != null && token.ValidFrom < DateTime.UtcNow && token.ValidTo > DateTime.UtcNow;
        return isValid;
    }
}