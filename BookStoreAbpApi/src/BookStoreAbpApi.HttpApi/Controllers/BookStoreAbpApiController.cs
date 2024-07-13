using BookStoreAbpApi.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BookStoreAbpApi.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BookStoreAbpApiController : AbpControllerBase
{
    protected BookStoreAbpApiController()
    {
        LocalizationResource = typeof(BookStoreAbpApiResource);
    }
}
