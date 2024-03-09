using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelViews;
using Services.Interface;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        IFoodService _foodService;
        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(null);
        }

        [Authorize]
        [HttpPost("add-food")]
        public async Task<IActionResult> AddFood(FoodModel food)
        {
            try
            {
                var user = User.FindFirst("user")?.Value;
                if (user != null)
                {
                    var acc = JsonSerializer.Deserialize<Account>(user);
                    if (acc != null)
                    {
                        var result = await _foodService.AddFood(food, acc);

                        return Ok(new { status = "00", data = result, mess = "thêm food thành công" });
                    }
                    return Unauthorized(new { status = "01", mess = "Lỗi account" });
                }
                else
                {
                    return Unauthorized(new { status = "01", mess = "Lỗi author" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = "01", data = ex.Message, mess = "Error" });
            }
            
        }

        [AllowAnonymous]
        [HttpGet("pagging-food")]
        public async Task<IActionResult> GetOrdersPaging(int index, int pageSize, string? search, bool? sortDateAsc, bool? sortPriceAsc, bool? sortNameAsc)
        {
            try
            {
                var items = await _foodService.PaggingFood(index, pageSize, search, sortDateAsc, sortPriceAsc, sortNameAsc);
                return Ok(new { status = "00", data = items, mess = "Get items success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = "01", data = ex.Message, mess = "Error" });
            }
        }

        [Authorize]
        [HttpPut("food-update/{id}")]
        public IActionResult UpdateFood(int id, FoodModel food)
        {
            try
            {
                return Ok(new { status = "00", data = "", mess = "Update success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = "01", data = ex.Message, mess = "Error" });
            }
        }
        [Authorize]
        [HttpDelete("food-delete/{id}")]
        public ActionResult DeleteFood(int id)
        {
            try
            {

                return Ok(new { status = "00", data = "", mess = "Delete success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = "01", data = ex.Message, mess = "Error" });
            }
        }
    }
}
