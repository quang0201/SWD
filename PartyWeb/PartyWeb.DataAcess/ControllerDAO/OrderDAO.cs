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
    }
}
