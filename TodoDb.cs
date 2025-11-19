using Microsoft.EntityFrameworkCore;

public class RecipieDb : DbContext
{
    public RecipieDb(DbContextOptions<RecipieDb> options)
        : base(options)
    {
    }

    public DbSet<Recipie> Recipie => Set<Recipie>();
}