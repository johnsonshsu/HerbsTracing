namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_qcm_finish_bom))]
    public partial class z_qcm_finish_bom
    {
        [NotMapped]
        public string? item_name { get; set; }
    }
}

public class metaz_qcm_finish_bom
{
    [Key]
    public string rowid { get; set; } = null!;

    public string? form_no { get; set; }

    public string? plot_no { get; set; }

    public string? clot_no { get; set; }

    public string? item_no { get; set; }
}
