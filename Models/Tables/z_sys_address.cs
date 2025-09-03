using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_sys_address
{
    public string rowid { get; set; } = null!;

    public string? parentid { get; set; }

    public string? country_no { get; set; }

    public string? province_no { get; set; }

    public string? city_no { get; set; }

    public string? town_no { get; set; }

    public string? road_no { get; set; }

    public string? addr_name { get; set; }
}
