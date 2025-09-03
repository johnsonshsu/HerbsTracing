using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_qcm_finish_d
{
    public string rowid { get; set; } = null!;

    public string? mno { get; set; }

    public string? seq { get; set; }

    public string? test_no { get; set; }

    public string? test_name { get; set; }

    public string? test_value { get; set; }

    public string? test_base { get; set; }

    public string? test_unit { get; set; }

    public string? test_result { get; set; }
}
