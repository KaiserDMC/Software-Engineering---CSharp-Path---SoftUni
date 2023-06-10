namespace Library.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DataConstants.Book;

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(TitleLengthMax)]
    public string Title { get; set; }

    [Required]
    [MaxLength(AuthorLengthMax)]
    public string Author { get; set; }

    [Required]
    [MaxLength(DescriptionMax)]
    public string Description { get; set; }

    [Required]
    public string ImageUrl { get; set; }

    [Required]
    [Range(typeof(decimal), RatingDecimalMin, RatingDecimalMax)]
    public decimal Rating { get; set; }

    [Required]
    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public ICollection<IdentityUserBook> UsersBooks { get; set; } = new List<IdentityUserBook>();
}