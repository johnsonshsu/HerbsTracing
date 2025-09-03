using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class pbcatcol
{
    public string pbc_tnam { get; set; } = null!;

    public int? pbc_tid { get; set; }

    public string pbc_ownr { get; set; } = null!;

    public string pbc_cnam { get; set; } = null!;

    public short? pbc_cid { get; set; }

    public string? pbc_labl { get; set; }

    public short? pbc_lpos { get; set; }

    public string? pbc_hdr { get; set; }

    public short? pbc_hpos { get; set; }

    public short? pbc_jtfy { get; set; }

    public string? pbc_mask { get; set; }

    public short? pbc_case { get; set; }

    public short? pbc_hght { get; set; }

    public short? pbc_wdth { get; set; }

    public string? pbc_ptrn { get; set; }

    public string? pbc_bmap { get; set; }

    public string? pbc_init { get; set; }

    public string? pbc_cmnt { get; set; }

    public string? pbc_edit { get; set; }

    public string? pbc_tag { get; set; }
}
