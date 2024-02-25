using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Order
{
    public int Id { get; set; }

    public string IdNumber { get; set; } = null!;

    public string? ListFood { get; set; }

    public string? ListDecor { get; set; }

    public string? Room { get; set; }

    public decimal PrePrice { get; set; }

    public decimal ActualPrice { get; set; }

    public byte Status { get; set; }

    public byte Type { get; set; }

    public string? Note { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedTime { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedTime { get; set; }
}
