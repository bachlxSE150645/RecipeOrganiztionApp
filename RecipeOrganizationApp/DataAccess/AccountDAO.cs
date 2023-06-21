using AutoMapper;
using BusinessObjects;

namespace DataAccess
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        private readonly AppDBContext _context;
        //private readonly IMapper _mapper;

        public AccountDAO(AppDBContext context)
        {
            this._context = context;
        }

        public static AccountDAO GetInstance(AppDBContext dbContext)
        {

            if (instance == null)
            {
                instance = new AccountDAO(dbContext);
            }

            return instance;
        }

        //Get All Accounts
        public List<Account> GetAccounts()
        {
            var listAccounts = new List<Account>();
            try
            {
                listAccounts = _context.Accounts.ToList();
                
            } catch(Exception ex)
            {
                throw new Exception();
            }
            return listAccounts;
        }
        //Get Account matches ID
        public Account GetAccountsById(Guid id)
        {
            var Account = new Account();
            try
            {
                
                    Account = _context.Accounts.Where(x => x.AccountID == id ).SingleOrDefault();
                
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return Account;
        }
        //Get Account by username and password
        public  Account GetAccountByEmailAndPassword(string email, string password)
        {
            var account = new Account();
            try
            {
                
                    account = _context.Accounts.Where(x => x.Email.Equals(email) && x.Password.Equals(password)).FirstOrDefault();
                
            } catch (Exception ex)
            {
                throw new Exception();
            }
            return account;
        }
        //Post new account
        public async Task<Account> AddAccount(SignUpData account)
        {
            try
            {
                var newAcc = new Account();

                newAcc.Email = account.Email;
                newAcc.Password = account.Password;
                newAcc.Phone = account.Phone;
                newAcc.UserName = account.UserName;
                newAcc.AccountID = Guid.NewGuid();
                newAcc.Status = true;
                newAcc.Role = _context.Roles!.Where(c => c.RoleName == "US").FirstOrDefault();

                _context.Accounts!.Add(newAcc);
                await _context.SaveChangesAsync();
                return newAcc;

            } catch(Exception ex)
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
                        _context.Entry<Account>(account).State =
                            Microsoft.EntityFrameworkCore.EntityState.Modified;
                        _context.SaveChanges();
                    return acc;
                    }
                return null;
            } catch(Exception ex)
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
                    if(acc != null)
                    {
                        _context.Accounts.Remove(acc);
                        _context.SaveChanges();
                    return true;
                    }
                return false;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}