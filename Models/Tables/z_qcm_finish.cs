using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_qcm_finish
{
    public string rowid { get; set; } = null!;

    public string? mno { get; set; }

    public DateTime? mdate { get; set; }

    public string? plot_no { get; set; }

    public string? prod_no { get; set; }

    public string? prod_name { get; set; }

    public string? clot_no { get; set; }

    public string? slot_no { get; set; }

    public string? item_no { get; set; }

    public string? item_name { get; set; }

    public DateTime? expire_date { get; set; }

    public DateTime? report_date { get; set; }

    public string? isconfirm { get; set; }

    public string? report_no { get; set; }

    public string? remark { get; set; }
}
