using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_car_buyitem
{
    public string rowid { get; set; } = null!;

    public DateTime? mdate { get; set; }

    public string? sessionid { get; set; }

    public string? item_no { get; set; }

    public string? item_name { get; set; }

    public decimal? qty { get; set; }

    public string? unit_no { get; set; }

    public decimal? price { get; set; }

    public decimal? amounts { get; set; }
}
