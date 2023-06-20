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
        public static List<Account> GetAccounts()
        {
            var listAccounts = new List<Account>();
            try
            {
                using(var context = new AppDBContext())
                {
                    listAccounts = context.Accounts.ToList();
                }
            } catch(Exception ex)
            {
                throw new Exception();
            }
            return listAccounts;
        }
        //Get Account matches ID
        public static Account GetAccountsById(string id)
        {
            var Account = new Account();
            try
            {
                using (var context = new AppDBContext())
                {
                    Account = context.Accounts.Where(x => x.AccountID.Equals(id)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return Account;
        }
        //Get Account by username and password
        public static Account GetAccountByEmailAndPassword(string email, string password)
        {
            var account = new Account();
            try
            {
                using(var context = new AppDBContext())
                {
                    account = context.Accounts.Where(x => x.Email.Equals(email) && x.Password.Equals(password)).FirstOrDefault();
                }
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
        public static void UpdateAccount(Account account)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var acc = context.Accounts.SingleOrDefault(x => x.AccountID == account.AccountID);
                    if (acc != null)
                    {
                        context.Entry<Account>(account).State =
                            Microsoft.EntityFrameworkCore.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Delete existing account
        public static void DeleteAccount(Account account)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var acc = context.Accounts.SingleOrDefault(x => x.AccountID.Equals(account.AccountID));
                    if(acc != null)
                    {
                        context.Accounts.Remove(acc);
                        context.SaveChanges();
                    }
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}