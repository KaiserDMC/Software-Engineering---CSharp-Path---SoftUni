namespace Contacts.ViewModels;

using System.ComponentModel.DataAnnotations;
using static Data.DataConstants.Contact;

public class ContactViewModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(FirstNameLengthMax, MinimumLength = FirstNameLengthMin)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(LastNameLengthMax, MinimumLength = LastNameLengthMin)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(EmailLengthMax, MinimumLength = EmailLengthMin)]
    public string Email { get; set; }

    [Required]
    [RegularExpression(PhoneNumberRegEx)]
    public string PhoneNumber { get; set; }

    public string? Address { get; set; }

    [Required]
    [RegularExpression(WebsiteRegEx)]
    public string Website { get; set; }
}