using Microsoft.EntityFrameworkCore;

namespace SQLInjection_LoginApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(new User()
                {
                    Id = 1,
                    Username = "Admin",
                    Password = "adminpass"
                });

            base.OnModelCreating(builder);
        }
    }
}
