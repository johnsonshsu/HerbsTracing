namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_bas_city))]
    public partial class z_bas_city
    {

    }
}

public class metaz_bas_city
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "國家代號")]
    public string? country_no { get; set; }
    [Display(Name = "國家名稱")]
    public string? country_name { get; set; }
    [Display(Name = "省份代號")]
    public string? province_no { get; set; }
    [Display(Name = "省份名稱")]
    public string? province_name { get; set; }
    [Display(Name = "縣市代號")]
    public string? mno { get; set; }
    [Display(Name = "縣市名稱")]
    public string? mname { get; set; }
    [Display(Name = "英文名稱")]
    public string? mename { get; set; }
}
