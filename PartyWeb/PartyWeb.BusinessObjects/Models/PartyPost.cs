using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class PartyPost
{
    public int PartyPostId { get; set; }

    public string PartyPostTitle { get; set; } = null!;

    public string PartyPostDetails { get; set; } = null!;

    public DateTime? CreatedTime { get; set; }

    public int? CreatedBy { get; set; }

    public virtual Account? CreatedByNavigation { get; set; }
}
