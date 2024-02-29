using BusinessObjects.Models;

namespace Server.Interface
{
    public interface IFood
    {
        public Task<Food> GetAllFood();
        public Task<Food> AddOneFood(Food food);
        public List<Task<Food>> AddManyFood(List<Food> foods);
        public Task<bool> Update(Food food);
        public Task<bool> Delete(Food food);
        public List<Task<Food>> Pagging(int page, int pageSize);
    }
}
