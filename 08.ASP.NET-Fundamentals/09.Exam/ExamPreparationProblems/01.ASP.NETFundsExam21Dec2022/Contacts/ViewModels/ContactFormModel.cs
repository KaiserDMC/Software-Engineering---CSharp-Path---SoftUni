namespace Contacts.ViewModels;

using System.ComponentModel.DataAnnotations;
using static Data.DataConstants.Contact;

public class ContactFormModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(FirstNameLengthMax, MinimumLength = FirstNameLengthMin)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(LastNameLengthMax, MinimumLength = LastNameLengthMin)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "E-mail")]
    [StringLength(EmailLengthMax, MinimumLength = EmailLengthMin)]
    public string Email { get; set; }

    [Required]
    [StringLength(PhoneNumberMax)]
    [RegularExpression(PhoneNumberRegEx)]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }


    public string? Address { get; set; }

    [Required]
    [RegularExpression(WebsiteRegEx)]
    public string Website { get; set; }
}