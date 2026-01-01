
namespace recipe_api.DTO
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? PortionSize { get; set; }
        public string? PreparationTime { get; set; }
        public string? CookingTime { get; set; }
        public List<string>? Ingredients { get; set; }
        public List<string>? Instructions { get; set; }
    }
}
