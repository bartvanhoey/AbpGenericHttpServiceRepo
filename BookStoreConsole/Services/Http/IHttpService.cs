using BookStoreConsole.Services.Http.Infra;

namespace BookStoreConsole.Services.Http;

public interface IHttpService<T, in TC, in TU, in TG, in TD>
{
    Task<ListResultDto<T>> GetListAsync(string uri, TG? getListRequestDto = default);
    Task<ListResultDto<T>> UpdateAsync(string uri, TU updateInputDto);
    Task<T> CreateAsync(string uri, TC createInputDto);
    Task CreateManyAsync(string uri, IEnumerable<TC> createManyInputDto);
    Task<T> GetAsync(string uri);
    Task DeleteAsync(string uri, TD id);
}