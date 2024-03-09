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
        public Task<Tuple<string, bool>> AddFood(FoodModel food,Account account);
    }
}
