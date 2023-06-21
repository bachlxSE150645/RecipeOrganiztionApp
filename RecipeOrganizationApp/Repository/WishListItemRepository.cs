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
            _context = WishListItemDAO.GetInstance(dbContext);
        }

        private readonly WishListItemDAO _context;

        public List<WishListItem> GetWishListItems() => _context.GetWishListItems();
        public List<WishListItem> GetWishListItemsByWishListId(string wishListId) => _context.GetWishListItemsByWishListId(wishListId);
        public List<WishListItem> GetWishListItemsByRecipeId(string recipeId) => _context.GetWishListItemsByRecipeId(recipeId);
        public WishListItem GetWishListItemsByRecIdAndWSLId(string recId, string WSLId) => _context.GetWishListItemsByRecIdAndWSLId(recId, WSLId);
        public void AddWishListItem(WishListItem wishListItem) => _context.AddWishListItem(wishListItem);
        public void DeleteWishListItem(WishListItem wishListItem) => _context.DeleteWishListItem(wishListItem);
    }
}
