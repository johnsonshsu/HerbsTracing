using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class pbcattbl
{
    public string pbt_tnam { get; set; } = null!;

    public int? pbt_tid { get; set; }

    public string pbt_ownr { get; set; } = null!;

    public short? pbd_fhgt { get; set; }

    public short? pbd_fwgt { get; set; }

    public string? pbd_fitl { get; set; }

    public string? pbd_funl { get; set; }

    public short? pbd_fchr { get; set; }

    public short? pbd_fptc { get; set; }

    public string? pbd_ffce { get; set; }

    public short? pbh_fhgt { get; set; }

    public short? pbh_fwgt { get; set; }

    public string? pbh_fitl { get; set; }

    public string? pbh_funl { get; set; }

    public short? pbh_fchr { get; set; }

    public short? pbh_fptc { get; set; }

    public string? pbh_ffce { get; set; }

    public short? pbl_fhgt { get; set; }

    public short? pbl_fwgt { get; set; }

    public string? pbl_fitl { get; set; }

    public string? pbl_funl { get; set; }

    public short? pbl_fchr { get; set; }

    public short? pbl_fptc { get; set; }

    public string? pbl_ffce { get; set; }

    public string? pbt_cmnt { get; set; }
}
