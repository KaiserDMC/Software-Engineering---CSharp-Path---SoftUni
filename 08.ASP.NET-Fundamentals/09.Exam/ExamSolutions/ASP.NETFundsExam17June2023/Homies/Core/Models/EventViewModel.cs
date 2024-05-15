namespace Homies.Core.Models;

using System.ComponentModel.DataAnnotations;

using Homies.Data;
using Homies.Data.Entities;
using Microsoft.AspNetCore.Identity;
using static Homies.Data.DataConstants.Event;
using static Homies.Data.DataConstants.Type;

public class EventViewModel
{

    public int Id { get; set; }

    [Required]
    [StringLength(DataConstants.Event.NameMaxLength, MinimumLength = DataConstants.Event.NameMinLength)]
    public string Name { get; set; }

    [Required]
    [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
    public string Description { get; set; } = null!;

    [Required]
    public string OrganiserId { get; set; } = null!;

    public IdentityUser Organiser { get; set; } = null!;

    [Required]
    public string CreatedOn { get; set; }

    [Required]
    public string Start { get; set; }

    [Required]
    public string End { get; set; }

    [Required]
    public int TypeId { get; set; }

    [Required]
    [StringLength(DataConstants.Type.NameMaxLength, MinimumLength = DataConstants.Type.NameMinLength)]
    public string Type { get; set; } = null!;

    public IEnumerable<EventParticipant> EventsParticipants { get; set; } = new List<EventParticipant>();
}