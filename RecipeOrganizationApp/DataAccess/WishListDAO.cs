using BusinessObjects;
namespace DataAccess
{
    public class WishListDAO
    {
        //Get all WishLists
        public static List<WishList> GetRoles()
        {
            var listWishList = new List<WishList>();
            try
            {
                using(var context = new AppDBContext())
                {
                    listWishList = context.WishLists.ToList();
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listWishList;
        }
        //Get wish list by WishListID
        public static WishList GetWishListById(string id)
        {
            var wishList = new WishList();
            try
            {
                using(var context = new AppDBContext())
                {
                    wishList = context.WishLists.SingleOrDefault(x => x.WishListID.ToString() == id);
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return wishList;
        }
        //Post new Wish List
        public static void AddWishList(WishList wishlist)
        {
            try
            {
                using(var context = new AppDBContext()) {
                    var wishListAdd = new WishList
                    {
                        AccountID = wishlist.AccountID,
                    };
                    context.WishLists.Add(wishListAdd);
                    context.SaveChanges();
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Put existing Wish List by Wish List ID
        public static void UpdateWishList(WishList wishList)
        {
            try
            {
                using(var context = new AppDBContext())
                {
                    if(context.WishLists.SingleOrDefault(x => x.WishListID == wishList.WishListID) != null)
                    {
                        context.Entry<WishList>(wishList).State =
                           Microsoft.EntityFrameworkCore.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            }catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        //Delete existing wish list
        public static void DeleteWishList(WishList wishList)
        {
            try
            {
                using(var context = new AppDBContext()) {
                    var wishListCheck = context.WishLists.SingleOrDefault(x => x.WishListID == wishList.WishListID);
                    if (wishListCheck != null)
                    {
                        context.WishLists.Remove(wishListCheck);
                    }
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
