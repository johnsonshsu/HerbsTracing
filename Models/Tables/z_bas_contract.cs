using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_bas_contract
{
    public string rowid { get; set; } = null!;

    public string? user_no { get; set; }

    public string? place_no { get; set; }

    public string? item_no { get; set; }

    public string? mno { get; set; }

    public DateTime? mdate { get; set; }

    public DateTime? mdate1 { get; set; }

    public DateTime? mdate2 { get; set; }

    public string? lot_no { get; set; }

    public string isconfirm { get; set; } = null!;

    public string? isclose { get; set; }

    public string? remark { get; set; }
}
