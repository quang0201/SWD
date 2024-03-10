using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelViews.Models;
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
                var result = await _foodService.AddFood(food, user);
                return Ok(new { status = 200, tilte = "Success", data = food, mess = "Add food fail" });

            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Add food fail" });
            }
        }

        [AllowAnonymous]
        [HttpGet("pagging-food")]
        public async Task<IActionResult> GetOrdersPaging(int index, int pageSize, string? search, bool? sortDateAsc, bool? sortPriceAsc, bool? sortNameAsc)
        {
            try
            {
                var items = await _foodService.PaggingFood(index, pageSize, search, sortDateAsc, sortPriceAsc, sortNameAsc);

                return Ok(new { status = 200, tilte = "Success", data = items, mess = "Get items success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Get items fail" });
            }
        }

        [Authorize]
        [HttpPut("food-update")]
        public async Task<IActionResult> UpdateFood(UpdateFoodModel food)
        {
            try
            {
                var user = User.FindFirst("user")?.Value;
                var items = await _foodService.Update(food, user);
                return Ok(new { status = 200, tilte = "Success", data = items, mess = "Update success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Update fail" });
            }
        }
        [Authorize]
        [HttpDelete("food-delete/{id}")]
        public async Task<ActionResult> DeleteFood(int id)
        {
            try
            {
                var user = User.FindFirst("user")?.Value;
                var items =  await _foodService.Delete(id, user);
                return Ok(new { status = 200, tilte = "Success", mess = "Delete success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Delete fail" });
            }
        }
        [Authorize]
        [HttpPut("food-approve")]
        public async Task<ActionResult> ApproveFood(int id)
        {
            try
            {
                var user = User.FindFirst("user")?.Value;
                var items = await _foodService.Approve(id, user);
                return Ok(new { status = 200, data =items,tilte = "Success", mess = "Active success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Active fail" });
            }
        }
    }
}
