using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IWishListRepository
    {
        WishList GetWishListById(string id);
        void AddWishList(WishList wishlist);
        void UpdateWishList(WishList wishList);
        void DeleteWishList(WishList wishList);
    }
}
