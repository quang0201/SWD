using BusinessObjects.Models;
using Reponsitories.Interface;
using Reponsitories.Repositories;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userrepository;
        public UserService(IUserRepository userRepository)
        {
            _userrepository = userRepository;
        }

        public async Task<List<Account>> GetAll() {
            var listUser = await _userrepository.GetAll();
            return listUser; 
        }
    }
}
