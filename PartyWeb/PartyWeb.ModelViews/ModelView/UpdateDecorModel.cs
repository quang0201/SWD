using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViews.ModelView
{
    public class UpdateDecorModel
    {
        public int Id { get; set; } = default!;
        public DecorModel Decor { get; set; } = default!;
    }
}
