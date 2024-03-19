using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using ModelViews.ModelView;
using ModelViews.ModelView.Accounts;
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
        [Route("get-all-account")]
       public async Task<IActionResult> GetAccounts()
        {
            try
            {
                List<ViewAccountModel>? accounts = await _service.GetAccounts();

                if (accounts == null)
                {
                    return NotFound();
                }
                return Ok(new { status = 200, tilte = "Success", data = accounts, message = "Get accounts successful" });
            }
            catch (Exception ex)
            {

                return BadRequest(new { status = 400, tilte = "Error", data = ex.Message, message = "Get accounts failed" });
            }
        }


        [HttpGet]
        [Route("view-account-details/{id}")]
        public async Task<IActionResult> ViewAccount(int id)
        {
            try
            {
                ViewAccountModel? account = await _service.GetAccountById(id);

                if (account == null)
                {
                    return NotFound();
                }
                return Ok(new { status = 200, tilte = "Success", data = account, message = "Get account successful" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", data = ex.Message, message = "Get account failed" });
            }
        }

        [HttpPost]
        [Route("add-account")]
        public async Task<IActionResult> AddAccount([FromBody] AddNewAccountModel account)
        {
            try
            {
                bool existedEmail = await _service.IsExistAccountEmail(account.Email ?? "");

                if (existedEmail == true)
                {
                    throw new Exception($"Account with email '{account.Email}' is already exist.");
                }

                bool existedUsername = await _service.IsExistAccountUsername(account.Username ?? "");

                if (existedUsername == true)
                {
                    throw new Exception($"Account with username '{account.Username}' is already exist.");
                }

                bool status = await _service.AddNewAccount(account);

                if (status)
                {
                    return Ok(new { status = 200, tilte = "Success", data = "Add account successful", message = "Add account successful" });
                }
                throw new Exception("Add account failed");
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", data = ex.Message, message = "Add account failed" });
            }
        }

        [HttpPost]
        [Route("update-account")]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountModel account)
        {
            try
            {
                bool status = await _service.UpdateAccount(account);

                if (status)
                {
                    return Ok(new { status = 200, tilte = "Success", data = "Update account successful", message = "Update account successful" });
                }
                throw new Exception("Update account failed");
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", data = ex.Message, message = "Add account failed" });
            }
        }

        [HttpDelete]
        [Route("delete-account/{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                ViewAccountModel? account = await _service.GetAccountById(id);

                if (account == null)
                {
                    return NotFound();
                }
                bool status = await _service.DeleteAccount(id);

                if (status)
                {
                    return Ok(new { status = 200, tilte = "Success", data = "Delete account successful", message = "Delete account successful" });
                }
                throw new Exception("Delete account failed");
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", data = ex.Message, message = "Delete account failed" });
            }
        }
    }
}
