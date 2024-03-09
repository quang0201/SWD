using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViews
{
    public class FoodModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Name length must be between 1 and 255.")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; } = default!;

        [Required(ErrorMessage = "Price is required.")]
        public string Price { get; set; } = default!;
    }
}
