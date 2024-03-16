using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelViews.ModelView;
using Services.Interface;

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

        [Authorize]
        [HttpPost("add-Decor")]
        public async Task<IActionResult> AddDecor(DecorModel Decor)
        {
            try
            {
                var user = User.FindFirst("user")?.Value;
                var result = await _DecorService.AddDecor(Decor, user);
                return Ok(new { status = 200, tilte = "Success", data = Decor, mess = "Add Decor success" });

            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Add Decor fail" });
            }
        }

        [Authorize]
        [HttpPut("Decor-update")]
        public async Task<IActionResult> UpdateDecor(UpdateDecorModel Decor)
        {
            try
            {
                var user = User.FindFirst("user")?.Value;
                var items = await _DecorService.Update(Decor, user);
                return Ok(new { status = 200, tilte = "Success", data = items, mess = "Update success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Update fail" });
            }
        }
        [Authorize]
        [HttpDelete("Decor-delete/{id}")]
        public async Task<ActionResult> DeleteDecor(int id)
        {
            try
            {
                var user = User.FindFirst("user")?.Value;
                var items = await _DecorService.Delete(id, user);
                return Ok(new { status = 200, tilte = "Success", mess = "Delete success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Delete fail" });
            }
        }
    }
}
