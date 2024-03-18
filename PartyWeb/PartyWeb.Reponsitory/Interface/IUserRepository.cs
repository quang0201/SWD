using BusinessObjects.Models;
using ModelViews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitories.Interface
{
    public interface IUserRepository
    {
        Task<Account> Login(LoginModel login);
        Task<bool> Register(Account account);
        Task<bool> GetUserByUserName(string userName);
        Task<Account> GetUserById(int id);  
    }
}
