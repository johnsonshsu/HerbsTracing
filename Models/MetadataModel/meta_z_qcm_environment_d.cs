namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_qcm_environment_d))]
    public partial class z_qcm_environment_d
    {
        [NotMapped]
        [Display(Name = "項目名稱")]
        public string? test_name { get; set; }
        [NotMapped]
        [Display(Name = "備註")]
        public string? remark { get {return string.Empty;} }
    }
}

public  class metaz_qcm_environment_d
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "類別代碼")]
    public string? mcode { get; set; }
    [Display(Name = "檢驗單號")]
    public string? mno { get; set; }
    [Display(Name = "序號")]
    public string? seq { get; set; }
    [Display(Name = "項目代號")]
    public string? test_no { get; set; }
    [Display(Name = "檢驗值")]
    public string? test_value { get; set; }
    [Display(Name = "標準值")]
    public string? stand_value { get; set; }
}
