using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViews
{
    public class UpdateFoodModel
    {
        public string Id { get; set; } = default!;
        public FoodModel Food { get; set; } = default!;
    }
}
