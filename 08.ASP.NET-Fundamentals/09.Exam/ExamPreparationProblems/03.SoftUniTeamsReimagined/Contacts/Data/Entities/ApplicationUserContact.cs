namespace Contacts.Data.Entities;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

public class ApplicationUserContact
{
    [ForeignKey(nameof(ApplicationUser))]
    public string ApplicationUserId { get; set; } = null!;
    public IdentityUser ApplicationUser { get; set; } = null!;

    [ForeignKey(nameof(Contact))]
    public Guid ContactId { get; set; }

    public Contact Contact { get; set; } = null!;
}