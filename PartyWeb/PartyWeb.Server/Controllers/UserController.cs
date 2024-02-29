using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ModelViews;
using Server.Interface;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase, IUser
    {
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

    }
}
