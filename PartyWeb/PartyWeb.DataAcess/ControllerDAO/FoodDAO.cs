using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.ControllerDAO
{
    public class FoodDAO
    {
        private static FoodDAO instance = default!;
        public static FoodDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FoodDAO();
                }
                return instance;
            }
        }
        public async Task<List<Food>> GetAll()
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    
                    return await dbContext.Foods.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }
        public async Task<bool> Add(Food food)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    await dbContext.Foods.AddAsync(food);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }
        public async Task<List<Food>> GetOrdersPagingAsync(int index, int pageSize, string? search, int? sortDate, int? sortPrice, int? sortName)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    // Start with the base query
                    var query = dbContext.Foods.AsQueryable();

                    // Apply search filter if provided
                    if (!string.IsNullOrEmpty(search))
                    {
                        query = query.Where(f => f.Name.Contains(search));
                    }

                    // Apply sorting based on parameters
                    if (sortDate.HasValue)
                    {
                        query = sortDate == 1 ? query.OrderBy(f => f.CreatedTime) : query.OrderByDescending(f => f.CreatedTime);
                    }
                    else if (sortPrice.HasValue)
                    {
                        query = sortPrice == 1 ? query.OrderBy(f => f.Price) : query.OrderByDescending(f => f.Price);
                    }
                    else if (sortName.HasValue)
                    {
                        query = sortName == 1 ? query.OrderBy(f => f.Name) : query.OrderByDescending(f => f.Name);
                    }

                    // Apply paging
                    var result = await query.Skip(index * pageSize).Take(pageSize).ToListAsync();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
