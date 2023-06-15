using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class WishListItem
    {
        [ForeignKey("WishList")] public Guid WishListID { get; set; }
        [ForeignKey("Recipe")] public Guid RecipeID { get; set; }
        public WishList WishList { get; set; }
        public Recipe Recipe { get; set; }
    }
}
