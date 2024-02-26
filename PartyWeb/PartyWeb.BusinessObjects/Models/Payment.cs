using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Payment
{
    public int Id { get; set; }

    public string IdPayment { get; set; } = null!;

    public decimal Money { get; set; }

    public string? Content { get; set; }

    public string? Type { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedTime { get; set; }
}
