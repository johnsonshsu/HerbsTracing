namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_qcm_finish_d))]
    public partial class z_qcm_finish_d
    {

    }
}
public partial class metaz_qcm_finish_d
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "檢驗單號")]
    public string? mno { get; set; }
    [Display(Name = "序號")]
    public string? seq { get; set; }
    [Display(Name = "項目代碼")]
    public string? test_no { get; set; }
    [Display(Name = "項目名稱")]
    public string? test_name { get; set; }
    [Display(Name = "檢驗值")]
    public string? test_value { get; set; }
    [Display(Name = "檢驗標準")]
    public string? test_base { get; set; }
    [Display(Name = "單位")]
    public string? test_unit { get; set; }
    [Display(Name = "檢驗結果")]
    public string? test_result { get; set; }
}
