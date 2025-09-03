using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_cart_order
{
    public string rowid { get; set; } = null!;

    public string? sheet_no { get; set; }

    public DateTime? sheet_date { get; set; }

    public string? sheet_code { get; set; }

    public string? target_no { get; set; }

    public string? target_name { get; set; }

    public decimal? amount { get; set; }
}
