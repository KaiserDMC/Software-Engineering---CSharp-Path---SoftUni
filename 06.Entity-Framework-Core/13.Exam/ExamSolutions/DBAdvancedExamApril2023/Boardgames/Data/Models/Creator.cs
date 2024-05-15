namespace Boardgames.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Creator
{
    public Creator()
    {
        this.Boardgames = new HashSet<Boardgame>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public virtual ICollection<Boardgame> Boardgames { get; set; }
}