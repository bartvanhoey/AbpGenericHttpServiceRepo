using IdentityModel.OidcClient;
using Microsoft.Extensions.Configuration;
using static System.ArgumentNullException;

namespace BookStoreMaui.Services.OpenIddict.Infra;

public static class OidcClientCreator
{
    public static OidcClient CreateClient(this OpenIddictSettings settings)
    {
        ThrowIfNull(settings);

        var oidcClientOptions = new OidcClientOptions
        {
            Authority = settings.AuthorityUrl,
            ClientId = settings.ClientId,
            Scope = settings.Scope,
            RedirectUri = settings.RedirectUri,
            ClientSecret = settings.ClientSecret,
            PostLogoutRedirectUri = settings.PostLogoutRedirectUri,
            Browser = new WebAuthenticatorBrowser(),
        };
        var client = new OidcClient(oidcClientOptions);

#if DEBUG
        client.Options.HttpClientFactory = HttpClientResolver.GetHttpClientByPlatform;
#endif
        return client;

    }

 
}