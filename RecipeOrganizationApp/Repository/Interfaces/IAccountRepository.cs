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
        Account GetAccountsById(Guid id);
        Account GetAccountByEmailAndPassword(string email, string password);
        Task<Account> AddAccount(SignUpData account);
        Account UpdateAccount(Account account);
        bool DeleteAccount(Account account);
    }
}
