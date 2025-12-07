namespace herbstracing.Models
{
    [ModelMetadataType(typeof(metaz_sys_user))]
    public partial class z_sys_user
    {

    }
}

public class metaz_sys_user
{
    [Key]
    public string rowid { get; set; } = null!;

    public string? orgno { get; set; }

    public string? mcode { get; set; }

    public string mno { get; set; } = null!;

    public string? mname { get; set; }

    public string? msname { get; set; }

    public string? mename { get; set; }

    public string? mpassword { get; set; }

    public DateTime? indate { get; set; }

    public DateTime? checkdate { get; set; }

    public DateTime? confirmdate { get; set; }

    public string? msex { get; set; }

    public string? roleno { get; set; }

    public string? memail { get; set; }

    public string? mtel { get; set; }

    public string? userno { get; set; }

    public string? isenabled { get; set; }

    public string? remark { get; set; }
}