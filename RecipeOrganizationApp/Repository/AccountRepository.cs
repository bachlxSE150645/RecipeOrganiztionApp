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
    public class AccountRepository : IAccountRepository
    {
        public AccountRepository(AppDBContext dbContext)
        {
            dao = new AccountDAO(dbContext);
        }

        private readonly AccountDAO dao;

        public Task<List<Account>> GetAccounts(string searchString, int? pageIndex) => dao.GetAccounts(searchString,pageIndex);
        public Account GetAccountsById(Guid id) => dao.GetAccountsById(id);
        public Account GetAccountByEmailAndPassword(string email, string password) => dao.GetAccountByEmailAndPassword(email, password);
        public Task<Account> AddAccount(SignUpData account) => dao.AddAccount(account);
        public Account UpdateAccount(Account account) => dao.UpdateAccount(account);
        public bool DeleteAccount(Account account) => dao.DeleteAccount(account);
        public IEnumerable<Account> SearchAccountByUser(string UserName) => dao.SearchAccountByUserName(UserName);

    }
}
