using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class FoodService : IFoodService
    {
        public void CreateFoods(Food d)
        => FoodDAO.CreateFoods(d);

        public void DeleteFoods(int FoodId)
        => FoodDAO.DeleteFoods(FoodId);

        public List<Food> GetFoods()
        => FoodDAO.GetFoods();

        public Food GetFoodsById(int FoodId)
        => FoodDAO.GetFoodsById(FoodId);

        public void UpdateFoods(Food d)
        => FoodDAO.UpdateFoods(d);
    }
}
