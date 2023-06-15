using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class RecipeDetail
    {
        [ForeignKey("Recipe")][Required] public Guid RecipeID { get;set; }
        [ForeignKey("Ingredient")][Required] public Guid IngredientID { get; set; }
        [Required] public int Quantity { get; set; }
        [Required][MaxLength(20)] public string Unit { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
