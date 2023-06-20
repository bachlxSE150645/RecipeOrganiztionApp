using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IAccountRepository
    {
        List<Account> GetAccounts();
        Account GetAccountsById(string id);
        Account GetAccountByEmailAndPassword(string email, string password);
        Task<Account> AddAccount(SignUpData account);
        void UpdateAccount(Account account);
        void DeleteAccount(Account account);
    }
}
