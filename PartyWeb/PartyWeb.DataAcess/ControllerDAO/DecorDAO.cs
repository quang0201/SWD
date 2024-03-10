using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;

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

    }
}
