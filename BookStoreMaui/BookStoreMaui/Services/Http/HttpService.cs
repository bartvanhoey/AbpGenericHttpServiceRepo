using System.Text;
using BookStoreMaui.Functional;
using BookStoreMaui.Services.Http.Infra;
using BookStoreMaui.Services.SecureStorage;


namespace BookStoreMaui.Services.Http;

public class HttpService<T, TC, TU, TL, TD>(ISecureStorageService secureStorageService)
    : HttpServiceBase<T, TC, TU, TL, TD>(secureStorageService), IHttpService<T, TC, TU, TL, TD>
    where T : class
    where TC : class
    where TU : class
    where TL : class
{
    public async Task<ListResultDto<T>> GetListAsync(string uri, TL? getListRequestDto = default)
    {
        if (getListRequestDto == null) return new ListResultDto<T>();

        var httpResponse = await (await GetHttpClientAsync()).Value.GetAsync(ComposeUri(uri, getListRequestDto));

        var json = await httpResponse.Content.ReadAsStringAsync();
        if (json == "[]" || json.IsNullOrWhiteSpace()) return new ListResultDto<T>();
        
        if (getListRequestDto is IPagedRequestDto)
        {
            var pagedResultDto = json.ToType<PagedResultDto<T>>();
            return new PagedResultDto<T>(pagedResultDto.TotalCount, pagedResultDto.Items);
        }

        var listResultDto = new ListResultDto<T>(json.ToType<List<T>>());
        return listResultDto;
    }

    public async Task<ListResultDto<T>> UpdateAsync(string uri, TU updateInputDto)
    {
            var httpResponse = await (await GetHttpClientAsync())
                .Value.PutAsync($"{uri}", new StringContent(updateInputDto.ToJson(), Encoding.UTF8, "application/json"));

            var json = await httpResponse.Content.ReadAsStringAsync();
            if (json == "[]" || json.IsNullOrWhiteSpace()) return new ListResultDto<T>();

            if(json.StartsWith("{") && json.EndsWith("}"))
                return new ListResultDto<T>(new List<T> { json.ToType<T>() });
            
            var items = json.ToType<List<T>>();
            
            return new ListResultDto<T>(items);
        
    }

    public async Task<T> CreateAsync(string uri, TC createInputDto)
    {
        var httpResponse = await (await GetHttpClientAsync())
            .Value.PostAsync(uri, new StringContent(createInputDto.ToJson(), Encoding.UTF8, "application/json"));

        var json = await httpResponse.Content.ReadAsStringAsync();
        return json.ToType<T>();
    }

    public async Task CreateManyAsync(string uri, IEnumerable<TC> createInputDto)
    {
        var httpResponse = await (await GetHttpClientAsync())
            .Value.PostAsync($"{uri}/many", new StringContent(createInputDto.ToJson(), Encoding.UTF8, "application/json"));

        httpResponse.EnsureSuccessStatusCode();
    }

    

    public async Task<T> GetAsync(string uri)
    {
        var httpResponse = await (await GetHttpClientAsync()).Value.GetAsync(uri);
        var json = await httpResponse.Content.ReadAsStringAsync();
        return json.ToType<T>() ;
    }

    public async Task DeleteAsync(string uri, TD id)
    {
        var httpResponse = await (await GetHttpClientAsync()).Value.DeleteAsync($"{uri}/{id}" );
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception("Failed to delete");
        }
    }
}