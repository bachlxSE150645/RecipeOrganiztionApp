using BusinessObjects;
using BusinessObjects.MapData;
using DataAccess;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class WishListItemRepository : IWishListItemRepository
    {
        public WishListItemRepository(AppDBContext dbContext)
        {
            dao = new WishListItemDAO(dbContext);
        }

        private readonly WishListItemDAO dao;

        public bool addWishListItem(WishListItemData inf) => dao.addWishListItem(inf);
        public bool removeWishListItem(WishListItemData inf) => dao.removeWishListItem(inf);
        public List<WishListItem> GetWishListByAccountID(Guid accountID) => dao.GetWishListByAccountID(accountID);

    }
}
