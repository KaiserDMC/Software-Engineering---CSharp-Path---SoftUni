namespace Library.Models.FormModels;

using System.ComponentModel.DataAnnotations;
using static Data.DataConstants.Book;

using ViewModels;

public class BookFromModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(TitleLengthMax, MinimumLength = TitleLengthMin)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(AuthorLengthMax, MinimumLength = AuthorLengthMin)]
    public string Author { get; set; } = null!;

    [Required]
    [StringLength(DescriptionMax, MinimumLength = DescriptionMin)]
    public string Description { get; set; } = null!;

    [Required]
    public string ImageUrl { get; set; } = null!;

    [Required]
    [Range(typeof(decimal), RatingDecimalMin, RatingDecimalMax)]
    public decimal Rating { get; set; }

    public int CategoryId { get; set; }

    public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
}