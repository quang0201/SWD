using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.ControllerDAO
{
    public class PaymenDAO
    {
        private static PaymenDAO instance = default!;

        public static PaymenDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PaymenDAO();
                }
                return instance;
            }
        }
        public async Task<bool> Add(Payment payment)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    await dbContext.Payments.AddAsync(payment);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }
        public async Task<int> GetTotalPayment()
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    return await dbContext.Payments.CountAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
