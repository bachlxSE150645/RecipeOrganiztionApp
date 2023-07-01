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
        Task<List<Account>> GetAccounts(string searchString, int? pageIndex);
        Account GetAccountsById(Guid id);
        Account GetAccountByEmailAndPassword(string email, string password);
        Task<Account> AddAccount(SignUpData account);
        Account UpdateAccount(Account account);
        bool DeleteAccount(Account account);
        IEnumerable<Account> SearchAccountByUser(string UserName);
    }
}
