using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PT_HospitalApp.Data
{
    public class HospitalDbContext : IdentityDbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
           : base(options)
           => this.Database.EnsureCreated();

        public DbSet<Examination> Examinations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<IdentityUser>();

            var patientLinda = new IdentityUser()
            {
                Id = "PatientLindaId",
                UserName = "linda@mail.com",
                NormalizedUserName = "linda@mail.com",
                Email = "linda@mail.com",
                NormalizedEmail = "linda@mail.com"
            };

            patientLinda.PasswordHash = hasher.HashPassword(patientLinda, "linda123");
            builder.Entity<IdentityUser>()
                .HasData(patientLinda);

            var patientJames = new IdentityUser()
            {
                Id = "PatientJamesId",
                UserName = "james@mail.com",
                NormalizedUserName = "james@mail.com",
                Email = "james@mail.com",
                NormalizedEmail = "james@mail.com"
            };

            patientJames.PasswordHash = hasher.HashPassword(patientJames, "james123");
            builder.Entity<IdentityUser>()
                .HasData(patientJames);

            builder.Entity<Examination>()
                .HasData(new List<Examination>()
                {
                    new Examination()
                    {
                        Id = 1,
                        Date = DateTime.Now.AddDays(-50),
                        Diagnosis = "Should take paracetamol for the headache.",
                        DoctorName = "Talia James",
                        DoctorSpeciality = "Neurologist",
                        PatientId = patientLinda.Id
                    },
                    new Examination()
                    {
                        Id = 2,
                        Date = DateTime.Now.AddDays(-1),
                        Diagnosis = "Has allergy to flowers.",
                        DoctorName = "Michael Drake",
                        DoctorSpeciality = "Allergist",
                        PatientId = patientLinda.Id
                    },
                    new Examination()
                    {
                        Id = 3,
                        Date = DateTime.Now.AddDays(-23),
                        Diagnosis = "Needs physiotherapy for the right hand.",
                        DoctorName = "Hannah Brown",
                        DoctorSpeciality = "Orthopedist",
                        PatientId = patientJames.Id
                    }
                });

            base.OnModelCreating(builder);
        }
    }
}