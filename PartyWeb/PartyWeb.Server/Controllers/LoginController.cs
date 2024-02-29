using BusinessObjects.Models;
using BusinessObjects.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Repositories.AccountRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // GET: api/<LoginController>
        private IConfiguration _configuration;
        private readonly IAccountRepository _accountRepository;
        public LoginController(IConfiguration configuration, IAccountRepository accountRepository)
        {
            _configuration = configuration;
            _accountRepository = accountRepository;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Account>>> GetAllAccounts()
        {
            if (_accountRepository == null)
            {
                return NotFound();
            }
            return await _accountRepository.GetAllAccounts();
        }

        [HttpPost]
        public async Task<IActionResult> Login(BusinessObjects.RequestModels.LoginRequest request)
        {
            IActionResult response = Unauthorized();
            if (request.Email == "" || request.Email == null)
            {
                if (request.Password == null || request.Password == "")
                {
                    return BadRequest("Please enter username or password.");
                }

            }
            var result = await _accountRepository.Login(request);
            if (result == null)
            {
                return BadRequest("Account not exist.");
            }
            var tokenString = GenerateJSONWebToken(result);
            response = Ok(new { token = tokenString });
            return Ok("Login successfully.");
        }
        private string GenerateJSONWebToken(Account userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
