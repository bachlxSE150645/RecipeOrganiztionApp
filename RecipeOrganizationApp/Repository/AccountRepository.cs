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
            _context = AccountDAO.GetInstance(dbContext);
        }

        private readonly AccountDAO _context;

        public List<Account> GetAccounts() => _context.GetAccounts();
        public Account GetAccountsById(Guid id) => _context.GetAccountsById(id);
        public Account GetAccountByEmailAndPassword(string email, string password) => _context.GetAccountByEmailAndPassword(email, password);
        public Task<Account> AddAccount(SignUpData account) => _context.AddAccount(account);
        public Account UpdateAccount(Account account) => _context.UpdateAccount(account);
        public bool DeleteAccount(Account account) => _context.DeleteAccount(account);

    }
}
