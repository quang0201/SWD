using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using ModelViews;
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
        public Task<List<Account>> GetAll() => AccountDAO.Instance.GetAll();

        public Task<Account> Login(LoginModel login) => AccountDAO.Instance.Login(login);
    }
}
