using System.ComponentModel.DataAnnotations;

namespace BookStoreWebApi.Dtos.Books
{
    public class CreateBookDto
    {
        public Guid Id { get; set; }        

        [Required]
        [StringLength(128)]
        public string? Name { get; set; }

        [Required]

        public BookType Type { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate{ get; set;  }

        [Required]

        public float Price { get; set; }
        
        public Guid AuthorId { get; set; }
    }
}