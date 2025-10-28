using Microsoft.EntityFrameworkCore;

public class RecipeDb : DbContext
{
    public RecipeDb(DbContextOptions<RecipeDb> options)
        : base(options)
    {
    }

    public DbSet<Recipe> Recipes => Set<Recipe>();
}