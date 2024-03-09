using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class OrderRoom
{
    public int Id { get; set; }

    public int IdOrder { get; set; }

    public int IdRoom { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal? TotalPrice { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Room IdRoomNavigation { get; set; } = null!;
}
