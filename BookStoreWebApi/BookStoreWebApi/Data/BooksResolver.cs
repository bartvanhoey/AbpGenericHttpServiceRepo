using BookStoreWebApi.Dtos.Books;

namespace BookStoreWebApi.Data
 {
    public static class BooksResolver
    {
        public static readonly List<BookDto> BookItems;

        static BooksResolver()
        {
            BookItems = new List<BookDto>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "1984",
                    Type = BookType.Dystopia,
                    PublishDate = new DateTime(1949, 6, 8),
                    Price = 19.84f
                },

                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "The Hitchhiker's Guide to the Galaxy",
                    Type = BookType.ScienceFiction,
                    PublishDate = new DateTime(1995, 9, 27),
                    Price = 42.0f
                },
            };
        }
    }
}
