using BusinessObjects.Models;
using ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IFoodService
    {
        Task<List<Food>> GetAll();
        public Task<bool> AddFood(FoodModel food,string user);
        public Task<List<Food>> PaggingFood(int index, int pageSize, string? search, bool? sortDate, bool? sortPrice, bool? sortName);
        public Task<bool> Update(UpdateFoodModel food, string user);
        public Task<bool> Delete(int id,string user);
    }
}
