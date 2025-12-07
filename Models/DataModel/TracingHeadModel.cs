using iText.Kernel.Crypto.Securityhandler;

/// <summary>
/// 溯源訊息表頭
/// </summary>
public class TracingHeadModel
{
    [Display(Name = "溯源碼")]
    public string TracingCode { get; set; }
    [Display(Name = "產品編號")]
    public string ProdNo { get; set; }
    [Display(Name = "產品名稱")]
    public string ProdName { get; set; }
    [Display(Name = "完工記錄ID")]
    public string FinishId { get; set; }
    [Display(Name = "製造批號")]
    public string PLotNo { get; set; }
    [Display(Name = "製造序號")]
    public string CLotNo { get; set; }
    [Display(Name = "製造批號")]
    public string ProdLotNo { get; set; }
    [Display(Name = "製造序號")]
    public string SerialNo { get; set; }
    [Display(Name = "報告日期")]
    public string ReportDate { get; set; }
    [Display(Name = "有效日期")]
    public string ValidDate { get; set; }
    [Display(Name = "報告編號")]
    public string ReportNo { get; set; }
    [Display(Name = "檢驗碼")]
    public string LotCode { get; set; }
    [Display(Name = "檢驗資訊")]
    public string CheckInfo { get; set; }
    [Display(Name = "作業名稱")]
    public string ActionName { get; set; }
}