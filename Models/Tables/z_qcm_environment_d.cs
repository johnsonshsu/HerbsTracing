using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_qcm_environment_d
{
    public string rowid { get; set; } = null!;

    public string? mcode { get; set; }

    public string? mno { get; set; }

    public string? seq { get; set; }

    public string? test_no { get; set; }

    public string? test_value { get; set; }

    public string? stand_value { get; set; }
}
