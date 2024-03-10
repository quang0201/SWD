using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
