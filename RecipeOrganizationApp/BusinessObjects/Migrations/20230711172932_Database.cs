using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Recipes_RecipeID",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Meals_MealID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Recipes_RecipeID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_WishListItems_WishLists_WishListID",
                table: "WishListItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeDetails",
                table: "RecipeDetails",
                columns: new[] { "RecipeID", "IngredientID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Recipes_RecipeID",
                table: "Meals",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Meals_MealID",
                table: "Orders",
                column: "MealID",
                principalTable: "Meals",
                principalColumn: "MealID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Recipes_RecipeID",
                table: "Reviews",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_WishListItems_WishLists_WishListID",
                table: "WishListItems",
                column: "WishListID",
                principalTable: "WishLists",
                principalColumn: "WishListID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Recipes_RecipeID",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Meals_MealID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Recipes_RecipeID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_WishListItems_WishLists_WishListID",
                table: "WishListItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeDetails",
                table: "RecipeDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Recipes_RecipeID",
                table: "Meals",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "RecipeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Meals_MealID",
                table: "Orders",
                column: "MealID",
                principalTable: "Meals",
                principalColumn: "MealID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Recipes_RecipeID",
                table: "Reviews",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "RecipeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishListItems_WishLists_WishListID",
                table: "WishListItems",
                column: "WishListID",
                principalTable: "WishLists",
                principalColumn: "WishListID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
