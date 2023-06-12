namespace Contacts.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Contacts.Data.Entities;

public class ContactsDbContext : IdentityDbContext<IdentityUser>
{
    public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Contact> Contacts { get; set; } = null!;
    public DbSet<ApplicationUserContact> ApplicationUsersContacts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<ApplicationUserContact>()
            .HasKey(uc => new { uc.ApplicationUserId, uc.ContactId });

        builder
            .Entity<Contact>()
            .HasData(new Contact()
            {
                FirstName = "Bruce",
                LastName = "Wayne",
                PhoneNumber = "+359881223344",
                Address = "Gotham City",
                Email = "imbatman@batman.com",
                Website = "www.batman.com"
            });

        base.OnModelCreating(builder);
    }
}