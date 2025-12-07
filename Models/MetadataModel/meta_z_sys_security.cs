namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_sys_security))]
    public partial class z_sys_security
    {
        [NotMapped]
        [Display(Name = "模組名稱")]
        public string? module_name { get; set; }
    }
}

public class metaz_sys_security
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "使用者編號")]
    public string? user_no { get; set; }
    [Display(Name = "模組編號")]
    public string? module_no { get; set; }
    [Display(Name = "程式編號")]
    public string? prg_no { get; set; }
    [Display(Name = "程式名稱")]
    public string? prg_name { get; set; }
    [Display(Name = "是否啟用")]
    public string? isenabled { get; set; }
    [Display(Name = "新增權限")]
    public string? isadd { get; set; }
    [Display(Name = "編輯權限")]
    public string? isedit { get; set; }
    [Display(Name = "刪除權限")]
    public string? isdelete { get; set; }
    [Display(Name = "列印權限")]
    public string? isprint { get; set; }
    [Display(Name = "確認權限")]
    public string? isconfirm { get; set; }
}