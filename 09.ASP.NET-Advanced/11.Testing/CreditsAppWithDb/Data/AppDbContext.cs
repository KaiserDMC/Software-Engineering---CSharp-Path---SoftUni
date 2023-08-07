using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CreditsAppWithDb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<CreditDecision> CreditDecisions { get; set; }
    }
}
