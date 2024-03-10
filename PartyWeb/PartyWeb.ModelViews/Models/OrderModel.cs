using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViews.Models
{
    public class OrderModel
    {
        public OrderRoom orderRooms { get; set; } = default!;
        public List<OrderDecor> orderDecors { get; set; } = default!;
        public List<OrderFood> orderFoods { get; set; } = default!;
    }
}
