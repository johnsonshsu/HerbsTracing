namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_sys_iplog))]
    public partial class z_sys_iplog
    {
        
    }
}

public class metaz_sys_iplog
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "類別")]
    public string? mcode { get; set; }
    [Display(Name = "製造批號")]
    public string? mlotno { get; set; }
    [Display(Name = "商品編號")]
    public string? mno { get; set; }
    [Display(Name = "記錄日期")]
    public DateTime? mdate { get; set; }
    [Display(Name = "記錄時間")]
    public DateTime? mtime { get; set; }
    [Display(Name = "IP位址")]
    public string? ipaddr { get; set; }
}

