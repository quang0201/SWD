using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using Reponsitories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitories.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        public async Task<bool> Add(Food food) => await FoodDAO.Instance.Add(food);

        public Task<List<Food>> GetAll() => FoodDAO.Instance.GetAll();

        public Task<Food> GetById(int id) => FoodDAO.Instance.GetById(id);

        public Task<List<Food>> PaggingFood(int index, int pageSize, string? search, bool? sortDateAsc, bool? sortPriceAsc, bool? sortNameAsc)
            => FoodDAO.Instance.PaggingFood(index,pageSize,search,sortDateAsc,sortPriceAsc,sortNameAsc);

        public Task<bool> Update(Food food) => FoodDAO.Instance.Update(food);
    }
}
