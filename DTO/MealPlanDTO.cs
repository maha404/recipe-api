
namespace recipe_api.DTO
{
    public class MealPlanDto
    {
        public DateOnly Date { get; set; }
        public RecipeDto Recipe { get; set; } = null!;
    }
}
