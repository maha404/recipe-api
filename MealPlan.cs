public class MealPlan
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateOnly Date { get; set; }
    // public string? Week { get; set; }
    public int RecipieId { get; set; }
    public Recipie? Recipie { get; set; }
}