using ModelViews.ModelView.Accounts;

namespace Services.Interface
{
    public  interface IAccountService
    {
        Task<ViewAccountModel> GetAccountById(int id);
        Task<List<ViewAccountModel>> GetAccounts();
        Task<bool> IsExistAccountEmail(string email);
        Task<bool> IsExistAccountUsername(string username);
        Task<bool> AddNewAccount(AddNewAccountModel account);
        Task<bool> DeleteAccount(int id);
        Task<bool> UpdateAccount(UpdateAccountModel account);

    }
}
