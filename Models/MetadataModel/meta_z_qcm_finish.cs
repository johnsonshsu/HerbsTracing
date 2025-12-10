namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_qcm_finish))]
    public partial class z_qcm_finish
    {

    }
}

public class metaz_qcm_finish
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "檢驗單號")]
    public string? mno { get; set; }
    [Display(Name = "檢驗日期")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? mdate { get; set; }
    [Display(Name = "溯源碼")]
    public string? plot_no { get; set; }
    [Display(Name = "成品編號")]
    public string? prod_no { get; set; }
    [Display(Name = "成品名稱")]
    public string? prod_name { get; set; }
    [Display(Name = "原料批號")]
    public string? clot_no { get; set; }
    [Display(Name = "製造批號")]
    public string? slot_no { get; set; }
    [Display(Name = "藥材編號")]
    public string? item_no { get; set; }
    [Display(Name = "藥材名稱")]
    public string? item_name { get; set; }
    [Display(Name = "有效日期")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? expire_date { get; set; }
    [Display(Name = "報告日期")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? report_date { get; set; }
    [Display(Name = "是否確認")]
    public string? isconfirm { get; set; }
    [Display(Name = "報告編號")]
    public string? report_no { get; set; }
    [Display(Name = "備註")]
    public string? remark { get; set; }
}
