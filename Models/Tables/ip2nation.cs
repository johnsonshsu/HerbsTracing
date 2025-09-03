using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class ip2nation
{
    public long ip { get; set; }

    public string? country { get; set; }
}
