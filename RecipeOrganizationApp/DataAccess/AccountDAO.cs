using APIRAO.Lib;
using AutoMapper;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DataAccess
{
    public class AccountDAO
    {
        private readonly AppDBContext _context;

        private PaginatedList<AccountDAO> items;
        
        private readonly int pageSize = 10;
        public AccountDAO(AppDBContext context)
        {

            this._context = context;

        }

        //Get All Accounts
        public async Task<List<Account>> GetAccounts(string searchString)
        {
            List<Account> accountIQ = _context.Accounts.Include(a => a.Role).ToList();
            if (!String.IsNullOrEmpty(searchString)) {
                accountIQ =  accountIQ.Where(a => a.UserName.Contains(searchString) || a.Email.Contains(searchString)).ToList();
            }

            return accountIQ;
        }

        //Get Account matches ID
        public Account GetAccountsById(Guid id)
        {
            try
            {
                return _context.Accounts.SingleOrDefault(x => x.AccountID == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Account> SearchAccountByUserName(string userName)
        {
            try
            {
                var accountUser = from x in _context.Accounts
                                  where x.UserName.Contains(userName)
                                  select x;
                return accountUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get Account by username and password
        public Account GetAccountByEmailAndPassword(string email, string password)
        {
            try
            {
                return _context.Accounts.Include(a => a.Role).FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Post new account
        public async Task<Account> AddAccount(SignUpData account)
        {
            try
            {
                var newAcc = new Account
                {
                    Email = account.Email,
                    Password = account.Password,
                    Phone = account.Phone,
                    UserName = account.UserName,
                    AccountID = Guid.NewGuid(),
                    Status = true,
                    Role = await _context.Roles!.FirstOrDefaultAsync(c => c.RoleName == "US")
                };

                _context.Accounts!.Add(newAcc);
                await _context.SaveChangesAsync();
                return newAcc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Put existing account
        public Account UpdateAccount(Account account)
        {
            try
            {
                var acc = _context.Accounts.SingleOrDefault(x => x.AccountID == account.AccountID);
                if (acc != null)
                {
                    _context.Entry<Account>(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    return acc;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete existing account
        public bool DeleteAccount(Account account)
        {
            try
            {
                var acc = _context.Accounts.SingleOrDefault(x => x.AccountID.Equals(account.AccountID));
                if (acc != null)
                {
                    acc.Status = false;
                    _context.Accounts.Update(acc);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}