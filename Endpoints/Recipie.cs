using Microsoft.EntityFrameworkCore;

namespace recipe_api.Endpoints
{
    public static class RecipieEndpoints
    {
        public static void MapRecipieEndpoints(this WebApplication app)
        {
            app.MapGet("/recipie", async (RecipieDb db) =>
            {
                var recipie = await db.Recipie.ToListAsync();
                return Results.Ok(recipie);
            }).WithName("GetRecipie").WithTags("Recipie");

            app.MapGet("/recipie/{id}", async (int id, RecipieDb db) =>
            {
                var recipie = await db.Recipie.FindAsync(id);
                return Results.Ok(recipie);
            }).WithName("GetSingleRecipie").WithTags("Recipie");
            
            app.MapPost("/recipie", async (Recipie recipie, RecipieDb db) =>
            {
                db.Recipie.Add(recipie);
                await db.SaveChangesAsync();

                return Results.Created($"/todoitems/{recipie.Id}", recipie);
            }).WithName("CreateRecipie").WithTags("Recipie");

            app.MapDelete("/recipie/{id}", async (int id, RecipieDb db) =>
            {
                if(await db.Recipie.FindAsync(id) is Recipie recipie)
                {
                    db.Recipie.Remove(recipie);
                    await db.SaveChangesAsync();
                    return Results.Ok($"Recipie {id} deleted");
                }

                return Results.NotFound();
            }).WithTags("Recipie");
        }
        
    } 
    
}