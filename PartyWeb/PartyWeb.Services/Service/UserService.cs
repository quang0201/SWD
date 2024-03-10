using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IUserRepository _userrepository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IConfiguration configuration, IMapper mapper)
        {
            _userrepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
            Authentication.Initialize(_configuration);
        }

        public async Task<string> GetByLogin(LoginModel login)
        {
            try
            {
                if (!RegexString.Instance.CheckStringMinMax(login.Username, 2, 100))
                {
                    throw new Exception("Length of username invalid");
                }
                if (!RegexString.Instance.ValidateInput(login.Username))
                {
                    throw new Exception("Username contains special letters");
                }
                if (!RegexString.Instance.CheckStringMinMax(login.Password, 2, 100))
                {
                    throw new Exception("length of password invalid");
                }
                if (!RegexString.Instance.ValidateInput(login.Password))
                {
                    throw new Exception("Password contains special letters");
                }
                var user = await _userrepository.Login(login);
                if(user == null)
                {
                    throw new Exception("Not exist account");
                }
                var token = Authentication.Instance.CreateToken(user);
                return token;
            }
            catch (Exception ex)
            {
                throw new (ex.Message);
            }
        }
        public async Task<bool> Register(RegisterModel account)
        {
            try
            {
                if (!RegexString.Instance.CheckStringMinMax(account.Username,2,100))
                {
                    throw new Exception("Length of username invalid");
                }
                if (!RegexString.Instance.ValidateInput(account.Username))
                {
                    throw new Exception("Username contains special letters");
                }
                if (!RegexString.Instance.CheckStringMinMax(account.Password, 2, 100))
                {
                    throw new Exception("length of password invalid");
                }
                if (!RegexString.Instance.ValidateInput(account.Password))
                {
                    throw new Exception("Password contains special letters");
                }
                if (!RegexString.Instance.ValidateEmail(account.Email))
                {
                    throw new Exception("Invalid email");
                }

                var checkExist = await _userrepository.GetUserByUserName(account.Username);
                if (checkExist)
                {
                    throw new Exception("Username exist");
                }
                var user = new Account()
                {
                    Username = account.Username,
                    Password = account.Password,
                    Email = account.Email,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Role = 0,
                    Status = 1,
                };
                // role
                // 0 = customer 
                // 1 = host
                // 2 = admin

                //status
                //0 = xoá
                //1 = đang hoạt động
                //2 = đang chặn
                //3 = 
                await _userrepository.Register(user);
                return true;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }
    }
}
