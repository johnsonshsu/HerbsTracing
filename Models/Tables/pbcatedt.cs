using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class pbcatedt
{
    public string pbe_name { get; set; } = null!;

    public string? pbe_edit { get; set; }

    public short? pbe_type { get; set; }

    public int? pbe_cntr { get; set; }

    public short pbe_seqn { get; set; }

    public int? pbe_flag { get; set; }

    public string? pbe_work { get; set; }
}
