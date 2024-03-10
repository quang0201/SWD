using BusinessObjects.Models;
using ModelViews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IUserService
    {
        Task<string> GetByLogin(LoginModel account);
        Task<bool>Register(RegisterModel account);
    }
}
