/// <summary>
/// 溯源系統服務
/// </summary>
public class TracingService : BaseClass
{
    /// <summary>
    /// 溯源碼
    /// </summary>
    /// <value></value>
    public static string TracingCode
    {
        get { return SessionService.GetSessionValue("TracingCode", ""); }
        set { SessionService.SetSessionValue("TracingCode", value); }
    }
    /// <summary>
    /// 城市編號
    /// </summary>
    public static string CityNo
    {
        get { return SessionService.GetSessionValue("CityNo", ""); }
        set { SessionService.SetSessionValue("CityNo", value); }
    }
    /// <summary>
    /// 廠商編號
    /// </summary>
    /// <value></value>
    public static string VendorNo
    {
        get { return SessionService.GetSessionValue("VendorNo", ""); }
        set { SessionService.SetSessionValue("VendorNo", value); }
    }
    /// <summary>
    /// 地點編號
    /// </summary>
    /// <value></value>
    public static string PlaceNo
    {
        get { return SessionService.GetSessionValue("PlaceNo", ""); }
        set { SessionService.SetSessionValue("PlaceNo", value); }
    }
    /// <summary>
    /// 製造批號
    /// </summary>
    /// <value></value>
    public static string PLotNo
    {
        get { return SessionService.GetSessionValue("PLotNo", ""); }
        set { SessionService.SetSessionValue("PLotNo", value); }
    }
    /// <summary>
    /// 製造序號
    /// </summary>
    /// <value></value>
    public static string CLotNo
    {
        get { return SessionService.GetSessionValue("CLotNo", ""); }
        set { SessionService.SetSessionValue("CLotNo", value); }
    }
    /// <summary>
    /// 藥品編號
    /// </summary>
    /// <value></value>
    public static string ItemSubNo
    {
        get { return SessionService.GetSessionValue("ItemSubNo", ""); }
        set { SessionService.SetSessionValue("ItemSubNo", value); }
    }
    /// <summary>
    /// 藥品名稱
    /// </summary>
    /// <value></value>
    public static string ItemSubName
    {
        get { return SessionService.GetSessionValue("ItemSubName", ""); }
        set { SessionService.SetSessionValue("ItemSubName", value); }
    }
    /// <summary>
    /// 製造批號
    /// </summary>
    public string ProdLotNo { get { return TracingCode.Substring(0, 13); } }
    /// <summary>
    /// 製造序號
    /// </summary>
    public string SerialNo {
        get
        {
            if (TracingCode.Length == 22)
                return TracingCode.Substring(TracingCode.Length - 3, 3);
            else
                return TracingCode.Substring(TracingCode.Length - 5, 5);
        }
    }
    /// <summary>
    /// 報告類型
    /// </summary>
    public string ReportType { get; set; } = "";
    /// <summary>
    /// 報告連結
    /// </summary>
    /// <value></value>
    public string ReportLink { get; set; } = "";
    /// <summary>
    /// 藥材編號
    /// </summary>
    public string ItemNo { get; set; } = "";
    /// <summary>
    /// 藥材名稱
    /// </summary>
    public string ItemName { get; set; } = "";
    /// <summary>
    /// 檢查溯源碼
    /// </summary>
    /// <param name="tracingCode">溯源碼</param>
    /// <returns></returns>
    public string CheckTracingCode(string tracingCode)
    {
        string errorMessage = string.Empty;
        if (!string.IsNullOrEmpty(errorMessage))
        {
            return "請輸入溯源碼";
        }
        //追溯源人工輸入查詢：新舊模式都要留
        //舊：國際碼13碼+保期6碼(yymmdd)+批號3碼 → 4715688118720270901401
        //新：國際碼13碼+保期6碼(yymmdd)+批號5碼 → 471568811872027090125001
        if (tracingCode.Length != 24 && tracingCode.Length != 22)
        {
            return "溯源碼長度錯誤，請重新輸入";
        }
        TracingCode = tracingCode;
        return string.Empty;
    }
    /// <summary>
    /// 取得溯源表頭資訊
    /// </summary>
    /// <param name="tracingCode">溯源碼</param>
    /// <returns></returns>
    public TracingHeadModel GetTracingHead(string tracingCode)
    {
        var finish = new sql_z_qcm_finish();
        var model = finish.GetTracingHeadModel(tracingCode);
        return model;
    }

    /// <summary>
    /// 檢查報告類型
    /// </summary>
    /// <param name="itemNo">藥材編號</param>
    public void CheckReportType(string itemNo)
    {
        ReportType = "A";
        ReportLink = "";
        var item = new sql_z_bas_item();
        var itemModel = item.GetData(itemNo);
        ItemNo = itemNo;
        ItemName = itemModel.mname;
        if (string.IsNullOrEmpty(itemModel.mplace)) ReportType = "A";
        if (string.IsNullOrEmpty(itemModel.msource)) ReportLink = itemModel.msource;
    }

    /// <summary>
    /// 取得溯源查詢資料
    /// </summary>
    /// <param name="tracingCode">溯源碼</param>
    /// <param name="itemNo">藥材編號</param>
    /// <param name="cityNo">城市編號</param>
    /// <returns></returns>
    public vmTracingIndex GetTracingIndexData(string tracingCode, string itemNo, string cityNo)
    {
        TracingCode = tracingCode;
        CityNo = cityNo;
        if (!string.IsNullOrEmpty(itemNo)) ItemSubNo = itemNo;

        var tracingHead = GetTracingHead(TracingCode);
        PLotNo = tracingHead.PLotNo;

        var itemModel = new sql_z_bas_item();
        var bomModel = new sql_z_bas_item_bom();
        var itemBOMList = bomModel.GetDataList(tracingHead.ProdNo, "");
        var testItem = new sql_z_qcm_item_testitem();
        var testItemList = testItem.GetDataListByItemCode(itemNo, "I");
        var cityModel = new sql_z_bas_city();
        var vendorModel = new sql_z_bas_vendor();
        var placeModel = new sql_z_bas_place();
        var contractModel = new sql_z_bas_contract();
        var finishBomModel = new sql_z_qcm_finish_bom();
        finishBomModel.SetMaterialInfo(PLotNo, ItemSubNo);
        contractModel.SetMaterialInfo(CLotNo);
        var placeInfo = placeModel.GetProductPlace(VendorNo, PlaceNo);
        var item = itemModel.GetData(ItemSubNo);
        if (item != null) ItemSubName = item.mname;
        if (string.IsNullOrEmpty(CityNo))
        {
            CityNo = cityModel.GetShopCityList().FirstOrDefault() != null ? cityModel.GetShopCityList().FirstOrDefault().mno : "";
        }
        var model = new vmTracingIndex
        {
            TracingHead = tracingHead,
            ItemBOMList = itemBOMList,
            TestItemList = testItemList,
            CityList = cityModel.GetShopCityList(),
            VendorList = vendorModel.GetShopCityList(CityNo),
            PlaceInfo = placeInfo
        };
        return model;
    }

    /// <summary>
    /// 設定藥材資訊
    /// </summary>
    public void SetMaterialInfo()
    {
        var finishBom = new sql_z_qcm_finish_bom();
        var contract = new sql_z_bas_contract();
        finishBom.SetMaterialInfo(ProdLotNo, ItemSubNo);
        contract.SetMaterialInfo(CLotNo);
    }
}
