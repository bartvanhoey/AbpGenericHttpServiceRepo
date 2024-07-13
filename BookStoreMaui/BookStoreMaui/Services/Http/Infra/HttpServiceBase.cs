using BookStoreMaui.Services.SecureStorage;
using IdentityModel.Client;

namespace BookStoreMaui.Services.Http.Infra;

public class HttpServiceBase<T, TC, TU, TG, TD>(ISecureStorageService secureStorageService)
{
    private ISecureStorageService StorageService { get; set; } = secureStorageService;

    protected async Task<Lazy<HttpClient>> GetHttpClientAsync()
    {
        var httpClient = new Lazy<HttpClient>(() => new HttpClient());
        var accessToken = await StorageService.GetAccessTokenAsync();
        httpClient.Value.SetBearerToken(accessToken);
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
    
    
}