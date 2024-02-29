using BusinessObjects.Models;
using ModelViews;

namespace Server.Interface
{
    public interface IUser
    {
        Task<bool> Register(Account account);
        Task<Account> Login(LoginModel account);
        Task<List<Account>> GetAll();

    }
}
