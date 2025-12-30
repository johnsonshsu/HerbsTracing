namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_sys_program))]
    public partial class z_sys_program
    {
        [NotMapped]
        [Display(Name = "啟用")]
        public bool is_enabled { get; set; }
        [NotMapped]
        [Display(Name = "模組名稱")]
        public string? module_name { get; set; }
    }

}

public class metaz_sys_program
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "模組名稱")]
    public string? moduleno { get; set; }
    [Display(Name = "分類")]
    public string? prgcode { get; set; }
    [Display(Name = "排序")]
    public string? msort { get; set; }
    [Display(Name = "程式代號")]
    public string? mno { get; set; }
    [Display(Name = "程式名稱")]
    public string? mname { get; set; }
    [Display(Name = "路徑")]
    public string? urlpath { get; set; }
    [Display(Name = "頁數")]
    public string? urlpage { get; set; }
    [Display(Name = "啟用")]
    public string? isenabled { get; set; }
}
