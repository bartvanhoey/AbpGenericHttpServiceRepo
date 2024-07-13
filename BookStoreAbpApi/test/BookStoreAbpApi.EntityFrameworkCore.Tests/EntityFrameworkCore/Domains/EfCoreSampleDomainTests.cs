using BookStoreAbpApi.Samples;
using Xunit;

namespace BookStoreAbpApi.EntityFrameworkCore.Domains;

[Collection(BookStoreAbpApiTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<BookStoreAbpApiEntityFrameworkCoreTestModule>
{

}
