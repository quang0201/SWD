using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelViews.ModelView;
using Services.Interface;
using Services.Service;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecorController : ControllerBase
    {
        IDecorService _DecorService;
        public DecorController(IDecorService DecorService)
        {
            _DecorService = DecorService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(null);
        }

        [Authorize]
        [HttpPost("add-decor")]
        public async Task<IActionResult> AddDecor(DecorModel Decor)
        {
            try
            {
                var idUser = User.FindFirst("id")?.Value;
                var result = await _DecorService.AddDecor(Decor, idUser);
                return Ok(new { status = 200, tilte = "Success", data = Decor, mess = "Add Decor success" });

            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Add Decor fail" });
            }
        }
        [AllowAnonymous]
        [HttpGet("pagging-decor")]
        public async Task<IActionResult> GetOrdersPaging(int index, int pageSize, string? search, bool? sortDateAsc, bool? sortPriceAsc, bool? sortNameAsc)
        {
            try
            {
                var items = await _DecorService.PaggingDecor(index, pageSize, search, sortDateAsc, sortPriceAsc, sortNameAsc);

                return Ok(new { status = 200, tilte = "Success", data = items, mess = "Get items success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Get items fail" });
            }
        }

        [Authorize]
        [HttpPut("update-decor")]
        public async Task<IActionResult> UpdateDecor(UpdateDecorModel Decor)
        {
            try
            {
                var user = User.FindFirst("id")?.Value;
                var items = await _DecorService.Update(Decor, user);
                return Ok(new { status = 200, tilte = "Success", data = items, mess = "Update success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Update fail" });
            }
        }
        [Authorize]
        [HttpDelete("delete-decor/{id}")]
        public async Task<ActionResult> DeleteDecor(int id)
        {
            try
            {
                var idUser = User.FindFirst("id")?.Value;
                var items = await _DecorService.Delete(id, idUser);
                return Ok(new { status = 200, tilte = "Success", mess = "Delete success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Delete fail" });
            }
        }
    }
}
