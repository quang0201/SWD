using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ModelViews;
using Services.Interface;
using System.Collections.Generic;
using System.Text.Json;
using Tools.Tool;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
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
            var result = await _userService.GetByLogin(account);
            if (result.Item2)
            {
                return Ok(new { status = "00", data =result.Item1, mess = "Đăng nhập thành công" });
            }
            else
            {

                return BadRequest(new { status = "00", data = $"{result.Item1}", mess = "đăng nhập thất bại" });
            }

        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel account)
        {
            var result = await _userService.Register(account);
            if (!result.Item2)
            {
                return BadRequest(new { status = "00",data = $"{result.Item1}" ,mess = "Đăng kí thất bại" });
            }
            return Ok(new { status = "00", mess = "Đăng kí thành công" });
        }

    }
}
