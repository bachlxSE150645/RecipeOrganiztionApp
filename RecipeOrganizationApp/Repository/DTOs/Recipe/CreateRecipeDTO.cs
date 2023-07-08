using System.ComponentModel.DataAnnotations;

namespace Repository.DTOs.Recipe { 

    public class CreateRecipeDTO
    {
        [Required]
        public string? RecipeName { get; set; }
        [Required]
        public string? RecipeImage { get; set; }
        [Required]
        public string? Description { get; set; }
        public Guid AccountID { get; set; }
        public RecipeIngredientDTO[] Ingredients { get; set; }


    }

    public class RecipeIngredientDTO
    {
        [Required]
        public string IngredientId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Unit { get; set;}

    }
}
