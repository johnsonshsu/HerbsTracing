public partial class ListItemData : BaseClass
{
    /// <summary>
    /// 取得測試結果列表
    /// </summary>
    /// <returns></returns>
    public List<SelectListItem> TestEnglishResult()
    {
        List<SelectListItem> listData = new List<SelectListItem>();
        listData.Add(new SelectListItem() { Text = "Pass", Value = "Pass" });
        listData.Add(new SelectListItem() { Text = "Positive", Value = "Positive" });
        listData.Add(new SelectListItem() { Text = "Failure", Value = "Failure" });
        return listData;
    }
}
