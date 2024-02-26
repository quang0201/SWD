using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Tran
{
    public int Id { get; set; }

    public string IdNumber { get; set; } = null!;

    public string IdPayment { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime? CreatedTime { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedTime { get; set; }
}
