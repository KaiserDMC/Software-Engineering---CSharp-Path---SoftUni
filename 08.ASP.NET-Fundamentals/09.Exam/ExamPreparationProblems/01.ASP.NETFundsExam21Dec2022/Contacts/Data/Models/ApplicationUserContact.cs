namespace Contacts.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ApplicationUserContact
{
    [Required]
    [ForeignKey(nameof(ApplicationUser))]
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

    [Required]
    [ForeignKey(nameof(Contact))]
    public int ContactId { get; set; }
    public Contact Contact { get; set; }
}