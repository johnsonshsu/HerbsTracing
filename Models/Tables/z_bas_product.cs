using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_bas_product
{
    /// <summary>
    /// 產品內容明細
    /// </summary>
    public int rowid { get; set; }

    public string? z_bas_item { get; set; }

    /// <summary>
    /// 編號
    /// </summary>
    public string? mno { get; set; }

    public string? mname { get; set; }

    /// <summary>
    /// 內容描述
    /// </summary>
    public string? mcontent { get; set; }
}
