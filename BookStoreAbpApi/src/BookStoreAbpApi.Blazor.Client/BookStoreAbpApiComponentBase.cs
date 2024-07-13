using BookStoreAbpApi.Localization;
using Volo.Abp.AspNetCore.Components;

namespace BookStoreAbpApi.Blazor.Client;

public abstract class BookStoreAbpApiComponentBase : AbpComponentBase
{
    protected BookStoreAbpApiComponentBase()
    {
        LocalizationResource = typeof(BookStoreAbpApiResource);
    }
}
