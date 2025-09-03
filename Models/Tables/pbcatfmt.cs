using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class pbcatfmt
{
    public string pbf_name { get; set; } = null!;

    public string? pbf_frmt { get; set; }

    public short? pbf_type { get; set; }

    public int? pbf_cntr { get; set; }
}
