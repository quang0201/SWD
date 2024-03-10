using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViews.Models
{
    public class OrderDecor
    {
        public int Id { get; set; }

        public int Quality { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
