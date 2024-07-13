namespace BookStoreConsole.Services.Http.Infra;
public class HttpServiceBase<TL>
{
    protected Task<Lazy<HttpClient>> GetHttpClientAsync()
    {
        var httpClient = new Lazy<HttpClient>(() => new HttpClient());
        return Task.FromResult(httpClient);
    }

    protected static string ComposeUri(string uri, TL getListRequestDto)
    {
        if (getListRequestDto is IPagedRequestDto pagedRequestDto)
        {
            var composeUri = uri.Contains('?')
                ? $"{uri}&skipCount={pagedRequestDto.SkipCount}&maxResultCount={pagedRequestDto.MaxResultCount}"
                : $"{uri}?skipCount={pagedRequestDto.SkipCount}&maxResultCount={pagedRequestDto.MaxResultCount}";
            return composeUri;
        }

        return uri;
    }
}



// public class HttpServiceBase<T, TC, TU, TG, TD>(ISecureStorageService secureStorageService)
// {
//     private ISecureStorageService StorageService { get; set; } = secureStorageService;
//
//     protected async Task<Lazy<HttpClient>> GetHttpClientAsync()
//     {
//         var httpClient = new Lazy<HttpClient>(() => new HttpClient());
//         var accessToken = await StorageService.GetAccessTokenAsync();
//         httpClient.Value.SetBearerToken(accessToken);
//         return httpClient;
//     }
//
//     protected static string ComposeUri(string uri, TG getListRequestDto)
//     {
//         if (getListRequestDto is IPagedRequestDto pagedRequestDto)
//             return uri.Contains('?')
//                 ? $"{uri}&skipCount={pagedRequestDto.SkipCount}&maxResultCount={pagedRequestDto.MaxResultCount}"
//                 : $"{uri}?skipCount={pagedRequestDto.SkipCount}&maxResultCount={pagedRequestDto.MaxResultCount}";
//         return uri;
//     }
// }