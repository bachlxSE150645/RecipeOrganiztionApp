using Azure.Core;
using BusinessObjects;
using System.Collections.Generic;

namespace DataAccess
{
    public class WishListItemDAO
    {
        //Get All Wish List Items
        public static List<WishListItem> GetWishListItems()
        {
            var list = new List<WishListItem>();
            try
            {
                using (var context = new AppDBContext())
                {
                    list = context.WishListItems.ToList();
                }
            } catch(Exception ex) {
                throw new Exception(ex.Message);
            }
            return list;
        }

        //Get Wish List Items by Wish List ID
        public static List<WishListItem> GetWishListItemsByWishListId(string wishListId)
        {
            var listWishListItem = new List<WishListItem>();
            try
            {
                using(var context = new AppDBContext())
                {
                    listWishListItem = context.WishListItems.Where(x=> x.WishListID.ToString() == wishListId).ToList();
                }
            } catch(Exception ex) {
                throw new Exception(ex.Message);
            }
            return listWishListItem;
        }

        //Get Wish List Items by Recipe ID
        public static List<WishListItem> GetWishListItemsByRecipeId(string recipeId)
        {
            var listWishListItems = new List<WishListItem>();
            try
            {
                using (var context = new AppDBContext())
                {
                    listWishListItems = context.WishListItems.Where(x => x.RecipeID.ToString() == recipeId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listWishListItems;
        }

        //Get Wish List Item by Recipe ID and Wish List ID
        public static WishListItem GetWishListItemsByRecIdAndWSLId(string recId, string WSLId)
        {
            var wishListItem = new WishListItem();
            try
            {
                using(var context = new AppDBContext())
                {
                    wishListItem = context.WishListItems.SingleOrDefault(x => x.RecipeID.ToString() == recId && x.WishListID.ToString() == WSLId);
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return wishListItem;
        }

        //Post new WishListItem
        public static void AddWishListItem(WishListItem wishListItem)
        {
            try
            {
                using(var context = new AppDBContext())
                {
                    var wishList = context.WishLists.SingleOrDefault(x=>x.WishListID == wishListItem.WishListID);
                    var recipe = context.Recipes.SingleOrDefault(x=>x.RecipeID== wishListItem.RecipeID);
                    if(wishList != null && recipe != null) {
                        context.WishListItems.Add(wishListItem);
                        context.SaveChanges();
                    }
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete existing WishListItem
        public static void DeleteWishListItem(WishListItem wishListItem)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var wishListItemCheck = context.WishListItems.SingleOrDefault(x => x.RecipeID.Equals(wishListItem.RecipeID) && x.WishListID.Equals(wishListItem.WishListID));
                    if (wishListItemCheck != null)
                    {
                        context.WishListItems.Remove(wishListItemCheck);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
