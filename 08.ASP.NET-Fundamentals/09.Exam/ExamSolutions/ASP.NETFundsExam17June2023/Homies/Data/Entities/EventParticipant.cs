namespace Homies.Data.Entities;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class EventParticipant
{
    [Required]
    [ForeignKey(nameof(Helper))]
    public string HelperId { get; set; } = null!;
    public IdentityUser Helper { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Event))]
    public int EventId { get; set; }
    public Event Event { get; set; } = null!;
}