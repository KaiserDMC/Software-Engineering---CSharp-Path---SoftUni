namespace Homies.Core.Models;

using Microsoft.AspNetCore.Identity;

public class EventDetailsViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public string OrganiserId { get; set; } = null!;
    public IdentityUser Organiser { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public int TypeId { get; set; }

    public string Type { get; set; } = null!;
}