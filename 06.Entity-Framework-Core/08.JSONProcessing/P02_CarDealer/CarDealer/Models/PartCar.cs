namespace CarDealer.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class PartCar
{
    [ForeignKey(nameof(Part))]
    public int PartId { get; set; }
    public Part Part { get; set; } = null!;

    [ForeignKey(nameof(Car))]
    public int CarId { get; set; }
    public Car Car { get; set; } = null!;
}
