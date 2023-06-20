using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.MapData
{
    public class RecipeData
    {
        public string RecipeName { get; set; }
        public string RecipeImage { get; set; }
        public string Description { get; set; }
        public Guid AccountID { get; set; }
    }
}
