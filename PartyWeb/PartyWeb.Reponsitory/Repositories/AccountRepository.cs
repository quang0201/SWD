using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using Reponsitories.Interface;

namespace Reponsitories.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public async Task<bool> AddNewAccount(Account account) => await AccountDAO.Instance.AddAccount(account);
        public async Task<bool> DeleteAccount(int id) => await AccountDAO.Instance.DeleteAccount(id);
        public async Task<Account> GetAccountById(int id)  => await AccountDAO.Instance.GetAccountById(id);
        public async Task<List<Account>> GetAccounts() => await AccountDAO.Instance.GetAccounts();
        public async Task<bool> IsExistAccountEmail(string email) => await AccountDAO.Instance.IsExistedEmail(email);
        public async Task<bool> IsExistAccountUsername(string username) => await AccountDAO.Instance.IsExistedUsername(username);
        public async Task<bool> UpdateAccount(Account account) => await AccountDAO.Instance.UpdateAccount(account);
    }
}
