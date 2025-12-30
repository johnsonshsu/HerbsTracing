namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_sys_role))]
    public partial class z_sys_role
    {
        [NotMapped]
        [Display(Name = "啟用")]
        public bool isenable { get; set; }
    }
}

public class metaz_sys_role
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "代號")]
    public string mno { get; set; } = null!;
    [Display(Name = "名稱")]
    public string? mname { get; set; }
    [Display(Name = "排序")]
    public string? msort { get; set; }
    [Display(Name = "啟用")]
    public string? isenabled { get; set; }
}
