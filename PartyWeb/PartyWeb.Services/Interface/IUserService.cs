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
        Task<Tuple<string,bool>> GetByLogin(LoginModel account);
        Task<Tuple<string,bool>> Register(RegisterModel account);
    }
}
