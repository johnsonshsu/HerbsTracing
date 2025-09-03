using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class ip2nationCountries
{
    public string code { get; set; } = null!;

    public string iso_code_2 { get; set; } = null!;

    public string? iso_code_3 { get; set; }

    public string iso_country { get; set; } = null!;

    public string country { get; set; } = null!;

    public double lat { get; set; }

    public double lon { get; set; }
}
