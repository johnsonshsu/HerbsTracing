using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_sys_module
{
    public string rowid { get; set; } = null!;

    public string? mcode { get; set; }

    public string? msort { get; set; }

    public string? mno { get; set; }

    public string? mname { get; set; }

    public string? isenabled { get; set; }
}
