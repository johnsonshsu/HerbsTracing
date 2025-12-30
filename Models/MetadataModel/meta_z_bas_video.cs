namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_bas_video))]
    public partial class z_bas_video
    {
        [NotMapped]
        [Display(Name = "啟用")]
        public bool misenabled { get; set; }
    }
}
public partial class metaz_bas_video
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "代號")]
    public string? mcode { get; set; }
    [Display(Name = "影片日期")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? mdate { get; set; }
    [Display(Name = "影片標題")]
    public string? mtitle { get; set; }
    [Display(Name = "影片檔名")]
    public string? mfile { get; set; }
    [Display(Name = "啟用")]
    public string? isenabled { get; set; }
}
