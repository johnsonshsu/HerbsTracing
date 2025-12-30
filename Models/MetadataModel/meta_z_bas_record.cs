namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_bas_record))]
    public partial class z_bas_record
    {
        [NotMapped]
        [Display(Name = "農戶編號")]
        public string? vender_name { get; set; }
        [NotMapped]
        [Display(Name = "產地編號")]
        public string? place_name { get; set; }
        [NotMapped]
        [Display(Name = "藥材編號")]
        public string? item_name { get; set; }
        [NotMapped]
        [Display(Name = "備註")]
        public string? remark { get {return string.Empty;} }

    }
}
public class metaz_bas_record
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "農戶編號")]
    public string? vender_no { get; set; }
    [Display(Name = "產地編號")]
    public string? place_no { get; set; }
    [Display(Name = "藥材編號")]
    public string? item_no { get; set; }
    [Display(Name = "記錄批號")]
    public string? lot_no { get; set; }
    [Display(Name = "記錄日期")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? mdate { get; set; }
    [Display(Name = "記錄說明")]
    public string? mdescribe { get; set; }
}
