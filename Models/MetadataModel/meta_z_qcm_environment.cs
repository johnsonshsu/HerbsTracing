namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_qcm_environment))]
    public partial class z_qcm_environment
    {
        [NotMapped]
        [Display(Name = "類別代碼")]
        public string? mcode_name {
            get {
                using var listData = new ListItemData();
                string codeName = listData.TestCodeList().FirstOrDefault(x => x.Value == mcode)?.Text ?? "";
            return codeName;
        } }
        [NotMapped]
        [Display(Name = "農戶名稱")]
        public string? user_name { get; set; }
        [NotMapped]
        [Display(Name = "產地名稱")]
        public string? place_name { get; set; }
        [NotMapped]
        [Display(Name = "檢驗結果")]
        public string? remark_name { get {return (remark is null) ? "未檢驗" : (remark == "True") ? "合格" : "不合格"; } }
    }
}

public partial class metaz_qcm_environment
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "類別代碼")]
    public string? mcode { get; set; }
    [Display(Name = "檢驗單號")]
    public string? mno { get; set; }
    [Display(Name = "農戶編號")]
    public string? user_no { get; set; }
    [Display(Name = "產地編號")]
    public string? place_no { get; set; }
    [Display(Name = "合約批號")]
    public string? lot_no { get; set; }
    [Display(Name = "送驗日期")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? mdate { get; set; }
    [Display(Name = "檢驗日期")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? sdate { get; set; }
    [Display(Name = "經手人員")]
    public string? handle_no { get; set; }
    [Display(Name = "檢驗結果")]
    public string? remark { get; set; }
    [Display(Name = "是否確認")]
    public string? isconfirm { get; set; }
}
