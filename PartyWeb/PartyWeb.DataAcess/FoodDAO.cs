using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess
{
    public class FoodDAO
    {
        private static FoodDAO instance = null;
        private static readonly object instanceLock = new object();
        private FoodDAO() { }
        public static FoodDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new FoodDAO();
                    }
                }
                return instance;
            }
        }
        
    }
}
