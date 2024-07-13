using BookStoreAbpConsole.Services.SecureStorage;
using IdentityModel.Client;

namespace BookStoreAbpConsole.Services.Http.Infra;

public class HttpServiceBase<T, TC, TU, TG, TD>(ISecureStorageService secureStorageService)
{
    
    const string ApiEndpoint = "https://localhost:44344/";
    
    private ISecureStorageService StorageService { get; set; } = secureStorageService;

    protected async Task<Lazy<HttpClient>> GetHttpClientAsync()
    {
        var httpClient = new Lazy<HttpClient>(() => new HttpClient());

        var tokens = await GetTokensFromBookStoreApi();
        var accessToken = await StorageService.GetAccessTokenAsync();

        httpClient.Value.SetBearerToken(tokens.AccessToken ?? throw new InvalidOperationException());
        return httpClient;
    }

    protected static string ComposeUri(string uri, TG getListRequestDto)
    {
        if (getListRequestDto is IPagedRequestDto pagedRequestDto)
            return uri.Contains('?')
                ? $"{uri}&skipCount={pagedRequestDto.SkipCount}&maxResultCount={pagedRequestDto.MaxResultCount}"
                : $"{uri}?skipCount={pagedRequestDto.SkipCount}&maxResultCount={pagedRequestDto.MaxResultCount}";
        return uri;
    }

    private static async Task<TokenResponse> GetTokensFromBookStoreApi()
    {
        var discoveryCache = new DiscoveryCache(ApiEndpoint);
        var disco = await discoveryCache.GetAsync();
        var httpClient = new Lazy<HttpClient>(() => new HttpClient());
        var response = await httpClient.Value.RequestPasswordTokenAsync(new PasswordTokenRequest
        {
            Address = disco.TokenEndpoint, // apiEndpoint/connect/token
            ClientId = "BookStore_Console",
            ClientSecret = "1q2w3e*",
            UserName = "admin",
            Password = "1q2w3E*",
            Scope = "openid offline_access address email phone profile roles BookStoreAbpApi",
        });
        return response.IsError ? new TokenResponse() : response;
    }
}