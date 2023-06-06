namespace Contacts.Data.Models;

using System.ComponentModel.DataAnnotations;
using static DataConstants.Contact;

public class Contact
{
    public int Id { get; set; }

    [Required]
    [MaxLength(FirstNameLengthMax)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(LastNameLengthMax)]
    public string LastName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [MaxLength(EmailLengthMax)]
    public string Email { get; set; } = null!;

    [Required]
    [Phone]
    [MaxLength(PhoneNumberMax)]
    public string PhoneNumber { get; set; } = null!;

    public string? Address { get; set; }

    [Required]
    public string Website { get; set; } = null!;

    public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; }
}