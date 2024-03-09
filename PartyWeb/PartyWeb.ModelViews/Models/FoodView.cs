﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViews.Models
{
    public class FoodView
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Content { get; set; }

        public decimal? Price { get; set; }
    }
}
