using BookStoreWebApi.Dtos.Authors;

namespace BookStoreWebApi.Data;

public static class AuthorsResolver
{
    public static readonly List<AuthorDto> AuthorItems;

    static AuthorsResolver()
    {
        AuthorItems = new List<AuthorDto>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "George Orwell",
                BirthDate = new DateTime(1903, 06, 25),
                ShortBio =
                    "Orwell produced literary criticism and poetry, fiction and polemical journalism; and is best known for the allegorical novella Animal Farm (1945) and the dystopian novel Nineteen Eighty-Four (1949)."
            },
            new()
            {
                Id = Guid.NewGuid(),
               Name = "Douglas Adams",
               BirthDate = new DateTime(1952, 03, 11),
               ShortBio  = "Douglas Adams was an English author, screenwriter, essayist, humorist, satirist and dramatist. Adams was an advocate for environmentalism and conservation, a lover of fast cars, technological innovation and the Apple Macintosh, and a self-proclaimed 'radical atheist'."
            }
        };
    }
    
}