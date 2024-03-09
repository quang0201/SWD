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
        public async Task<List<Food>> PaggingFood(int index, int pageSize, string? search, bool? sortDateAsc, bool? sortPriceAsc, bool? sortNameAsc)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    // Start with the base query
                    var query = dbContext.Foods.Where(x => x.Status == 1).AsQueryable();

                    // Apply search filter if provided
                    if (!string.IsNullOrEmpty(search))
                    {
                        query = query.Where(f => EF.Functions.Like(f.Name, $"%{search}%"));
                    }

                    // Apply sorting based on parameters
                    if (sortDateAsc.HasValue)
                    {
                        query = sortDateAsc == true ? query.OrderBy(f => f.CreatedTime) : query.OrderByDescending(f => f.CreatedTime);
                    }

                    else if (sortPriceAsc.HasValue)
                    {
                        query = sortPriceAsc == true ? query.OrderBy(f => f.Price) : query.OrderByDescending(f => f.Price);
                    }
                    else if (sortNameAsc.HasValue)
                    {
                        query = sortNameAsc == true ? query.OrderBy(f => f.Name) : query.OrderByDescending(f => f.Name);
                    }

                    // Apply paging
                    var result = await query.Skip((index - 1) * pageSize).Take(pageSize).ToListAsync();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }
        public async Task<bool> Update(Food food)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    dbContext.Entry(food).State = EntityState.Modified;
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }
        public async Task<Food> GetById(int id)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var food = await dbContext.Foods.FindAsync(id);
                    return food;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
