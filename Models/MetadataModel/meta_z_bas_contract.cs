namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_bas_contract))]
    public partial class z_bas_contract
    {
        [NotMapped]
        [Display(Name = "農戶名稱")]
        public string? user_name { get; set; }
        [NotMapped]
        [Display(Name = "產地名稱")]
        public string? place_name { get; set; }
        [NotMapped]
        [Display(Name = "藥材名稱")]
        public string? item_name { get; set; }
    }
}

public partial class metaz_bas_contract
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "農戶編號")]
    public string? user_no { get; set; }
    [Display(Name = "產地編號")]
    public string? place_no { get; set; }
    [Display(Name = "藥材編號")]
    public string? item_no { get; set; }
    [Display(Name = "合約編號")]
    public string? mno { get; set; }
    [Display(Name = "合約日期")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? mdate { get; set; }
    [Display(Name = "合約起日")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? mdate1 { get; set; }
    [Display(Name = "合約迄日")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? mdate2 { get; set; }
    [Display(Name = "批號")]
    public string? lot_no { get; set; }
    [Display(Name = "確認")]
    public string isconfirm { get; set; } = null!;
    [Display(Name = "結案")]
    public string? isclose { get; set; }
    [Display(Name = "備註")]
    public string? remark { get; set; }
}
