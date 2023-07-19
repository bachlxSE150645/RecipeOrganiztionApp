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
            _context = new WishListDAO(dbContext);
        }

        private readonly WishListDAO _context;

        public void newWishList(Guid accID) => _context.newWishList(accID);
    }
}
