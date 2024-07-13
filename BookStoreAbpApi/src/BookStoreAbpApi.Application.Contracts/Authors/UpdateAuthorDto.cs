using System;
using System.ComponentModel.DataAnnotations;

namespace BookStoreAbpApi.Authors
{
    public class UpdateAuthorDto
{
    [Required]
    [StringLength(AuthorConsts.MaxNameLength)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public DateTime BirthDate { get; set; }
    
    public string? ShortBio { get; set; }
}
}