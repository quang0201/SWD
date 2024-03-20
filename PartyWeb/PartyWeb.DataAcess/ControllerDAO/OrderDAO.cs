using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.ControllerDAO
{
    public class OrderDAO
    {
        private static OrderDAO instance = default!;
        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDAO();
                }
                return instance;
            }
        }
        public async Task<bool> Add(Order order)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    await dbContext.Orders.AddAsync(order);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }
        public async Task<bool> CheckRoomDateBook(int roomId, DateTime start, DateTime end)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    // Check if there are any existing bookings that overlap with the provided date range
                    var existingBooking = await dbContext.OrderRooms
                        .Where(b => b.IdRoom == roomId &&
                         (b.StartDate.Date.CompareTo(end.Date) <= 0 &&
                         start.Date.CompareTo(b.EndDate.Date) <= 0))
                        .FirstOrDefaultAsync();

                    if (existingBooking != null)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<List<Order>> PaggingOrder(int id,int index, int pageSize, bool? sortDateAsc, bool? sortPriceAsc)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    // Start with the base query
                    var query = dbContext.Orders.Where(x => x.CreatedBy == id).AsQueryable();



                    // Apply sorting based on parameters
                    if (sortDateAsc.HasValue)
                    {
                        query = sortDateAsc == true ? query.OrderBy(f => f.CreatedTime) : query.OrderByDescending(f => f.CreatedTime);
                    }

                    else if (sortPriceAsc.HasValue)
                    {
                        query = sortPriceAsc == true ? query.OrderBy(f => f.Price) : query.OrderByDescending(f => f.Price);
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
