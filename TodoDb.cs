using Microsoft.EntityFrameworkCore;

public class RecipieDb : DbContext
{

    public DbSet<Recipie> Recipes => Set<Recipie>();
    public DbSet<MealPlan> MealPlans => Set<MealPlan>();

    public RecipieDb(DbContextOptions<RecipieDb> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MealPlan>()
            .HasOne(mp => mp.Recipie)
            .WithMany(r => r.MealPlans)
            .HasForeignKey(mp => mp.RecipieId);
    }

    public DbSet<Recipie> Recipie => Set<Recipie>();
}