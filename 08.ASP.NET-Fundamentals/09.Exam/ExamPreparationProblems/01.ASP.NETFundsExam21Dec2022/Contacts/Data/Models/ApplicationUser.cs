namespace Contacts.Data.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using static DataConstants.ApplicationUser;

public class ApplicationUser : IdentityUser
{
    //[Key]
    //public string Id { get; set; } = null!;

    //[Required]
    //[MaxLength(UsernameLengthMax)]
    //public string UserName { get; set; } = null!;

    //[Required]
    //[MaxLength(EmailLengthMax)]
    //public string Email { get; set; } = null!;

    //[Required]
    //[MaxLength(PasswordLengthMax)]
    //public string Password { get; set; } = null!;

    public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; }
}