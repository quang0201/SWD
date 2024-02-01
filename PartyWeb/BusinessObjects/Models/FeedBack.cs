using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class FeedBack
{
    public int Id { get; set; }

    public string Content { get; set; } = null!;

    public string? IdParty { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedTime { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedTime { get; set; }
}
