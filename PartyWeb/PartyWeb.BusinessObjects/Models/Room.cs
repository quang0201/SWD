using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Room
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Content { get; set; }

    public decimal? Price { get; set; }

    public byte? Status { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public DateTime? DeletedTime { get; set; }

    public virtual Account? CreatedByNavigation { get; set; }

    public virtual ICollection<OrderRoom> OrderRooms { get; set; } = new List<OrderRoom>();
}
