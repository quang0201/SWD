using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Room
{
    public int Int { get; set; }

    public string Number { get; set; } = null!;

    public byte Status { get; set; }

    public byte Type { get; set; }

    public byte Size { get; set; }

    public int MaxCapacity { get; set; }

    public decimal Price { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedTime { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedTime { get; set; }
}
