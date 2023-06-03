namespace Forum.Data.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Models;
using Seeding;

public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
{
    private readonly PostSeeder _seeder;

    public PostEntityConfiguration()
    {
        this._seeder = new PostSeeder();
    }

    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasData(this._seeder.GeneratePosts());
    }
}