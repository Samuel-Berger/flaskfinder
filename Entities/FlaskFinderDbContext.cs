using Microsoft.EntityFrameworkCore;

namespace Entities;

public class FlaskFinderDbContext : DbContext
{
    public FlaskFinderDbContext() { }

    public FlaskFinderDbContext(DbContextOptions<FlaskFinderDbContext> options) : base(options)
    {
    }

    public required DbSet<Wine> Wines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Wine>(e =>
        {
            e.ToTable("wine");
            e.HasKey("Id");
        });

        modelBuilder.Entity<Blend>(e =>
        {
            e.ToTable("Blend");
            e.HasKey(e => new { e.Grape, e.Percentage });
        });

        base.OnModelCreating(modelBuilder);
    }
}
