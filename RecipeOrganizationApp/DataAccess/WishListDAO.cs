using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using BusinessObjects.MapData;

namespace DataAccess
{
    public class WishListDAO
    {
        private readonly AppDBContext _context;

        public WishListDAO(AppDBContext context)
        {
            _context = context;
        }

        //Get all WishLists
        public List<WishList> GetWishLists()
        {
            try
            {
                return _context.WishLists.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get wish list by WishListID
        public WishList GetWishListById(string id)
        {
            try
            {
                return _context.WishLists.SingleOrDefault(x => x.WishListID == Guid.Parse(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Post new Wish List
        public void AddWishList(WishList wishlist)
        {
            try
            {
                _context.WishLists.Add(wishlist);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Put existing Wish List by Wish List ID
        public void UpdateWishList(WishList wishList)
        {
            try
            {
                var wishListCheck = _context.WishLists.SingleOrDefault(x => x.WishListID == wishList.WishListID);
                if (wishListCheck != null)
                {
                    _context.Entry(wishListCheck).CurrentValues.SetValues(wishList);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
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