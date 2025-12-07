namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_bas_item))]
    public partial class z_bas_item
    {

    }
}

public class metaz_bas_item
{
    [Key]
    public string rowid { get; set; } = null!;

    public string? mcode { get; set; }

    public string? mtype { get; set; }

    public string? mno { get; set; }

    public string? mname { get; set; }

    public string? mename { get; set; }

    public string? munit { get; set; }

    public string? mplace { get; set; }

    public string? mparts { get; set; }

    public string? msource { get; set; }

    public string? mdescribe { get; set; }

    public string? mremark { get; set; }

    public decimal? msale { get; set; }

    public decimal? mprice { get; set; }

    public string? issale { get; set; }

    public string? ispicture { get; set; }

    public string? pictureurl { get; set; }

    public string? cart_unit { get; set; }

    public decimal? cart_price { get; set; }

    public decimal? cart_undiscount { get; set; }
}