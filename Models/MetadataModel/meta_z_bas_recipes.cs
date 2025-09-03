namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_bas_recipes))]
    public partial class z_bas_recipes
    {

    }
}

public class metaz_bas_recipes
{
    [Key]
    public int rowid { get; set; }
    [Display(Name = "分類")]
    public string? mcode { get; set; }
    [Display(Name = "排序")]
    public string? msort { get; set; }
    [Display(Name = "名稱")]
    public string? mname { get; set; }
    [Display(Name = "材料")]
    public string? material { get; set; }
    [Display(Name = "料理")]
    public string? care { get; set; }
    [Display(Name = "功效")]
    public string? effect { get; set; }
}