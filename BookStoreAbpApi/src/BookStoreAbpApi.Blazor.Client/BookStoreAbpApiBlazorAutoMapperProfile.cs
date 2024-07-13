using AutoMapper;
using BookStoreAbpApi.Authors;
using BookStoreAbpApi.Books;

namespace BookStoreAbpApi.Blazor.Client;

public class BookStoreAbpApiBlazorAutoMapperProfile : Profile
{
    public BookStoreAbpApiBlazorAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Blazor project.

        CreateMap<BookDto, CreateBookDto>();
        CreateMap<BookDto, UpdateBookDto>();
        
        CreateMap<AuthorDto, UpdateAuthorDto>();
    }
}
