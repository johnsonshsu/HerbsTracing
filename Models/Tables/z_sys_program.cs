using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_sys_program
{
    public string rowid { get; set; } = null!;

    public string? moduleno { get; set; }

    public string? prgcode { get; set; }

    public string? msort { get; set; }

    public string? mno { get; set; }

    public string? mname { get; set; }

    public string? urlpath { get; set; }

    public string? urlpage { get; set; }

    public string? isenabled { get; set; }
}
