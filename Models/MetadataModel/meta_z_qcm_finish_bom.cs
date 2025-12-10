namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_qcm_finish_bom))]
    public partial class z_qcm_finish_bom
    {
        [NotMapped]
        [Display(Name = "藥材名稱")]
        public string? item_name { get; set; }
    }
}

public class metaz_qcm_finish_bom
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "檢驗單號")]
    public string? form_no { get; set; }
    [Display(Name = "溯源碼")]
    public string? plot_no { get; set; }
    [Display(Name = "藥材批號")]
    public string? clot_no { get; set; }
    [Display(Name = "藥材編號")]
    public string? item_no { get; set; }
}
