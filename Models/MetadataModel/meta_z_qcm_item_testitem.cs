namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_qcm_item_testitem))]
    public partial class z_qcm_item_testitem
    {

    }
}

public class metaz_qcm_item_testitem
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "父代ID")]
    public string? parentid { get; set; }
    [Display(Name = "藥材編號")]
    public string? mno { get; set; }
    [Display(Name = "序號")]
    public string? seq { get; set; }
    [Display(Name = "檢驗代號")]
    public string? test_no { get; set; }
    [Display(Name = "檢驗項目")]
    public string? test_name { get; set; }
    [Display(Name = "檢測值")]
    public string? test_value { get; set; }
    [Display(Name = "判定基準")]
    public string? test_base { get; set; }
    [Display(Name = "單位")]
    public string? test_unit { get; set; }
    [Display(Name = "檢驗結果")]
    public string? test_result { get; set; }
}