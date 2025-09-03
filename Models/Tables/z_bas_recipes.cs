using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_bas_recipes
{
    public int rowid { get; set; }

    public string? mcode { get; set; }

    public string? msort { get; set; }

    public string? mname { get; set; }

    public string? material { get; set; }

    public string? care { get; set; }

    public string? effect { get; set; }
}
