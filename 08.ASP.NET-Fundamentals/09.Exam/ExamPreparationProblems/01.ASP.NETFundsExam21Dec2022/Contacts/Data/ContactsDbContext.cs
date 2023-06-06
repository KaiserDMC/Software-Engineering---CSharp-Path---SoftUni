namespace Contacts.Data;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Models;


public class ContactsDbContext : IdentityDbContext<ApplicationUser>
{
    public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Contact> Contacts { get; set; } = null!;
    public DbSet<ApplicationUserContact> ApplicationUsersContacts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ApplicationUserContact>(entity =>
        {
            entity.HasKey(a => new { a.ContactId, a.ApplicationUserId });
        });

        builder
            .Entity<Contact>()
            .HasData(new Contact()
            {
                Id = 1,
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