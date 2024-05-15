namespace Library.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

public class IdentityUserBook
{
    [Required]
    [ForeignKey(nameof(Collector))]
    public string CollectorId { get; set; }
    public IdentityUser Collector { get; set; }

    [Required]
    [ForeignKey(nameof(Book))]
    public int BookId { get; set; }
    public Book Book { get; set; }
}