using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Interface;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase, IFood
    {
        public List<Task<Food>> AddMany(List<Food> foods)
        {
            throw new NotImplementedException();
        }

        public Task<Food> AddOne(Food food)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Food food)
        {
            throw new NotImplementedException();
        }

        public Task<Food> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Task<Food>> Pagging(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Food food)
        {
            throw new NotImplementedException();
        }
    }
}
