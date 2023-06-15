using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Ingredient
    {
        [Key][Required] public Guid IngredientID { get; set; }
        [Required] public string IngredientName { get; set; }
        [Required] public bool Status { get; set; }

    }
}
