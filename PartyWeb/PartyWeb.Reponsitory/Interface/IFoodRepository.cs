using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitories.Interface
{
    public interface IFoodRepository
    {
        Task<List<Food>> GetAll();
        Task<bool> Add(Food food);
        Task<bool> Update(Food food);
        Task<Food> GetById(int id);
    }
}
