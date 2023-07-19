using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using BusinessObjects.MapData;
using Microsoft.Identity.Client;

namespace DataAccess
{
    public class WishListItemDAO
    {
        private readonly AppDBContext _context;

        public WishListItemDAO(AppDBContext context)
        {
            _context = context;
        }

        //Get Wish List Items by Wish List ID
        public List<WishListItem> GetWishListByAccountID(Guid accountID)
        {
            try
            {
                var id = _context.WishLists.Where(c => c.AccountID == accountID).FirstOrDefault();
                if (id != null)
                {
                    return _context.WishListItems.Where(x => x.WishListID == id.WishListID).ToList();
                }
                return new List<WishListItem>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //Post new WishListItem
        public bool addWishListItem(WishListItemData inf)
        {
            try
            {
                var id = _context.WishLists.Where(c => c.AccountID == inf.AccountID).FirstOrDefault();
                var wishList = _context.WishLists.SingleOrDefault(x => x.WishListID == id.WishListID);
                var recipe = _context.Recipes.SingleOrDefault(x => x.RecipeID == inf.RecipeID);

                if (wishList != null && recipe != null)
                {
                    var newItem = new WishListItem
                    {
                        WishListID = wishList.WishListID,
                        RecipeID = inf.RecipeID,
                        Recipe = recipe,
                        WishList = wishList
                    };

                    _context.WishListItems.Add(newItem);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete existing WishListItem
        public bool removeWishListItem(WishListItemData inf)
        {
            try
            {
                var id = _context.WishLists.Where(c => c.AccountID == inf.AccountID).FirstOrDefault();
                var wishList = _context.WishLists.SingleOrDefault(x => x.WishListID == id.WishListID);
                var recipe = _context.Recipes.SingleOrDefault(x => x.RecipeID == inf.RecipeID);

                if (wishList != null && recipe != null)
                {
                    var item = _context.WishListItems.Where(c => c.WishListID == wishList.WishListID && c.RecipeID == inf.RecipeID).FirstOrDefault();
                    _context.WishListItems.Remove(item);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}