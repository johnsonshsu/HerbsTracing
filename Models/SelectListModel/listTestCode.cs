public partial class ListItemData : BaseClass
{
    /// <summary>
    /// 取得測試類別列表
    /// </summary>
    /// <returns></returns>
    public List<SelectListItem> TestCodeList()
    {
        List<SelectListItem> listData = new List<SelectListItem>();
        listData.Add(new SelectListItem() { Text = "水分檢測", Value = "W" });
        listData.Add(new SelectListItem() { Text = "土壤檢測", Value = "P" });
        listData.Add(new SelectListItem() { Text = "藥材檢測", Value = "I" });
        return listData;
    }
}
