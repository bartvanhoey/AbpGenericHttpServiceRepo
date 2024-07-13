using BookStoreAbpApi.EntityFrameworkCore;
using Xunit;

namespace BookStoreAbpApi.Books;

[Collection(BookStoreAbpApiTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<BookStoreAbpApiEntityFrameworkCoreTestModule>
{

}