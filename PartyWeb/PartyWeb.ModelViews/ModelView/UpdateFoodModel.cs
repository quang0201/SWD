using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViews.Models
{
    public class UpdateFoodModel
    {
        public int Id { get; set; } = default!;
        public FoodModel Food { get; set; } = default!;
    }
}
