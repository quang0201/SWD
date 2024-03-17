using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViews.ModelView
{
    public class DecorViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Content { get; set; }

        public decimal? Price { get; set; }

        public string DecorProvider { get; set; } = null!;
    }
}
