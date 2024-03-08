using BusinessObjects.Models;
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

        public async Task<Tuple<string, bool>> AddFood(FoodModel food, Account account)
        {
            if (!RegexString.Instance.ValidateInputVietnamese(food.Name))
            {
                return Tuple.Create("Tên không phù hợp", false);
            }
            if (!RegexString.Instance.ValidateInputVietnamese(food.Content))
            {
                return Tuple.Create("Nội dung không phù hợp", false);
            }
            if (!RegexString.Instance.ValidateInputDigitsLengthMinMax(food.Price, 1, 15))
            {
                return Tuple.Create("Giá tiền không phù hợp", false);
            }
            if (int.Parse(food.Price) < 0)
            {
                return Tuple.Create("Nhập một số hợp lệ", false);
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
            var result = await _foodRepo.Add(foodDTO);
            if (!result)
            {
                return Tuple.Create("Lỗi", false);
            }
            return Tuple.Create(JsonSerializer.Serialize(food), true);
        }
    }
}
