﻿using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Role
{
    public byte Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}