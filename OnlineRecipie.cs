public class OnlineRecipie
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Url { get; set; } = null!;
    public ICollection<MealPlan> MealPlans { get; set; } = new List<MealPlan>();
}