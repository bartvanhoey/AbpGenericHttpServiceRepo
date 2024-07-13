using AutoMapper;
using BookStoreAbpApi.Authors;
using BookStoreAbpApi.Books;

namespace BookStoreAbpApi;

public class BookStoreAbpApiApplicationAutoMapperProfile : Profile
{
    public BookStoreAbpApiApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

            CreateMap<Book, BookDto>();
            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();

            CreateMap<Author, AuthorDto>();
            CreateMap<Author, AuthorLookupDto>();
    }
}
