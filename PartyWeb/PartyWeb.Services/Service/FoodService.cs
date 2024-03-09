using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using ModelViews;
using Reponsitories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools.Tool;

namespace Services.Service
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepo;

        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepo = foodRepository;
        }
        public async Task<List<Food>> GetAll()
        {
            return await _foodRepo.GetAll();
        }

        public async Task<bool> AddFood(FoodModel food, Account account)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(food.Name))
                {

                }
                if (int.Parse(food.Price) < 0)
                {
                    throw new Exception("Money must than 0");
                }
                var foodDTO = new Food()
                {
                    Name = food.Name,
                    Content = food.Content,
                    Price = int.Parse(food.Price),
                    CreatedBy = account.Id,
                    Status = 2,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow
                };
                //status 
                //1 là active
                //0 là delete
                //2 là chờ approve
                //3 là bị từ chối
                var result = await _foodRepo.Add(foodDTO);
                if (!result)
                {
                    throw new Exception("add fail");
                }
                return true;
            }
            catch (Exception ex) {
                throw new(ex.Message);   
            }
        }

        public async Task<List<Food>> PaggingFood(int index, int pageSize, string? search, bool? sortDateAsc, bool? sortPriceAsc, bool? sortNameAsc)
        {

            try
            {
                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException("index must be >= 0");
                }
                if (pageSize < 0 || pageSize > 100)
                {
                    throw new ArgumentOutOfRangeException("range 1-100");
                }

                var items = await FoodDAO.Instance.PaggingFood(index, pageSize, search, sortDateAsc, sortPriceAsc, sortNameAsc);

                return items; // Trả về dữ liệu thành công
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public Task<bool> Update()
        {
            throw new NotImplementedException();
        }
    }
}
