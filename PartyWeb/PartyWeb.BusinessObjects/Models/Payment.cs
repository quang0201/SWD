using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Payment
{
    public int Id { get; set; }

    public int? Status { get; set; }

    public int? Amount { get; set; }

    public DateTime? TimeCreate { get; set; }

    public DateTime? TimeUpdate { get; set; }

    public string? TransIdSystem { get; set; }

    public int? CreatedBy { get; set; }
}
