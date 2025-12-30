using System;
using System.Collections.Generic;

namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_bas_pHPLC))]
    public partial class z_bas_pHPLC
    {

    }
}

public class metaz_bas_pHPLC
{
    [Key]
    public int rowid { get; set; }
    [Display(Name = "照片編號")]
    public string? mno { get; set; }
    [Display(Name = "照片名稱")]
    public string? z_bas_item_bom_no { get; set; }
}
