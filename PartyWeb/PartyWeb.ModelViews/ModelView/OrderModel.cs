using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViews.Models
{
    public class OrderModel
    {
        public OrderRoomModel orderRooms { get; set; } = default!;
        public List<OrderDecorModel> orderDecors { get; set; } = default!;
        public List<OrderFoodModel> orderFoods { get; set; } = default!;
    }
}
