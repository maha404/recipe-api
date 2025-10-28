public class Recipe
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? PortionSize { get; set; }
    public string? PreparationTime { get; set; }
    public string? CookingTime { get; set; }
    public List<string>? Ingredients { get; set; }
    public string? Instructions { get; set; }
}