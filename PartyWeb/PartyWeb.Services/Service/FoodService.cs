using AutoMapper;
using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using ModelViews.Models;
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
        private readonly IMapper _mapper;

        public FoodService(IFoodRepository foodRepository, IMapper mapper)
        {
            _foodRepo = foodRepository;
            _mapper = mapper;
        }
        public async Task<List<Food>> GetAll()
        {
            return await _foodRepo.GetAll();
        }

        public async Task<bool> AddFood(FoodModel food, string user)
        {
            try
            {
                if (!Validation.Instance.CheckStringMinMax(food.Name, 2, 255))
                {
                    throw new Exception("Length of Name invalid");
                }
                if (Validation.Instance.ValidateInputVietnamese(food.Name))
                {
                    throw new Exception("Name contains special letters");
                }
                if (!Validation.Instance.CheckStringMinMax(food.Content, 2, 1000))
                {
                    throw new Exception("length of content invalid");
                }
                if (Validation.Instance.ValidateInputVietnamese(food.Content))
                {
                    throw new Exception("Content contains special letters");
                }
                if (!Validation.Instance.ValidateInputOnlyNumber(food.Price))
                {
                    throw new Exception("price only number");
                }
                if (int.Parse(food.Price) <= 0)
                {
                    throw new Exception("number invaild");
                }
                var account = JsonSerializer.Deserialize<Account>(user);
                if (account == null)
                {
                    throw new Exception("User happen error");
                }
                if (account.Role == 0)
                {
                    throw new Exception("you not role host");
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
                    throw new Exception("Add Fail");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<List<FoodViewModel>> PaggingFood(int index, int pageSize, string? search, bool? sortDateAsc, bool? sortPriceAsc, bool? sortNameAsc)
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
                var itemsMapper = _mapper.Map<List<FoodViewModel>>(items);
                return itemsMapper; // Trả về dữ liệu thành công
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }


        public async Task<bool> Update(UpdateFoodModel food, string user)
        {
            try
            {
                if (!Validation.Instance.ValidateInputOnlyNumber(food.Id))
                {
                    throw new Exception("id only number");
                }
                if (!Validation.Instance.CheckStringMinMax(food.Food.Name, 2, 255))
                {
                    throw new Exception("Length of Name invalid");
                }
                if (Validation.Instance.ValidateInputVietnamese(food.Food.Name))
                {
                    throw new Exception("Name contains special letters");
                }
                if (!Validation.Instance.CheckStringMinMax(food.Food.Content, 2, 1000))
                {
                    throw new Exception("length of content invalid");
                }
                if (Validation.Instance.ValidateInputVietnamese(food.Food.Content))
                {
                    throw new Exception("Content contains special letters");
                }
                if (!Validation.Instance.ValidateInputOnlyNumber(food.Food.Price))
                {
                    throw new Exception("price only number");
                }
                if (int.Parse(food.Food.Price) <= 0)
                {
                    throw new Exception("number invaild");
                }
                var account = JsonSerializer.Deserialize<Account>(user);
                if (account == null)
                {
                    throw new Exception("User happen error");
                }
                var foodDTO = await _foodRepo.GetById(int.Parse(food.Id));
                if (foodDTO == null)
                {
                    throw new Exception("Food not found");
                }
                if (foodDTO.Status != 1)
                {
                    throw new Exception("Food not active");
                }
                if (account.Role != 1)
                {
                    if (foodDTO.CreatedBy != account.Id)
                    {
                        throw new Exception("Food not yours");
                    }
                }
                foodDTO.Name = food.Food.Name;
                foodDTO.Price = int.Parse(food.Food.Price);
                foodDTO.Content = food.Food.Content;
                foodDTO.UpdatedTime = DateTime.Now;
                var result = await _foodRepo.Update(foodDTO);
                return true;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<bool> Delete(int id, string user)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("number invaild");
                }
                var account = JsonSerializer.Deserialize<Account>(user);
                if (account == null)
                {
                    throw new Exception("User happen error");
                }
                var foodDTO = await _foodRepo.GetById(id);
                if (foodDTO == null)
                {
                    throw new Exception("Food not found");
                }
                if (foodDTO.Status != 1)
                {
                    throw new Exception("Food not active");
                }
                if (account.Role != 1)
                {
                    if (foodDTO.CreatedBy != account.Id)
                    {
                        throw new Exception("Food not yours");
                    }
                }
                foodDTO.Status = 0;
                foodDTO.DeletedTime = DateTime.Now;
                var result = await _foodRepo.Update(foodDTO);
                return true;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<Food> Approve(int id, string user)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("number invaild");
                }
                var account = JsonSerializer.Deserialize<Account>(user);
                if (account == null)
                {
                    throw new Exception("User happen error");
                }
                var foodDTO = await _foodRepo.GetById(id);
                if (foodDTO == null)
                {
                    throw new Exception("Food not found");
                }
                if (foodDTO.Status == 1)
                {
                    throw new Exception("Food is actived");
                }
                if (account.Role != 1)
                {
                    throw new Exception("Dont Access");
                }
                foodDTO.Status = 1;
                foodDTO.UpdatedTime = DateTime.Now;
                var result = await _foodRepo.Update(foodDTO);
                return foodDTO;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }
    }
}
