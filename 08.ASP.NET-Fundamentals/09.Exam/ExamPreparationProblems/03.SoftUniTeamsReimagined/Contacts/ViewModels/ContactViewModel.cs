namespace Contacts.ViewModels;

using System.ComponentModel.DataAnnotations;
using static Data.DataConstants.Contact;

public class ContactViewModel
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
    public string Email { get; set; }

    [Required]
    [Phone]
    [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
    public string Phone { get; set; }

    public string? Address { get; set; }

    [Required]
    [RegularExpression(WebsiteRegEx)]
    public string Website { get; set; }
}