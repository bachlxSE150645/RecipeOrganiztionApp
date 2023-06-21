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
        public WishListRepository(AppDBContext dbContext)
        {
            _context = WishListDAO.GetInstance(dbContext);
        }

        private readonly WishListDAO _context;

        public List<WishList> GetRoles() => _context.GetRoles();
        public WishList GetWishListById(string id) => _context.GetWishListById(id);
        public void AddWishList(WishList wishlist) => _context.AddWishList(wishlist);
        public void UpdateWishList(WishList wishList) => _context.UpdateWishList(wishList);
        public void DeleteWishList(WishList wishList) => _context.DeleteWishList(wishList);
    }
}
