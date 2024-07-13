using System;
using System.Collections.Generic;
using System.Text;
using BookStoreAbpApi.Localization;
using Volo.Abp.Application.Services;

namespace BookStoreAbpApi;

/* Inherit your application services from this class.
 */
public abstract class BookStoreAbpApiAppService : ApplicationService
{
    protected BookStoreAbpApiAppService()
    {
        LocalizationResource = typeof(BookStoreAbpApiResource);
    }
}
