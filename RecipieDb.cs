using Microsoft.EntityFrameworkCore;

public class RecipieDb : DbContext
{

    public DbSet<Recipie> Recipes => Set<Recipie>();
    public DbSet<MealPlan> MealPlans => Set<MealPlan>();
    public DbSet<OnlineRecipie> OnlineRecipie => Set<OnlineRecipie>();

    public RecipieDb(DbContextOptions<RecipieDb> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MealPlan>()
        .HasOne(m => m.OnlineRecipie)
        .WithMany(o => o.MealPlans)
        .HasForeignKey(m => m.OnlineRecipieId)
        .OnDelete(DeleteBehavior.SetNull);
    }

    public DbSet<Recipie> Recipie => Set<Recipie>();
}