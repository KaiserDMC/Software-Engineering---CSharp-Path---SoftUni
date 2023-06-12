namespace Contacts.Data.Entities;

using System.ComponentModel.DataAnnotations;
using static DataConstants.Contact;

public class Contact
{
    public Contact()
    {
        Id = Guid.NewGuid();
    }

    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(FirstNameMaxLength)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(LastNameMaxLength)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(EmailMaxLength)]
    public string Email { get; set; }

    [Required]
    [Phone]
    [MaxLength(PhoneNumberMaxLength)]
    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    [Required]
    [RegularExpression(WebsiteRegEx)]
    public string Website { get; set; }

    public IEnumerable<ApplicationUserContact> ApplicationUsersContacts { get; set; }
}