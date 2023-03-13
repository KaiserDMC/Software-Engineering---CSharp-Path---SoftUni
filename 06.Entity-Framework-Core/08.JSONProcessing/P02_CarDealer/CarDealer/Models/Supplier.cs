namespace CarDealer.Models;

public class Supplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsImporter { get; set; }

    public ICollection<Part> Parts { get; set; } = new List<Part>();
}