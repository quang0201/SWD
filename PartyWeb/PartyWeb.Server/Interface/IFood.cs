using BusinessObjects.Models;

namespace Server.Interface
{
    public interface IFood
    {
        public Task<Food> GetAllFood();
        public Task<Food> AddOneFood(Food food);

    }
}
