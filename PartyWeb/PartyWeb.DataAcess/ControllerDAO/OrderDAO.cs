using BusinessObjects.Models;
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
    }
}
