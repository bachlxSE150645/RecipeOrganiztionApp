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
    public class Meal
    {
        [Key][Required] public Guid MealID { get; set; }
        [ForeignKey("Account")][Required] public Guid AccountID { get; set; }
        [ForeignKey("Recipe")][Required] public Guid RecipeID { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        [Required][MaxLength(10)] public string Status { get; set; }
        public virtual Account Account { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual Recipe Recipe { get; set; } = null!;

    }
}
