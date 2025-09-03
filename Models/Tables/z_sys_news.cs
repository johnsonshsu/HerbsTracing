using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_sys_news
{
    public string rowid { get; set; } = null!;

    public string? mcode { get; set; }

    public DateTime? mdate { get; set; }

    public DateTime? mtime { get; set; }

    public string? mtitle { get; set; }

    public string? mdescribe { get; set; }

    public string? isenabled { get; set; }
}
