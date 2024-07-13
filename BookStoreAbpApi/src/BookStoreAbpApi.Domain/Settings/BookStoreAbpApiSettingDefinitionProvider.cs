using Volo.Abp.Settings;

namespace BookStoreAbpApi.Settings;

public class BookStoreAbpApiSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BookStoreAbpApiSettings.MySetting1));
    }
}
