using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_qcm_item_testitem
{
    public string rowid { get; set; } = null!;

    public string? parentid { get; set; }

    public string? mno { get; set; }

    public string? seq { get; set; }

    public string? test_no { get; set; }

    public string? test_name { get; set; }

    public string? test_value { get; set; }

    public string? test_base { get; set; }

    public string? test_unit { get; set; }

    public string? test_result { get; set; }
}
