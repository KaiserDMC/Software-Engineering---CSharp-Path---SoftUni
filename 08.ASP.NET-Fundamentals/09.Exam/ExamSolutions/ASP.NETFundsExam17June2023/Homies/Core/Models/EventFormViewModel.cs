namespace Homies.Core.Models;

using System.ComponentModel.DataAnnotations;

using Homies.Data;
using static Homies.Data.DataConstants.Event;

public class EventFormViewModel
{
    [Required]
    [StringLength(DataConstants.Event.NameMaxLength, MinimumLength = DataConstants.Event.NameMinLength)]
    public string Name { get; set; }

    [Required]
    [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
    public string Description { get; set; } = null!;

    [Required]
    public DateTime CreatedOn { get; set; }

    [Required]
    public string Start { get; set; }

    [Required]
    public string End { get; set; }

    [Required]
    public int TypeId { get; set; }

    [Required]
    public string OrganiserId { get; set; } = null!;

    public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
}