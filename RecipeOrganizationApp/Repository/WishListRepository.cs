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
    public class WishListRepository : IWishListRepository
    {
        public List<WishList> GetRoles() => WishListDAO.GetRoles();
        public WishList GetWishListById(string id) => WishListDAO.GetWishListById(id);
        public void AddWishList(WishList wishlist) => WishListDAO.AddWishList(wishlist);
        public void UpdateWishList(WishList wishList) => WishListDAO.UpdateWishList(wishList);
        public void DeleteWishList(WishList wishList) => WishListDAO.DeleteWishList(wishList);
    }
}
