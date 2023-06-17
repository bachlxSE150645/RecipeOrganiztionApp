using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IWishListItemRepository
    {
        List<WishListItem> GetWishListItems();
        List<WishListItem> GetWishListItemsByWishListId(string wishListId);
        List<WishListItem> GetWishListItemsByRecipeId(string recipeId);
        WishListItem GetWishListItemsByRecIdAndWSLId(string recId, string WSLId);
        void AddWishListItem(WishListItem wishListItem);
        void DeleteWishListItem(WishListItem wishListItem);

    }
}
