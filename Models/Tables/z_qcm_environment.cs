using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_qcm_environment
{
    public string rowid { get; set; } = null!;

    public string? mcode { get; set; }

    public string? mno { get; set; }

    public string? user_no { get; set; }

    public string? place_no { get; set; }

    public string? lot_no { get; set; }

    public DateTime? mdate { get; set; }

    public DateTime? sdate { get; set; }

    public string? handle_no { get; set; }

    public string? remark { get; set; }

    public string? isconfirm { get; set; }
}
