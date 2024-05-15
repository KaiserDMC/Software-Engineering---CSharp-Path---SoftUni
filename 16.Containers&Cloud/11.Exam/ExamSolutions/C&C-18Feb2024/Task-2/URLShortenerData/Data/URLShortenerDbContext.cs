using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using URLShortenerData.Data.Entities;

namespace URLShortenerData.Data
{
    public class URLShortenerDbContext : IdentityDbContext
    {
        private bool seedDb = true;
        private IdentityUser GuestUser { get; set; }
        private URLAddress FirstURLAddress { get; set; }
        private URLAddress SecondURLAddress { get; set; }
        private URLAddress ThirdURLAddress { get; set; }
        public URLShortenerDbContext(DbContextOptions<URLShortenerDbContext> options, bool seedDb = true)
            : base(options)
        {
            this.seedDb = seedDb;
            this.Database.EnsureCreated();
        }

        public DbSet<URLAddress> URLAddresses { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (seedDb)
            {
                SeedUser();
                builder.Entity<IdentityUser>()
                    .HasData(this.GuestUser);

                SeedURLAddress();
                builder.Entity<URLAddress>()
                    .HasData(this.FirstURLAddress,
                    this.SecondURLAddress,
                    this.ThirdURLAddress);
            }
            base.OnModelCreating(builder);
        }

        private void SeedURLAddress()
        {
            this.FirstURLAddress = new URLAddress()
            {
                Id = 1,
                OriginalUrl = "https://nakov.com",
                ShortUrl = "http://shorturl.nakov.repl.co/go/nak",
                DateCreated = new DateTime(2024, 02, 17, 14, 41, 33),
                Visits = 160,
                UserId = this.GuestUser.Id

            };
            this.SecondURLAddress = new URLAddress()
            {
                Id = 2,
                OriginalUrl = "https://selenium.dev",
                ShortUrl = "http://shorturl.nakov.repl.co/go/seldev",
                DateCreated = new DateTime(2024, 02, 17, 22, 07, 08),
                Visits = 43,
                UserId = this.GuestUser.Id
            };
            this.ThirdURLAddress = new URLAddress()
            {
                Id = 3,
                OriginalUrl = "https://nodejs.org",
                ShortUrl = "http://shorturl.nakov.repl.co/go/node",
                DateCreated = new DateTime(2024, 02, 19, 16, 41, 56),
                Visits = 86,
                UserId = this.GuestUser.Id
            };
        }

        private void SeedUser()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            this.GuestUser = new IdentityUser()
            {
                UserName = "guest@mail.com",
                NormalizedUserName = "GUEST@MAIL.COM",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM"
            };

            this.GuestUser.PasswordHash = hasher.HashPassword(this.GuestUser, "guest123");
        }
    }
}
