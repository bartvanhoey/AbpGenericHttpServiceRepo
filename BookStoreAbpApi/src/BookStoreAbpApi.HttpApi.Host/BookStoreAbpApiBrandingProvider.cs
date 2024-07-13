using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace BookStoreAbpApi;

[Dependency(ReplaceServices = true)]
public class BookStoreAbpApiBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BookStoreAbpApi";
}
