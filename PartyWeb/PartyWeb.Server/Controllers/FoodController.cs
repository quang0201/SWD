using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PartyWeb.Server;
using Server.Interface;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase, IFood
    {
        [HttpGet("Get-All")]
        public async Task<Food> AddOneFood(Food food)
        {
            throw new NotImplementedException();
        }
        [HttpPost("Add")]
        public async Task<Food> GetAllFood()
        {
            throw new NotImplementedException();
        }
    }
}
