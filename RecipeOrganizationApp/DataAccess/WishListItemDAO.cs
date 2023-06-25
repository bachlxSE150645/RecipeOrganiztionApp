using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using BusinessObjects.MapData;

namespace DataAccess
{
    public class WishListItemDAO
    {
        private readonly AppDBContext _context;

        public WishListItemDAO(AppDBContext context)
        {
            _context = context;
        }

        //Get All Wish List Items
        public List<WishListItem> GetWishListItems()
        {
            try
            {
                return _context.WishListItems.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get Wish List Items by Wish List ID
        public List<WishListItem> GetWishListItemsByWishListId(string wishListId)
        {
            try
            {
                return _context.WishListItems.Where(x => x.WishListID == Guid.Parse(wishListId)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get Wish List Items by Recipe ID
        public List<WishListItem> GetWishListItemsByRecipeId(string recipeId)
        {
            try
            {
                return _context.WishListItems.Where(x => x.RecipeID == Guid.Parse(recipeId)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get Wish List Item by Recipe ID and Wish List ID
        public WishListItem GetWishListItemsByRecIdAndWSLId(string recId, string WSLId)
        {
            try
            {
                return _context.WishListItems.SingleOrDefault(x => x.RecipeID == Guid.Parse(recId) && x.WishListID == Guid.Parse(WSLId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Post new WishListItem
        public void AddWishListItem(WishListItem wishListItem)
        {
            try
            {
                var wishList = _context.WishLists.SingleOrDefault(x => x.WishListID == wishListItem.WishListID);
                var recipe = _context.Recipes.SingleOrDefault(x => x.RecipeID == wishListItem.RecipeID);
                if (wishList != null && recipe != null)
                {
                    _context.WishListItems.Add(wishListItem);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete existing WishListItem
        public void DeleteWishListItem(WishListItem wishListItem)
        {
            try
            {
                var wishListItemCheck = _context.WishListItems.SingleOrDefault(x => x.RecipeID == wishListItem.RecipeID && x.WishListID == wishListItem.WishListID);
                if (wishListItemCheck != null)
                {
                    _context.WishListItems.Remove(wishListItemCheck);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}