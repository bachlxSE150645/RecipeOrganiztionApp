using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIRAO.Controllers.DTOs.Recipe
{
    public class CreateRecipeDTO
    {
        [Required]
        public string? RecipeName { get; set; }
        [Required]
        public string? RecipeImage { get; set; }
        [Required]
        public string? Description { get; set; }
        public Guid AccountID { get; set; }

    }
}
