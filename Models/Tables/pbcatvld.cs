using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class pbcatvld
{
    public string pbv_name { get; set; } = null!;

    public string? pbv_vald { get; set; }

    public short? pbv_type { get; set; }

    public int? pbv_cntr { get; set; }

    public string? pbv_msg { get; set; }
}
