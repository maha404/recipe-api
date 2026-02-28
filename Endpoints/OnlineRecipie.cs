using Microsoft.EntityFrameworkCore;
using System.Globalization;
using recipe_api.DTO;

namespace recipe_api.Endpoints
{
    public static class OnlineRecipieEndpoints
    {

        public static void MapOnlineRecipieEndpoints(this WebApplication app)
        {
            app.MapGet("/onlineRecipie", async (RecipieDb db) =>
            {
                var onlineRecipie = await db.OnlineRecipie.ToListAsync();
                return Results.Ok(onlineRecipie);
            }).WithName("GetOnlineRecipie").WithTags("OnlineRecipie");


            app.MapPost("/onlineRecipie", async (OnlineRecipieDto onlineRecipieDTO, RecipieDb db) =>
            {
                var onlineRecipie = new OnlineRecipie
                {
                    Title = onlineRecipieDTO.Title,
                    Url = onlineRecipieDTO.Url,
                };

                db.OnlineRecipie.Add(onlineRecipie);
                await db.SaveChangesAsync();

                return Results.Created($"/onlineRecipie/{onlineRecipie.Id}", onlineRecipie);
            }).WithName("CreateOnlineRecipie").WithTags("OnlineRecipie");
        }
    }
}