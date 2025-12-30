namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_bas_item))]
    public partial class z_bas_item
    {
        [NotMapped]
        [Display(Name = "類別")]
        public string? mcode_name { get { return (mcode == "M" ? "藥材" : (mcode == "H" ? "科中" : "其他")); } }
        [NotMapped]
        [Display(Name = "分類")]
        public string? mtype_name { get; set; }
        [NotMapped]
        [Display(Name = "報告類別")]
        public string? mplace_name { get { return (mcode == "A" ? "廠內報告" : (mcode == "B" ? "PDF 檔" : (mcode == "C") ? "廠外連結" : "")); } }
        [NotMapped]
        [Display(Name = "圖片1")]
        public string? item_image1 { get; set; }
        [NotMapped]
        [Display(Name = "圖片2")]
        public string? item_image2 { get; set; }
    }
}

public class metaz_bas_item
{
    [Key]
    public string rowid { get; set; } = null!;
    [Display(Name = "類別")]
    public string? mcode { get; set; }
    [Display(Name = "分類")]
    public string? mtype { get; set; }
    [Display(Name = "藥材編號")]
    public string? mno { get; set; }
    [Display(Name = "藥材名稱")]
    public string? mname { get; set; }
    [Display(Name = "英文名稱")]
    public string? mename { get; set; }
    [Display(Name = "計量單位")]
    public string? munit { get; set; }
    [Display(Name = "報告類別")]
    public string? mplace { get; set; }
    [Display(Name = "藥用部位")]
    public string? mparts { get; set; }
    [Display(Name = "報告連結")]
    public string? msource { get; set; }
    [Display(Name = "性狀")]
    public string? mdescribe { get; set; }
    [Display(Name = "英文備註")]
    public string? mremark { get; set; }

    public decimal? msale { get; set; }

    public decimal? mprice { get; set; }
    [Display(Name = "顯示成品檢驗")]
    public string? issale { get; set; }

    public string? ispicture { get; set; }

    public string? pictureurl { get; set; }

    public string? cart_unit { get; set; }

    public decimal? cart_price { get; set; }

    public decimal? cart_undiscount { get; set; }
}
