namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_bas_vendor))]
    public partial class z_bas_vendor
    {
        [NotMapped]
        [Display(Name = "店家資訊")]
        public string mtitle { get; set; } = null!;
        [NotMapped]
        [Display(Name = "性別")]
        public string? msex_name
        {
            get
            {
                return msex == "M" ? "男" : msex == "F" ? "女" : "其他";
            }
        }
    }
}

public partial class metaz_bas_vendor
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "廠商編號")]
    public string mno { get; set; } = null!;
    [Display(Name = "廠商類別")]
    public string? mcode { get; set; }
    [Display(Name = "廠商名稱")]
    [Required(ErrorMessage = "{0} 為必填欄位")]
    public string? mname { get; set; }
    [Display(Name = "廠商地區")]
    public string? marea { get; set; }
    [Display(Name = "統一編號")]
    public string? mserialno { get; set; }
    [Display(Name = "主要產品")]
    public string? mproduct { get; set; }
    [Display(Name = "申請日期")]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
    public DateTime? cdate { get; set; }
    [Display(Name = "核准日期")]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
    public DateTime? adate { get; set; }
    [Display(Name = "狀態")]
    public string? mstatus { get; set; }
    [Display(Name = "性別")]
    public string? msex { get; set; }
    [Display(Name = "電話")]
    public string? mtel { get; set; }
    [Display(Name = "傳真")]
    public string? mfax { get; set; }
    [Display(Name = "手機")]
    public string? mmobil { get; set; }
    [Display(Name = "國別")]
    public string? country_no { get; set; }
    [Display(Name = "省")]
    public string? province_no { get; set; }
    [Display(Name = "市")]
    public string? city_no { get; set; }
    [Display(Name = "區")]
    public string? town_no { get; set; }
    [Display(Name = "路街號")]
    public string? road_no { get; set; }
    [Display(Name = "地址")]
    public string? maddlead { get; set; }
    [Display(Name = "主要地址")]
    public string? maddress { get; set; }
    [Display(Name = "店家地址")]
    public string? maddr { get; set; }
    [Display(Name = "電子郵件")]
    public string? memail { get; set; }
    [Display(Name = "負責人")]
    public string? userno { get; set; }
    [Display(Name = "驗證日期")]
    public DateTime? vdate { get; set; }
    [Display(Name = "備註")]
    public string? remark { get; set; }
    public string? mzipno { get; set; }
    public string? msname { get; set; }
    public string? mboss { get; set; }
    public string? mcontactor { get; set; }
    public string? mweburl { get; set; }
    public string? mtime { get; set; }
    public string? msubject { get; set; }
    public string? mskill { get; set; }
    public string? mdescribe { get; set; }
    public string? mpassword { get; set; }
    public string? mapaddr { get; set; }
    public string? mapdesc { get; set; }
    public string? mapx { get; set; }
    public string? mapy { get; set; }
    public string? ismap { get; set; }
}