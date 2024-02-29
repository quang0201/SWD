using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitories.FoodRepositores
{
    public interface IFoodService
    {
        List<Food> GetFoods();
        Food GetFoodsById(int FoodId);
        void CreateFoods(Food d);

        void UpdateFoods(Food d);

        void DeleteFoods(int FoodId);
    }
}
