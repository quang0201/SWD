using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reponsitories.FoodRepositores;

namespace PartyWeb.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : ControllerBase
    {
        private IFoodService _FoodService = new FoodService();
        public FoodController()
        {
        }

        [Authorize]
        [HttpGet("GetFoods")]
        public IActionResult GetFoods()
        {
            try
            {
                
                List<Food> Foods = _FoodService.GetFoods();
                return Ok(Foods);

            }
            catch (Exception)
            {
                return BadRequest(new { error = "error" });
            }
        }

        [Authorize]
        [HttpGet("GetFoodsById/{id}")]
        public IActionResult GetFoodsById(int id)
        {
            try
            {

                Food Foods = _FoodService.GetFoodsById(id);
                return Ok(Foods);

            }
            catch (Exception)
            {
                return BadRequest(new { error = "error" });
            }
        }

        [Authorize]
        [HttpPost("CreateFoods")]
        public IActionResult CreateFoods(Food d)
        {
            try
            {
                _FoodService.CreateFoods(d);
                return Ok("Create Sucessfull");

            }
            catch (Exception)
            {
                return BadRequest(new { error = "error" });
            }
        }

        [Authorize]
        [HttpDelete("DeleteFoods")]
        public IActionResult DeleteFoods(int id)
        {
            try
            {

                _FoodService.DeleteFoods(id);
                return Ok("Delete Sucessfull");

            }
            catch (Exception)
            {
                return BadRequest(new { error = "error" });
            }
        }

        [Authorize]
        [HttpPut("UpdateFoods")]
        public IActionResult UpdateFoods(Food d)
        {
            try
            {

                _FoodService.UpdateFoods(d);
                return Ok("Update Sucessfull");

            }
            catch (Exception)
            {
                return BadRequest(new { error = "error" });
            }
        }


    }
}
