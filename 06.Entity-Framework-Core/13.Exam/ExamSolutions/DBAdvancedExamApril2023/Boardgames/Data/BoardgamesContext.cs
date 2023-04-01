namespace Boardgames.Data;

using Microsoft.EntityFrameworkCore;

using Models;

public class BoardgamesContext : DbContext
{
    public BoardgamesContext()
    {
    }

    public BoardgamesContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Boardgame> Boardgames { get; set; } = null!;
    public DbSet<Seller> Sellers { get; set; } = null!;
    public DbSet<Creator> Creators { get; set; } = null!;
    public DbSet<BoardgameSeller> BoardgamesSellers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer(Configuration.ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BoardgameSeller>(entity =>
        {
            entity.HasKey(pk => new { pk.BoardgameId, pk.SellerId });
        });
    }
}