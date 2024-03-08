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

        public async Task<Tuple<string,bool>> GetByLogin(LoginModel login)
        {
            try
            {
                if (!RegexString.Instance.ValidateInput(login.username))
                {
                    return Tuple.Create($"tài khoản không hợp lệ", false);
                }   
                if (!RegexString.Instance.ValidateInput(login.password))
                {
                    return Tuple.Create($"mật khẩu không hợp lệ", false);
                }
                
                var user = await _userrepository.Login(login);
                if (user == null)
                {
                    return Tuple.Create($"tài khoản hoặc mật khẩu không chính xác", false);
                }
                var token = Authentication.Instance.CreateToken(user);
                return Tuple.Create(token, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Tuple<string, bool>> Register(RegisterModel account)
        {
            try
            {
                if (!RegexString.Instance.ValidateInput(account.Username))
                {
                    return Tuple.Create($"tài khoản không hợp lệ", false);
                }
                if (!RegexString.Instance.ValidateInput(account.Password))
                {
                    return Tuple.Create($"mật khẩu không hợp lệ", false);
                }
                if (await _userrepository.GetUserByUserName(account.Username))
                {
                    return Tuple.Create($"Tài khoản đã tồn tại", false);
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
                return Tuple.Create("đăng kí thành công", true);
            }
            catch (Exception ex)
            {
                return Tuple.Create($"Error during registration: {ex.Message}", false);
            }
        }
    }
}
