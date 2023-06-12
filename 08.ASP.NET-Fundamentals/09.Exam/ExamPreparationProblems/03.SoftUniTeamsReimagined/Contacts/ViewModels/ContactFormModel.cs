namespace Contacts.ViewModels;

using System.ComponentModel.DataAnnotations;
using static Data.DataConstants.Contact;

public class ContactFormModel
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
    public string LastName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
    public string Email { get; set; } = null!;

    [Required]
    [Phone]
    [Display(Name = "Phone Number")]
    [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
    public string Phone { get; set; } = null!;

    public string? Address { get; set; }

    [Required]
    [RegularExpression(WebsiteRegEx)]
    public string Website { get; set; } = null!;
}