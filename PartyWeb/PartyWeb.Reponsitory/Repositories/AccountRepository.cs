using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using Reponsitories.Interface;

namespace Reponsitories.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public Task<bool> AddNewAccount(Account account) => AccountDAO.Instance.AddAccount(account);

        public Task<bool> DeleteAccount(string email) => AccountDAO.Instance.DeleteAccount(email);

        public Task<Account> GetAccountByEmail(string email) => AccountDAO.Instance.GetAccountByEmail(email);

        public Task<bool> UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
