namespace Trucks.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Despatcher
{
    public Despatcher()
    {
        this.Trucks = new HashSet<Truck>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Position { get; set; }

    public virtual ICollection<Truck> Trucks { get; set; }
}