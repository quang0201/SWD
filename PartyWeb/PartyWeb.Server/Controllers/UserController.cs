using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelViews;
using Server.Interface;
using Services.Interface;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase, IUser
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) { 
            _userService = userService;
        } 
        [AllowAnonymous]
        [HttpPost("login")]
        public Task<Account> Login(LoginModel account)
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public Task<bool> Register(Account account)
        {
            throw new NotImplementedException();
        }


        [HttpGet("GetAll")]
        public async Task<List<Account>> GetAll()
        {
            using (var dbContext = new SwdContext())
            {
                var accountList = await dbContext.Accounts.ToListAsync();
                Console.WriteLine(accountList.Count);
                if (accountList.Count == 0)
                {
                    Console.WriteLine("Danh sách không có phần tử.");
                }
                return accountList;
            }
        }
    }
}
