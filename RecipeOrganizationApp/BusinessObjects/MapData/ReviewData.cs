using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.MapData
{
    public class ReviewData
    {
        public Guid AccountID { get; set; }
        public Guid RecipeID { get; set; }
        public string? ReviewContent { get; set; }
        public float? Rating { get; set; }
    }
}
