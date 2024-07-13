using System;
using Microsoft.Extensions.Configuration;

namespace BookStoreMaui.Services.OpenIddict.Infra
{
    public static class ConfigurationExtensions
    {
        public static OpenIddictSettings GetOidcSettings(this IConfiguration configuration)
        {
            var oIddict = configuration.GetSection(nameof(OpenIddictSettings)).Get<OpenIddictSettings>();
            if (oIddict == null) throw new ArgumentNullException(nameof(OpenIddictSettings));
            return oIddict;
        }
        
        public static string GetAuthUrl(this IConfiguration configuration) => configuration.GetOidcSettings().AuthorityUrl ?? string.Empty;
        public static string GetBookApiUrl(this IConfiguration configuration) 
            => configuration.GetOidcSettings().AuthorityUrl != null ? $"{configuration.GetOidcSettings().AuthorityUrl}/api/app/book" : string.Empty;
        
        public static string GetAuthorApiUrl(this IConfiguration configuration) 
            => configuration.GetOidcSettings().AuthorityUrl != null ? $"{configuration.GetOidcSettings().AuthorityUrl}/api/app/author" : string.Empty;
    }
}
