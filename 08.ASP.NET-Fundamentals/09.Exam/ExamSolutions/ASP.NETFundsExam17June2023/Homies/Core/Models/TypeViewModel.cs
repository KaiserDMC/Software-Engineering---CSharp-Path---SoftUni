namespace Homies.Core.Models;

using System.ComponentModel.DataAnnotations;

using static Homies.Data.DataConstants.Type;

public class TypeViewModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
    public string Name { get; set; } = null!;

    public ICollection<EventViewModel> Events { get; set; } = new List<EventViewModel>();
}