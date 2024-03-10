using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using ModelViews.Models;
using Reponsitories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitories.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<bool> GetUserByUserName(string userName) => AccountDAO.Instance.GetUserByUserName(userName);
        public Task<Account> Login(LoginModel login) => AccountDAO.Instance.Login(login);

        public Task<bool> Register(Account account) => AccountDAO.Instance.Register(account);
    }
}
