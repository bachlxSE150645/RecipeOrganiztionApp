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
        public List<Account> GetAccounts() => AccountDAO.GetAccounts();
        public Account GetAccountsById(string id) => AccountDAO.GetAccountsById(id);
        public Account GetAccountByEmailAndPassword(string email, string password) => AccountDAO.GetAccountByEmailAndPassword(email, password);
        public void AddAccount(Account account) => AccountDAO.AddAccount(account);
        public void UpdateAccount(Account account) => AccountDAO.UpdateAccount(account);
        public void DeleteAccount(Account account) => AccountDAO.DeleteAccount(account);
    }
}
