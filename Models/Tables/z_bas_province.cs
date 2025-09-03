using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_bas_province
{
    public string rowid { get; set; } = null!;

    public string? country_no { get; set; }

    public string? country_name { get; set; }

    public string? mno { get; set; }

    public string? mname { get; set; }

    public string? mename { get; set; }
}
