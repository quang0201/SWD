using BusinessObjects.Models;
using BusinessObjects.RequestModels;
using BusinessObjects.ResponseModels;
using DataAcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.AccountRepository
{
    public class AccountRepository : IAccountRepository
    {
        public Task<List<Account>> GetAllAccounts() => AccountDAO.Instance.GetAllAccounts();
        public Task<Account> Login(LoginRequest request) => AccountDAO.Instance.Login(request);
        public Task<Account> GetAccount(string username, string password) => AccountDAO.Instance.GetAccount(username, password);
        public Task<int> CreateAccount (Account account) => AccountDAO.Instance.CreateAccount(account);
    }
}
