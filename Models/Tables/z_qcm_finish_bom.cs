using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_qcm_finish_bom
{
    public string rowid { get; set; } = null!;

    public string? form_no { get; set; }

    public string? plot_no { get; set; }

    public string? clot_no { get; set; }

    public string? item_no { get; set; }
}
