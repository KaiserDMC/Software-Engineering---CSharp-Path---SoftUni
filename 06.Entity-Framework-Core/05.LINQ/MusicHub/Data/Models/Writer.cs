namespace MusicHub.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Writer
{
    public Writer()
    {
        this.Songs = new HashSet<Song>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.WriterNameMaxLength)]
    public string Name { get; set; } = null!;

    public string? Pseudonym { get; set; }

    public virtual ICollection<Song> Songs { get; set; }
}