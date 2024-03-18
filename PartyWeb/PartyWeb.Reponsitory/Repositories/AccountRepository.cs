using BusinessObjects.Models;
using Reponsitories.Interface;

namespace Reponsitories.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public Task<bool> AddNewAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAccount(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccountByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
