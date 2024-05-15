namespace Boardgames.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Seller
{
    public Seller()
    {
        this.BoardgamesSellers = new HashSet<BoardgameSeller>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public string Country { get; set; }

    [Required]
    public string Website { get; set; }

    public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
}