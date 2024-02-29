using BusinessObjects.Models;
using ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IUserService
    {
        Task<List<Account>> GetAll();
        Task<Account> GetByLogin(LoginModel login);
    }
}
