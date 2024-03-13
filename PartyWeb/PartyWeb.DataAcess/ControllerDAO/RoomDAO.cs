using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAcess.ControllerDAO
{
    public class RoomDAO
    {
        private static RoomDAO instance = default!;

        public static RoomDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoomDAO();
                }
                return instance;
            }
        }

        public async Task<bool> Add(Room food)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    await dbContext.Rooms.AddAsync(food);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }
        public async Task<Room> GetById(int id)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var item = await dbContext.Rooms.SingleOrDefaultAsync(x => x.Id == id);
                    Console.WriteLine(item == null);
                    return item;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }
        public async Task<List<Room>> PaggingFood(int index, int pageSize, string? search, bool? sortDateAsc, bool? sortPriceAsc, bool? sortNameAsc)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    // Start with the base query
                    var query = dbContext.Rooms.Where(x => x.Status == 1).Include(x => x.CreatedByNavigation).AsQueryable();

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
