using BookStoreAbpApi.Samples;
using Xunit;

namespace BookStoreAbpApi.EntityFrameworkCore.Applications;

[Collection(BookStoreAbpApiTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<BookStoreAbpApiEntityFrameworkCoreTestModule>
{

}
