namespace Homies.Data.Entities;

using System.ComponentModel.DataAnnotations;

using static DataConstants.Type;

public class Type
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    public ICollection<Event> Events { get; set; } = new List<Event>();
}