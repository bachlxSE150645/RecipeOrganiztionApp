using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    [Keyless]
    public class RecipeDetail
    {
        [ForeignKey("Recipe")]
        [Required] public Guid RecipeID { get;set; }
        [ForeignKey("Ingredient")]
        [Required] public Guid IngredientID { get; set; }
        public int? Quantity { get; set; }
        [MaxLength(20)] public string? Unit { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
