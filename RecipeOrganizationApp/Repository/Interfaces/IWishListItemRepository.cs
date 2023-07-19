using BusinessObjects;
using BusinessObjects.MapData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IWishListItemRepository
    {
        bool addWishListItem(WishListItemData inf);
        bool removeWishListItem(WishListItemData inf);

        List<WishListItem> GetWishListByAccountID(Guid accountID);
    }
}
