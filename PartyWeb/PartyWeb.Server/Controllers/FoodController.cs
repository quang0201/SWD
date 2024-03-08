using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ModelViews;
using Services.Interface;
using System.Text.Json;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        IFoodService _foodService;
        public FoodController(IFoodService foodService) { 
            _foodService = foodService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _foodService.GetAll();
            return Ok(result);
        }

        [Authorize]
        [HttpPost("addfood")]
        public async Task<IActionResult> AddFood(FoodModel food)
        {
            var user = User.FindFirst("user")?.Value;
            if (user != null)
            {
                var acc = JsonSerializer.Deserialize<Account>(user);
                var result = await _foodService.AddFood(food,acc);
                if (!result.Item2)
                {
                    return Ok(new { status = "00", data = result.Item1, mess = "thêm thất bại" });
                }
                return Ok(new { status = "00",data = result.Item1 ,mess = "thêm food thành công" });
            }
            else
            {
                return Unauthorized(new { status = "01", mess = "Lỗi author" });
            }

        }
    }
}
