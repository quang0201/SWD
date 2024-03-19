using BusinessObjects.Models;

namespace Reponsitories.Interface
{
    public interface IAccountRepository
    {
        Task<bool> IsExistAccountEmail(string email);
        Task<bool> IsExistAccountUsername(string username);
        Task<Account> GetAccountById(int id);
        Task<List<Account>> GetAccounts();
        Task<bool> AddNewAccount(Account account);
        Task<bool> DeleteAccount(int id);
        Task<bool> UpdateAccount(Account account);
    }
}
