using AutoMapper;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AccountDAO
    {
        private readonly AppDBContext _context;

        public AccountDAO(AppDBContext context)
        {
            this._context = context;
        }

        //Get All Accounts
        public List<Account> GetAccounts()
        {
            try
            {
                return _context.Accounts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        //Get Account by username and password
        public Account GetAccountByEmailAndPassword(string email, string password)
        {
            try
            {
                return _context.Accounts.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));
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
                    _context.Accounts.Remove(acc);
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