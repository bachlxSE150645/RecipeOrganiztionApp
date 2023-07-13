using BusinessObjects.MapData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Recipe
    {
        [Key][Required] public Guid RecipeID { get; set; }
        public string? RecipeName { get; set; }
        public string? RecipeImage { get; set; }
        public string? Description { get; set; }
        [ForeignKey("Account")][Required] public Guid AccountID { get; set; }
        [Required][MaxLength(10)] public string Status { get; set; }
        [DataType(DataType.DateTime)]public DateTime? CreateDate { get; set; }
        public virtual Account Account { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Meal> Meals { get; set; } = new List<Meal>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        [NotMapped]
        public virtual ICollection<RecipeDetail> RecipeDetails { get; set; } = new List<RecipeDetail>();
        [NotMapped]
        public virtual RecipeMealDTO Meal { get; set; }
    }
}
