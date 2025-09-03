using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_cart_order_d
{
    public string rowid { get; set; } = null!;

    public string? sheet_no { get; set; }

    public DateTime? sheet_date { get; set; }

    public string? seq { get; set; }

    public string? item_code { get; set; }

    public string? item_no { get; set; }

    public string? item_name { get; set; }

    public decimal? qty { get; set; }

    public decimal? price { get; set; }

    public decimal? amount { get; set; }

    public string? remark { get; set; }
}
