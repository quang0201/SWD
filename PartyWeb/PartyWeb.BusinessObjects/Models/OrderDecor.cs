using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class OrderDecor
{
    public int Id { get; set; }

    public int? IdOrder { get; set; }

    public int? IdDecor { get; set; }

    public int? Quality { get; set; }

    public decimal? TotalPrice { get; set; }

    public byte? Status { get; set; }

    public virtual Decor? IdDecorNavigation { get; set; }

    public virtual Order? IdOrderNavigation { get; set; }
}
