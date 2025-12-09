using System;
using System.Collections.Generic;

namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_bas_item_desc))]
    public partial class z_bas_item_desc
    {

    }
}

public class metaz_bas_item_desc
{
    [Key]
    public int rowid { get; set; }
    [Display(Name = "排序")]
    public string? msort { get; set; }
    [Display(Name = "名稱")]
    public string? mname { get; set; }
    [Display(Name = "基原")]
    public string? mbase { get; set; }
    [Display(Name = "原產地")]
    public string? morigion { get; set; }
    [Display(Name = "修治")]
    public string? mplace { get; set; }
    [Display(Name = "性味歸經")]
    public string? mfix { get; set; }
    [Display(Name = "特色功能")]
    public string? mtested { get; set; }
    [Display(Name = "產地")]
    public string? mfuntion { get; set; }
}
