using BusinessObjects;
namespace DataAccess
{
    public class WishListDAO
    {
        private static WishListDAO instance;
        private readonly AppDBContext _context;

        public WishListDAO(AppDBContext context)
        {
            this._context = context;
        }

        public static WishListDAO GetInstance(AppDBContext dbContext)
        {

            if (instance == null)
            {
                instance = new WishListDAO(dbContext);
            }

            return instance;
        }
        //Get all WishLists
        public List<WishList> GetRoles()
        {
            var listWishList = new List<WishList>();
            try
            {
                
                    listWishList = _context.WishLists.ToList();
                
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listWishList;
        }
        //Get wish list by WishListID
        public WishList GetWishListById(string id)
        {
            var wishList = new WishList();
            try
            {
                
                    wishList = _context.WishLists.SingleOrDefault(x => x.WishListID.ToString() == id);
                
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return wishList;
        }
        //Post new Wish List
        public void AddWishList(WishList wishlist)
        {
            try
            {
                
                    var wishListAdd = new WishList
                    {
                        AccountID = wishlist.AccountID,
                    };
                    _context.WishLists.Add(wishListAdd);
                    _context.SaveChanges();
                
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Put existing Wish List by Wish List ID
        public void UpdateWishList(WishList wishList)
        {
            try
            {
                
                    if(_context.WishLists.SingleOrDefault(x => x.WishListID == wishList.WishListID) != null)
                    {
                        _context.Entry<WishList>(wishList).State =
                           Microsoft.EntityFrameworkCore.EntityState.Modified;
                        _context.SaveChanges();
                    }
                
            }catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        //Delete existing wish list
        public void DeleteWishList(WishList wishList)
        {
            try
            {
                
                    var wishListCheck = _context.WishLists.SingleOrDefault(x => x.WishListID == wishList.WishListID);
                    if (wishListCheck != null)
                    {
                        _context.WishLists.Remove(wishListCheck);
                    }
                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
