using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_bas_video
{
    public string rowid { get; set; } = null!;

    public string? mcode { get; set; }

    public DateTime? mdate { get; set; }

    public string? mtitle { get; set; }

    public string? mfile { get; set; }

    public string? isenabled { get; set; }
}
