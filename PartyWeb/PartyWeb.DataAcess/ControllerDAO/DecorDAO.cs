using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
