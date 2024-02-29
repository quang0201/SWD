using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ModelViews;
using Server.Interface;
using Services.Interface;
using System.Collections.Generic;
using System.Text.Json;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase, IUser
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel account)
        {
            var user = await _userService.GetByLogin(account);
            return Ok(new { status = "00", data = user, mess = "Đăng nhập thành công" });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public Task<bool> Register(Account account)
        {
            throw new NotImplementedException();
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _userService.GetAll();
            return Ok(new { status = "00", data = list, mess = "lấy data thành công" });
        }
    }
}
