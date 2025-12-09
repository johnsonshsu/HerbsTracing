using System;
using System.Collections.Generic;

namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_bas_test_item))]
    public partial class z_bas_test_item
    {
        [NotMapped]
        [Display(Name = "檢測編號")]
        public string? test_name { get; set; }
    }
}

public class metaz_bas_test_item
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "分類")]
    public string? mcode { get; set; }
    [Display(Name = "序號")]
    public string? seq { get; set; }
    [Display(Name = "檢測編號")]
    public string? test_no { get; set; }
}
