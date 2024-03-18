using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using ModelViews.ModelView;
using Services.Interface;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("view-account/{email}")]
        public async Task<IActionResult> ViewAccount(string email)
        {
            try
            {
                AccountModel? account = await _service.GetAccountByEmail(email);

                if(account == null)
                {
                    return NotFound();
                }
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("add-account")]
        public async Task<IActionResult> AddAccount([FromBody] AccountModel account)
        {
            try
            {
                AccountModel? acc = await _service.GetAccountByEmail(account.Email ?? "");

                if (acc != null)
                {
                    return BadRequest($"Account with email {account.Email} is already exist.");
                }
                bool status = await _service.AddNewAccount(account);

                if(status)
                {
                    return Ok("Add account succesful");
                }
                return BadRequest("Add account failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("update-account")]
        public async Task<IActionResult> UpdateAccount([FromBody] AccountModel account)
        {
            try
            {
                bool status = await _service.UpdateAccount(account);

                if (status)
                {
                    return Ok("Update account succesful");
                }
                return BadRequest("Update account failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete-account/{email}")]
        public async Task<IActionResult> DeleteAccount(string email)
        {
            try
            {
                AccountModel? account = await _service.GetAccountByEmail(email);

                if (account == null)
                {
                    return NotFound();
                }
                bool status = await _service.DeleteAccount(email);

                if (status)
                {
                    return Ok("Delete account succesful");
                }
                return BadRequest("Delete account failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
