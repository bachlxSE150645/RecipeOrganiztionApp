using BusinessObjects;
using DataAccess;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class WishListItemRepository : IWishListItemRepository
    {
        public List<WishListItem> GetWishListItems() => WishListItemDAO.GetWishListItems();
        public List<WishListItem> GetWishListItemsByWishListId(string wishListId) => WishListItemDAO.GetWishListItemsByWishListId(wishListId);
        public List<WishListItem> GetWishListItemsByRecipeId(string recipeId) => WishListItemDAO.GetWishListItemsByRecipeId(recipeId);
        public WishListItem GetWishListItemsByRecIdAndWSLId(string recId, string WSLId) => WishListItemDAO.GetWishListItemsByRecIdAndWSLId(recId, WSLId);
        public void AddWishListItem(WishListItem wishListItem) => WishListItemDAO.AddWishListItem(wishListItem);
        public void DeleteWishListItem(WishListItem wishListItem) => WishListItemDAO.DeleteWishListItem(wishListItem);
    }
}
