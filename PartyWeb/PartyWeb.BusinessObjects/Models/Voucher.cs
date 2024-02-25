using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Voucher
{
    public int Id { get; set; }

    public byte Type { get; set; }

    public double Discount { get; set; }

    public byte Status { get; set; }

    public string Name { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime CreatedTime { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedTime { get; set; }
}
