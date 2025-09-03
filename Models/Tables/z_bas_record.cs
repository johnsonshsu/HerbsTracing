using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_bas_record
{
    public string rowid { get; set; } = null!;

    public string? vender_no { get; set; }

    public string? place_no { get; set; }

    public string? item_no { get; set; }

    public string? lot_no { get; set; }

    public DateTime? mdate { get; set; }

    public string? mdescribe { get; set; }
}
