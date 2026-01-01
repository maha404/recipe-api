using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recipe_api.Migrations
{
    /// <inheritdoc />
    public partial class MealPlan2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "MealPlans");

            migrationBuilder.AddColumn<string>(
                name: "Week",
                table: "MealPlans",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Week",
                table: "MealPlans");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "MealPlans",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
