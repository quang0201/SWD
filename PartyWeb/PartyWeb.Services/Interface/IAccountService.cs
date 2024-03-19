using BusinessObjects.Models;
using ModelViews.ModelView;

namespace Services.Interface
{
    public  interface IAccountService
    {
        Task<AccountModel> GetAccountByEmail(string email);
        Task<bool> AddNewAccount(AccountModel account);
        Task<bool> DeleteAccount(string email);
        Task<bool> UpdateAccount(AccountModel account);

    }
}
