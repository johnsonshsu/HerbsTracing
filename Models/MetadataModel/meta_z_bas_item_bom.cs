namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_bas_item_bom))]
    public partial class z_bas_item_bom
    {
        [NotMapped]
        [Display(Name = "藥材名稱")]
        public string? mname { get; set; }
    }
}


public partial class metaz_bas_item_bom
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "父階Id")]
    public string? parentid { get; set; }
    [Display(Name = "父階品號")]
    public string? item_no { get; set; }
    [Display(Name = "藥材編號")]
    public string? mno { get; set; }
}