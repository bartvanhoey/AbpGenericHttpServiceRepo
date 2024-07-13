using Xunit;

namespace BookStoreAbpApi.EntityFrameworkCore;

[CollectionDefinition(BookStoreAbpApiTestConsts.CollectionDefinitionName)]
public class BookStoreAbpApiEntityFrameworkCoreCollection : ICollectionFixture<BookStoreAbpApiEntityFrameworkCoreFixture>
{

}
