using BusinessObjects.Models;
using BusinessObjects.RequestModels;
using BusinessObjects.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.AccountRepository
{
    public interface IAccountRepository
    {
        public Task<List<Account>> GetAllAccounts();
        public Task<Account> Login(LoginRequest request);
        public Task<Account> GetAccount(string username, string password);
        public Task<int> CreateAccount(Account account);
    }
}
