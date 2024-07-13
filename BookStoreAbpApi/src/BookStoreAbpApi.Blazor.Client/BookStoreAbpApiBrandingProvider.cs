using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace BookStoreAbpApi.Blazor.Client;

[Dependency(ReplaceServices = true)]
public class BookStoreAbpApiBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BookStoreAbpApi";
}
