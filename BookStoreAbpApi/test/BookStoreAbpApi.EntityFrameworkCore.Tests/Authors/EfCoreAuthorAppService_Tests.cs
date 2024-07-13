using Acme.BookStore.Authors;
using Xunit;

namespace BookStoreAbpApi.EntityFrameworkCore.Applications.Authors;

[Collection(BookStoreAbpApiTestConsts.CollectionDefinitionName)]
public class EfCoreAuthorAppService_Tests : AuthorAppService_Tests<BookStoreAbpApiEntityFrameworkCoreTestModule>
{

}
