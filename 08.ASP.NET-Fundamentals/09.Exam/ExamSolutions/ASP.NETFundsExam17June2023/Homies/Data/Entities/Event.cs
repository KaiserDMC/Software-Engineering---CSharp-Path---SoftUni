namespace Homies.Data.Entities;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static DataConstants.Event;

public class Event
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(DescriptionMaxLength)]
    public string Description { get; set; } = null!;

    [Required,ForeignKey(nameof(Organiser))]
    public string OrganiserId { get; set; } = null!;
    [Required]
    public IdentityUser Organiser { get; set; } = null!;

    [Required]
    [DisplayFormat(DataFormatString = DateTimeFormat)]
    public DateTime CreatedOn { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = DateTimeFormat)]
    public DateTime Start { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = DateTimeFormat)]
    public DateTime End { get; set; }

    [Required, ForeignKey(nameof(Type))]
    public int TypeId { get; set; }
    [Required]
    public Type Type { get; set; } = null!;

    public ICollection<EventParticipant> EventsParticipants { get; set; } = new List<EventParticipant>();
}