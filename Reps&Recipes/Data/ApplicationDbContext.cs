using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reps_Recipes.Models;

namespace Reps_Recipes.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Връзка много към много: Catalog - Diets
        builder.Entity<CatalogDiets>()
            .HasKey(cd => new { cd.CatalogId, cd.DietId });

        builder.Entity<CatalogDiets>()
            .HasOne(cd => cd.Catalog)
            .WithMany(c => c.CatalogDiets)
            .HasForeignKey(cd => cd.CatalogId);

        builder.Entity<CatalogDiets>()
            .HasOne(cd => cd.Diet)
            .WithMany(d => d.CatalogDiets)
            .HasForeignKey(cd => cd.DietId);

        // Връзка много към много: Catalog - WorkoutRegimes
        builder.Entity<CatalogRegimes>()
            .HasKey(cr => new { cr.CatalogId, cr.WorkoutRegimeId });

        builder.Entity<CatalogRegimes>()
            .HasOne(cr => cr.Catalog)
            .WithMany(c => c.CatalogRegimes)
            .HasForeignKey(cr => cr.CatalogId);

        builder.Entity<CatalogRegimes>()
            .HasOne(cr => cr.WorkoutRegime)
            .WithMany(wr => wr.CatalogRegimes)
            .HasForeignKey(cr => cr.WorkoutRegimeId);
    }
    public DbSet<Diet> Diets { get; set; }
    public DbSet<WorkoutRegime> WorkoutRegimes { get; set; }
    public DbSet<Catalog> Catalogs { get; set; }
    public DbSet<CatalogDiets> CatalogDiets { get; set; }
    public DbSet<CatalogRegimes> CatalogRegimes { get; set; }
}
