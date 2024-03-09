using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;

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

    }
}
