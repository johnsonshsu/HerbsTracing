using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_sys_security
{
    public string rowid { get; set; } = null!;

    public string? user_no { get; set; }

    public string? module_no { get; set; }

    public string? prg_no { get; set; }

    public string? prg_name { get; set; }

    public string? isenabled { get; set; }

    public string? isadd { get; set; }

    public string? isedit { get; set; }

    public string? isdelete { get; set; }

    public string? isprint { get; set; }

    public string? isconfirm { get; set; }
}
