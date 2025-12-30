namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_sys_application))]
    public partial class z_sys_application
    {

    }
}

public class metaz_sys_application
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "系統名稱")]
    public string? app_name { get; set; }
    [Display(Name = "系統版本")]
    public string? app_version { get; set; }
    [Display(Name = "頁尾文字1")]
    public string? footer1 { get; set; }
    [Display(Name = "頁尾文字2")]
    public string? footer2 { get; set; }
    [Display(Name = "頁尾文字3")]
    public string? footer3 { get; set; }
    [Display(Name = "備註")]
    public string? remark { get; set; }
}
