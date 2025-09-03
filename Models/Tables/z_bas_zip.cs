using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_bas_zip
{
    public string rowid { get; set; } = null!;

    public string? country_no { get; set; }

    public string? country_name { get; set; }

    public string? province_no { get; set; }

    public string? province_name { get; set; }

    public string? city_no { get; set; }

    public string? city_name { get; set; }

    public string? town_no { get; set; }

    public string? town_name { get; set; }

    public string? road_no { get; set; }

    public string? road_name { get; set; }

    public string? scope_name { get; set; }

    public string? zip_no { get; set; }
}
