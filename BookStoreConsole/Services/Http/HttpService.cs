using System.Net.Http.Json;
using BookStoreConsole.Services.Http.Infra;

namespace BookStoreConsole.Services.Http;

public class HttpService<T, TC, TU, TL, TD> : HttpServiceBase<TL>, IHttpService<T, TC, TU, TL, TD>
    where T : class 
    where TC : class
    where TU : class
    where TL : class
{
    public async Task<ListResultDto<T>> GetListAsync(string uri, TL? getListRequestDto = default)
    {
        if (getListRequestDto == null) return new ListResultDto<T>();
        var httpResponse = await (await GetHttpClientAsync()).Value.GetAsync(ComposeUri(uri, getListRequestDto));
        httpResponse.EnsureSuccessStatusCode();
        var json = await httpResponse.Content.ReadAsStringAsync();
        if (json == "[]" || json.IsNullOrWhiteSpace()) return new ListResultDto<T>();
        if (getListRequestDto is IPagedRequestDto)
        {
            var pagedResultDto = json.ToType<PagedResultDto<T>>();
            return new PagedResultDto<T>(pagedResultDto.TotalCount,pagedResultDto.Items);
        }
        return new ListResultDto<T>(json.ToType<List<T>>());
    }

    public async Task<ListResultDto<T>> UpdateAsync(string uri, TU updateInputDto)
    {
        var httpResponse = await (await GetHttpClientAsync()).Value.PutAsJsonAsync($"{uri}", updateInputDto);
        httpResponse.EnsureSuccessStatusCode();
        var json = await httpResponse.Content.ReadAsStringAsync();
        if (json == "[]" || json.IsNullOrWhiteSpace()) return new ListResultDto<T>();

        if (json.StartsWith("{") && json.EndsWith("}"))
            return new ListResultDto<T>(new List<T> { json.ToType<T>() });

        return new ListResultDto<T>(json.ToType<List<T>>());
    }

    public async Task<T> CreateAsync(string uri, TC createInputDto)
    {
        var httpResponse = await (await GetHttpClientAsync()).Value.PostAsJsonAsync(uri, createInputDto);
        httpResponse.EnsureSuccessStatusCode();
        return (await httpResponse.Content.ReadAsStringAsync()).ToType<T>();
    }

    public async Task CreateManyAsync(string uri, IEnumerable<TC> createInputDto)
    {
        var httpResponse = await (await GetHttpClientAsync()).Value.PostAsJsonAsync($"{uri}/many", createInputDto);
        httpResponse.EnsureSuccessStatusCode();
    }

    public async Task<T> GetAsync(string uri)
    {
        var httpResponse = await (await GetHttpClientAsync()).Value.GetAsync(uri);
        httpResponse.EnsureSuccessStatusCode();
        return (await httpResponse.Content.ReadAsStringAsync()).ToType<T>();
    }

    public async Task DeleteAsync(string uri, TD id)
    {
        var httpResponse = await (await GetHttpClientAsync()).Value.DeleteAsync($"{uri}/{id}");
        httpResponse.EnsureSuccessStatusCode();
    }
}