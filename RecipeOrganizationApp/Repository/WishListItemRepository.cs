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
        public WishListItemRepository(AppDBContext dbContext)
        {
            dao = new WishListItemDAO(dbContext);
        }

        private readonly WishListItemDAO dao;

        public List<WishListItem> GetWishListItems() => dao.GetWishListItems();
        public List<WishListItem> GetWishListItemsByWishListId(string wishListId) => dao.GetWishListItemsByWishListId(wishListId);
        public List<WishListItem> GetWishListItemsByRecipeId(string recipeId) => dao.GetWishListItemsByRecipeId(recipeId);
        public WishListItem GetWishListItemsByRecIdAndWSLId(string recId, string WSLId) => dao.GetWishListItemsByRecIdAndWSLId(recId, WSLId);
        public void AddWishListItem(WishListItem wishListItem) => dao.AddWishListItem(wishListItem);
        public void DeleteWishListItem(WishListItem wishListItem) => dao.DeleteWishListItem(wishListItem);
    }
}
