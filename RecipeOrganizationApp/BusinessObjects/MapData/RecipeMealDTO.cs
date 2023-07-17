using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.MapData
{
    public class RecipeMealDTO
    {
        public Guid MealID { get; set; }
        public Guid AccountID { get; set; }
        public Guid RecipeID { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
    }
}
