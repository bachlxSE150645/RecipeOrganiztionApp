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
    public class Recipe
    {
        [Key][Required] public Guid RecipeID { get; set; }
        public string? RecipeName { get; set; }
        public string? RecipeImage { get; set; }
        public string? Description { get; set; }
        [ForeignKey("Account")][Required] public Guid AccountID { get; set; }
        [Required][MaxLength(10)] public string Status { get; set; }
        [DataType(DataType.DateTime)]public DateTime? CreateDate { get; set; }
        public Account Account { get; set; }
    }
}
