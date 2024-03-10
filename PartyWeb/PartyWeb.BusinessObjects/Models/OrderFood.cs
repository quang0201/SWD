using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class OrderFood
{
    public int Id { get; set; }

    public int? IdFood { get; set; }

    public int? Quality { get; set; }

    public decimal? TotalPrice { get; set; }

    public int? IdOrder { get; set; }

    public byte? Status { get; set; }

    public virtual Food? IdFoodNavigation { get; set; }

    public virtual Order? IdOrderNavigation { get; set; }
}
