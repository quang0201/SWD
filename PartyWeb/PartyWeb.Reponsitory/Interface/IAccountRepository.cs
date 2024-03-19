using BusinessObjects.Models;

namespace Reponsitories.Interface
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountByEmail(string email);
        Task<bool> AddNewAccount(Account account);
        Task<bool> DeleteAccount(string email);
        Task<bool> UpdateAccount(Account account);
    }
}
