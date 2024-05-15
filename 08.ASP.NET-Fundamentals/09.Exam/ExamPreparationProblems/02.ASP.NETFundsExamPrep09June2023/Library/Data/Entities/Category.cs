namespace Library.Data.Entities;

using System.ComponentModel.DataAnnotations;
using static DataConstants.Category;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameLengthMax)]
    public string Name { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
}