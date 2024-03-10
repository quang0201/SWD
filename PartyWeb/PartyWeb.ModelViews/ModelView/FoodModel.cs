using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViews.Models
{
    public class FoodModel
    {
        public string Name { get; set; } = default!;

        public string Content { get; set; } = default!;

        public string Price { get; set; } = default!;
    }
}
