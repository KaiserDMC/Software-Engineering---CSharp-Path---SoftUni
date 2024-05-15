namespace Boardgames.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using Enums;

public class Boardgame
{
    public Boardgame()
    {
        this.BoardgamesSellers = new HashSet<BoardgameSeller>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public double Rating { get; set; }

    [Required]
    public int YearPublished { get; set; }

    [Required]
    public CategoryType CategoryType { get; set; }

    [Required]
    public string Mechanics { get; set; }

    [Required, ForeignKey(nameof(Creator))]
    public int CreatorId { get; set; }
    public Creator Creator { get; set; }

    public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
}