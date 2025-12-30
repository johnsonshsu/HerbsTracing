using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_sys_application
{
    public string rowid { get; set; } = null!;

    public string? app_name { get; set; }

    public string? app_version { get; set; }

    public string? footer1 { get; set; }

    public string? footer2 { get; set; }

    public string? footer3 { get; set; }

    public string? remark { get; set; }
}
