using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recipe_api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlans_Recipie_RecipieId",
                table: "MealPlans");

            migrationBuilder.AlterColumn<int>(
                name: "RecipieId",
                table: "MealPlans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OnlineRecipieId",
                table: "MealPlans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealPlans_OnlineRecipieId",
                table: "MealPlans",
                column: "OnlineRecipieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlans_OnlineRecipie_OnlineRecipieId",
                table: "MealPlans",
                column: "OnlineRecipieId",
                principalTable: "OnlineRecipie",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlans_Recipie_RecipieId",
                table: "MealPlans",
                column: "RecipieId",
                principalTable: "Recipie",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlans_OnlineRecipie_OnlineRecipieId",
                table: "MealPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_MealPlans_Recipie_RecipieId",
                table: "MealPlans");

            migrationBuilder.DropIndex(
                name: "IX_MealPlans_OnlineRecipieId",
                table: "MealPlans");

            migrationBuilder.DropColumn(
                name: "OnlineRecipieId",
                table: "MealPlans");

            migrationBuilder.AlterColumn<int>(
                name: "RecipieId",
                table: "MealPlans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlans_Recipie_RecipieId",
                table: "MealPlans",
                column: "RecipieId",
                principalTable: "Recipie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
