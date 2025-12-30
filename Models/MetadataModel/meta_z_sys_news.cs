
namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_sys_news))]
    public partial class z_sys_news
    {
        [NotMapped]
        [Display(Name = "內容")]
        public string? mshort_describe { get; set; }
        [NotMapped]
        [Display(Name = "啟用")]
        public bool misenabled { get; set; }
    }
}

public class metaz_sys_news
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "代號")]
    public string? mcode { get; set; }
    [Display(Name = "日期")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? mdate { get; set; }
    [Display(Name = "時間")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
    public DateTime? mtime { get; set; }
    [Display(Name = "標題")]
    public string? mtitle { get; set; }
    [Display(Name = "內容")]
    public string? mdescribe { get; set; }
    [Display(Name = "啟用")]
    public string? isenabled { get; set; }
}
