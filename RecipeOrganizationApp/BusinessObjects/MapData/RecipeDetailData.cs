using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.MapData
{
    public class RecipeDetailData
    {
        public Guid RecipeID { get; set; }
        public Guid IngredientID { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
    }
}
