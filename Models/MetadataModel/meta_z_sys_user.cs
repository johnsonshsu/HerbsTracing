namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_sys_user))]
    public partial class z_sys_user
    {
        [NotMapped]
        [Display(Name = "角色")]
        public string? role_name { get; set; }
        [NotMapped]
        [Display(Name = "啟用")]
        public bool isenable { get; set; }
        [NotMapped]
        [Display(Name = "狀態")]
        public string mcode_name
        {
            get { return (mcode == null) ? "正常" : mcode.ToLower() == "n" ? "正常" : "停用"; }
        }
    }
}

public class metaz_sys_user
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "組織")]
    public string? orgno { get; set; }
    [Display(Name = "類別")]
    public string? mcode { get; set; }
    [Display(Name = "帳號")]
    public string mno { get; set; } = null!;
    [Display(Name = "姓名")]
    public string? mname { get; set; }
    [Display(Name = "簡稱")]
    public string? msname { get; set; }
    [Display(Name = "英文名")]
    public string? mename { get; set; }
    [Display(Name = "密碼")]
    public string? mpassword { get; set; }
    [Display(Name = "申請日期")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? indate { get; set; }
    [Display(Name = "審核日期")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? checkdate { get; set; }
    [Display(Name = "過審日期")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? confirmdate { get; set; }
    [Display(Name = "性別")]
    public string? msex { get; set; }
    [Display(Name = "角色")]
    public string? roleno { get; set; }
    [Display(Name = "Email")]
    public string? memail { get; set; }
    [Display(Name = "電話")]
    public string? mtel { get; set; }
    [Display(Name = "工號")]
    public string? userno { get; set; }
    [Display(Name = "啟用")]
    public string? isenabled { get; set; }
    [Display(Name = "備註")]
    public string? remark { get; set; }
}
