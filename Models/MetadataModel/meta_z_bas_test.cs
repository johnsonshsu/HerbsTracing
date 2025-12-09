namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_bas_test))]
    public partial class z_bas_test
    {

    }
}

public class metaz_bas_test
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "類別")]
    public string? mcode { get; set; }
    [Display(Name = "代號")]
    public string? mno { get; set; }
    [Display(Name = "名稱")]
    public string? mname { get; set; }
    [Display(Name = "英文名稱")]
    public string? mename { get; set; }
}
