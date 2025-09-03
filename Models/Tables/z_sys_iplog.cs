using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_sys_iplog
{
    public string rowid { get; set; } = null!;

    public string? mcode { get; set; }

    public string? mlotno { get; set; }

    public string? mno { get; set; }

    public DateTime? mdate { get; set; }

    public DateTime? mtime { get; set; }

    public string? ipaddr { get; set; }
}
