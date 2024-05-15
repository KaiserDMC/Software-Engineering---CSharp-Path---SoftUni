namespace Footballers.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Team
{
    public Team()
    {
        this.TeamsFootballers = new HashSet<TeamFootballer>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Nationality { get; set; }

    [Required]
    public int Trophies { get; set; }

   public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; }
}