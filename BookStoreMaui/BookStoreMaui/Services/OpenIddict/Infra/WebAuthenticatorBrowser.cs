using IdentityModel.OidcClient.Browser;
using static System.String;
using IBrowser = IdentityModel.OidcClient.Browser.IBrowser;

namespace BookStoreMaui.Services.OpenIddict.Infra
{
    internal class WebAuthenticatorBrowser(string? callbackUrl = null) : IBrowser
    {
        private readonly string _callbackUrl = callbackUrl ?? "";
        public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default)
        {
            try
            {
                var authenticatorOptions = new WebAuthenticatorOptions
                {
                    Url = new Uri(options.StartUrl),
                    CallbackUrl = new Uri(IsNullOrEmpty(_callbackUrl) ? options.EndUrl : _callbackUrl),
                    PrefersEphemeralWebBrowserSession = true
                };

                var authResult = await WebAuthenticator.Default.AuthenticateAsync(authenticatorOptions);
                return authResult.GetBrowserResult(options.EndUrl);
            }
            catch (TaskCanceledException ex)
            {
                return GetBrowserResult(ex);
            }
            catch (Exception ex)
            {
              return  GetBrowserResult(ex);
            }
        }

        private static BrowserResult GetBrowserResult(Exception ex)
        {
            return new BrowserResult
            {
                ResultType = BrowserResultType.UnknownError,
                Error = ex.ToString()
            };
        }
    }
}