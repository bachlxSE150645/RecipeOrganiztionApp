using System.ComponentModel.DataAnnotations;

namespace Repository.DTOs.Recipe
{
    public class UpdateRecipeDTO
    {
        public string? RecipeName { get; set; }
        public string? RecipeImage { get; set; }
        public string? Description { get; set; }
        public RecipeIngredientDTO[] Ingredients { get; set; }
    }
}
