using IdentityModel.OidcClient.Browser;

namespace BookStoreMaui.Services.OpenIddict.Infra;

public static class WebAuthenticatorResultExtensions
{
    public static BrowserResult GetBrowserResult(this WebAuthenticatorResult result, string optionsEndUrl) 
        => new() { Response = $"{optionsEndUrl}#{String.Join("&", result.Properties.Select(pair => $"{pair.Key}={pair.Value}"))}" };
}