using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ModelViews.Models;
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
            try
            {
                var result = await _userService.GetByLogin(account);
                return Ok(new { status = 200, tilte = "Success", data = account,token = result, mess = "Login success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Login fail" });
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel account)
        {
            try
            {
                var result = await _userService.Register(account);
                return Ok(new { status = 200, tilte = "Success", data = account, mess = "Register success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Register fail" });
            }
        }
        [Authorize]
        [HttpGet("get-user/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var idUser = User.FindFirst("id")?.Value;
                var user = await _userService.GetUserById(id,int.Parse(idUser));
                return Ok(new { status = 200, tilte = "Success", data = user, mess = "Register success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Register fail" });
            }
        }
        [Authorize]
        [HttpGet("get-user")]
        public async Task<IActionResult> GetUserByIdToken()
        {
            try
            {
                var idUser = User.FindFirst("id")?.Value;
                var user = await _userService.GetUserByIdToken(int.Parse(idUser));
                return Ok(new { status = 200, tilte = "Success", data = user, mess = "get user success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Register fail" });
            }
        }
    }
}
