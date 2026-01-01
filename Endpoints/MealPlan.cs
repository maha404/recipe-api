using Microsoft.EntityFrameworkCore;
using System.Globalization;
using recipe_api.DTO;

namespace recipe_api.Endpoints
{
    public static class MealPlanEndpoints
    {

        static (DateOnly start, DateOnly end) GetWeekRange(int year, int week)
        {
            var firstThursday = new DateTime(year, 1, 4);

            var firstWeekStart = firstThursday.AddDays(
                DayOfWeek.Monday - firstThursday.DayOfWeek
            );

            var weekStart = firstWeekStart.AddDays((week - 1) * 7);
            var weekEnd = weekStart.AddDays(6);

            return (
                DateOnly.FromDateTime(weekStart),
                DateOnly.FromDateTime(weekEnd)
            );
        }

        static (DateOnly start, DateOnly end) GetMonthRange(int year, int month)
        {
            var start = new DateOnly(year, month, 1);
            var end = start.AddMonths(1).AddDays(-1);
            return (start, end);
        }
        public static void MapMealPlanEndpoints(this WebApplication app)
        {
            app.MapGet("/mealplan/week", async (int year, int week, RecipieDb db) =>
            {
                var (start, end) = GetWeekRange(year, week);

                var mealPlans = db.MealPlans
                .Where(mp => mp.Date >= start && mp.Date <= end)
                .OrderBy(mp => mp.Date)
                .Select(mp => new MealPlanDto
                {
                    Date = mp.Date,
                    Recipe = new RecipeDto
                    {
                        Id = mp.Recipie.Id,
                        Title = mp.Recipie.Title,
                        Description = mp.Recipie.Description,
                        PortionSize = mp.Recipie.PortionSize,
                        PreparationTime = mp.Recipie.PreparationTime,
                        CookingTime = mp.Recipie.CookingTime,
                        Ingredients = mp.Recipie.Ingredients,
                        Instructions = mp.Recipie.Instructions
                    }
                })
                .ToList();
                return Results.Ok(mealPlans);
            }).WithName("GetMealPlansWeek").WithTags("MealPlan"); 

           app.MapGet("/mealplan/month", async (int year, int month, RecipieDb db) =>
            {
                var (start, end) = GetMonthRange(year, month);

                var mealPlans = db.MealPlans
                .Where(mp => mp.Date >= start && mp.Date <= end)
                .OrderBy(mp => mp.Date)
                .Select(mp => new MealPlanDto
                {
                    Date = mp.Date,
                    Recipe = new RecipeDto
                    {
                        Id = mp.Recipie.Id,
                        Title = mp.Recipie.Title,
                        Description = mp.Recipie.Description,
                        PortionSize = mp.Recipie.PortionSize,
                        PreparationTime = mp.Recipie.PreparationTime,
                        CookingTime = mp.Recipie.CookingTime,
                        Ingredients = mp.Recipie.Ingredients,
                        Instructions = mp.Recipie.Instructions
                    }
                });
                return Results.Ok(mealPlans);
            }).WithName("GetMealPlansMonth").WithTags("MealPlan");

            // app.MapGet("/mealplan/{id}", async (int id, RecipieDb db) =>
            // {
            //     var mealPlan = await db.MealPlans.Include(mp => mp.Recipie).FirstOrDefaultAsync(mp => mp.Id == id);
            //     return mealPlan is not null ? Results.Ok(mealPlan) : Results.NotFound();
            // }).WithName("GetSingleMealPlan").WithTags("MealPlan");
            
            // app.MapPost("/mealplan", async (MealPlan mealPlan, RecipieDb db) =>
            // {
            //     db.MealPlans.Add(mealPlan);
            //     await db.SaveChangesAsync();

            //     return Results.Created($"/mealplan/{mealPlan.Id}", mealPlan);
            // }).WithName("CreateMealPlan").WithTags("MealPlan");

            // app.MapDelete("/mealplan/{id}", async (int id, RecipieDb db) =>
            // {
            //     if(await db.MealPlans.FindAsync(id) is MealPlan mealPlan)
            //     {
            //         db.MealPlans.Remove(mealPlan);
            //         await db.SaveChangesAsync();
            //         return Results.Ok($"MealPlan {id} deleted");
            //     }

            //     return Results.NotFound();
            // }).WithTags("MealPlan");
        }
        
    }
}