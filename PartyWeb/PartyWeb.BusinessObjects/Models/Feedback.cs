using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? Stars { get; set; }

    public string? Content { get; set; }

    public int? CreatedBy { get; set; }

    public virtual Account? CreatedByNavigation { get; set; }
}
