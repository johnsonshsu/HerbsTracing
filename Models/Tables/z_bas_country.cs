using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_bas_country
{
    public string rowid { get; set; } = null!;

    public string? continent_no { get; set; }

    public string? continent_name { get; set; }

    public string? mno { get; set; }

    public string? mname { get; set; }

    public string? mename { get; set; }

    public string? isenabled { get; set; }
}
