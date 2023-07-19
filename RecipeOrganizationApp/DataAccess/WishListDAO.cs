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

        //Post new Wish List
        public void newWishList(Guid accID)
        {
            try
            {
                var newWL = new WishList
                {

                    WishListID = Guid.NewGuid(),
                    AccountID = accID,
                    Account = _context.Accounts.Where(c => c.AccountID == accID).FirstOrDefault(),
                };
                _context.WishLists.Add(newWL);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}