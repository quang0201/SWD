using BusinessObjects.Models;
using Microsoft.Extensions.Configuration;
using ModelViews;
using Reponsitories.Interface;
using Reponsitories.Repositories;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Tool;

namespace Services.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userrepository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userrepository = userRepository;
            _configuration = configuration;
            Authentication.Initialize(_configuration);
        }

        public async Task<List<Account>> GetAll()
        {
            var listUser = await _userrepository.GetAll();
            return listUser;
        }

        public async Task<Account> GetByLogin(LoginModel login)
        {
            try
            {
                var user = await _userrepository.Login(login);
                var token = Authentication.Instance.CreateToken(user);
                Console.WriteLine(token);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
