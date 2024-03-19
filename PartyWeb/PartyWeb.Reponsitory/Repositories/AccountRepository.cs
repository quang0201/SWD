using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using Reponsitories.Interface;

namespace Reponsitories.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public async Task<bool> AddNewAccount(Account account) => await AccountDAO.Instance.AddAccount(account);
        public async Task<bool> DeleteAccount(string email) => await AccountDAO.Instance.DeleteAccount(email);
        public async Task<Account> GetAccountByEmail(string email)  => await AccountDAO.Instance.GetAccountByEmail(email);
        public async Task<bool> UpdateAccount(Account account) => await AccountDAO.Instance.UpdateAccount(account);
    }
}
