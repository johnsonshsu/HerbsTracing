namespace herbstracing.Models
{
        [ModelMetadataType(typeof(metaz_sys_module))]
        public partial class z_sys_module
        {
        [Display(Name = "類別")]
        public string? mcode_name { get { return (mcode == "SYS") ? "後台" : "前台"; } }
        [NotMapped]
        [Display(Name = "啟用")]
        public bool is_enabled { get; set; }
    }
}

public class metaz_sys_module
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "類別")]
    public string? mcode { get; set; }
    [Display(Name = "排序")]
    public string? msort { get; set; }
    [Display(Name = "代號")]
    public string? mno { get; set; }
    [Display(Name = "名稱")]
    public string? mname { get; set; }
    [Display(Name = "啟用")]
    public string? isenabled { get; set; }
}
