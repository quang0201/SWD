using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAcess.ControllerDAO
{
    public class DecorDAO
    {
        private static DecorDAO instance = default!;

        public static DecorDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DecorDAO();
                }
                return instance;
            }
        }
        public async Task<bool> Update(Decor food)
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

        public async Task<bool> Add(Decor food)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    await dbContext.Decors.AddAsync(food);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }
        public async Task<Decor> GetById(int id)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var item = await dbContext.Decors.SingleOrDefaultAsync(x => x.Id == id);
                    if (item != null)
                    {
                        return item;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }
        public async Task<List<Decor>> PaggingDecor(int index, int pageSize, string? search, bool? sortDateAsc, bool? sortPriceAsc, bool? sortNameAsc)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    // Start with the base query
                    var query = dbContext.Decors.Where(x => x.Status == 1).Include(x => x.CreatedByNavigation).AsQueryable();

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
    }
}
