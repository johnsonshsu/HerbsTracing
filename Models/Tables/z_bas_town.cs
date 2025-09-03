using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_bas_town
{
    public string rowid { get; set; } = null!;

    public string? country_no { get; set; }

    public string? country_name { get; set; }

    public string? province_no { get; set; }

    public string? province_name { get; set; }

    public string? city_no { get; set; }

    public string? city_name { get; set; }

    public string? mno { get; set; }

    public string? mname { get; set; }

    public string? mename { get; set; }
}
