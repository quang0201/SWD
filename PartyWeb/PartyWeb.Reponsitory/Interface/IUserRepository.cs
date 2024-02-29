using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitories.Interface
{
    public interface IUserRepository
    {
        Task<List<Account>> GetAll();

    }
}
