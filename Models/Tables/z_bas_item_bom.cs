using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_bas_item_bom
{
    public string rowid { get; set; } = null!;

    public string? parentid { get; set; }

    public string? item_no { get; set; }

    public string? mno { get; set; }
}
