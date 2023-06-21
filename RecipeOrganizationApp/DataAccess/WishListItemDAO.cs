using Azure.Core;
using BusinessObjects;
using System.Collections.Generic;

namespace DataAccess
{
    public class WishListItemDAO
    {
        private static WishListItemDAO instance;
        private readonly AppDBContext _context;

        public WishListItemDAO(AppDBContext context)
        {
            this._context = context;
        }

        public static WishListItemDAO GetInstance(AppDBContext dbContext)
        {

            if (instance == null)
            {
                instance = new WishListItemDAO(dbContext);
            }

            return instance;
        }

        //Get All Wish List Items
        public List<WishListItem> GetWishListItems()
        {
            var list = new List<WishListItem>();
            try
            {
                
                    list = _context.WishListItems.ToList();
                
            } catch(Exception ex) {
                throw new Exception(ex.Message);
            }
            return list;
        }

        //Get Wish List Items by Wish List ID
        public List<WishListItem> GetWishListItemsByWishListId(string wishListId)
        {
            var listWishListItem = new List<WishListItem>();
            try
            {
                
                    listWishListItem = _context.WishListItems.Where(x=> x.WishListID.ToString() == wishListId).ToList();
                
            } catch(Exception ex) {
                throw new Exception(ex.Message);
            }
            return listWishListItem;
        }

        //Get Wish List Items by Recipe ID
        public List<WishListItem> GetWishListItemsByRecipeId(string recipeId)
        {
            var listWishListItems = new List<WishListItem>();
            try
            {
                
                    listWishListItems = _context.WishListItems.Where(x => x.RecipeID.ToString() == recipeId).ToList();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listWishListItems;
        }

        //Get Wish List Item by Recipe ID and Wish List ID
        public WishListItem GetWishListItemsByRecIdAndWSLId(string recId, string WSLId)
        {
            var wishListItem = new WishListItem();
            try
            {
                
                    wishListItem = _context.WishListItems.SingleOrDefault(x => x.RecipeID.ToString() == recId && x.WishListID.ToString() == WSLId);
                
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return wishListItem;
        }

        //Post new WishListItem
        public void AddWishListItem(WishListItem wishListItem)
        {
            try
            {
                
                    var wishList = _context.WishLists.SingleOrDefault(x=>x.WishListID == wishListItem.WishListID);
                    var recipe = _context.Recipes.SingleOrDefault(x=>x.RecipeID== wishListItem.RecipeID);
                    if(wishList != null && recipe != null) {
                        _context.WishListItems.Add(wishListItem);
                        _context.SaveChanges();
                    }
                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete existing WishListItem
        public void DeleteWishListItem(WishListItem wishListItem)
        {
            try
            {
                
                    var wishListItemCheck = _context.WishListItems.SingleOrDefault(x => x.RecipeID.Equals(wishListItem.RecipeID) && x.WishListID.Equals(wishListItem.WishListID));
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
