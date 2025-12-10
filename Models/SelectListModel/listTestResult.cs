public partial class ListItemData : BaseClass
{
    /// <summary>
    /// 取得測試結果列表
    /// </summary>
    /// <returns></returns>
    public List<SelectListItem> TestResultList()
    {
        List<SelectListItem> listData = new List<SelectListItem>();
        listData.Add(new SelectListItem() { Text = "合格", Value = "True" });
        listData.Add(new SelectListItem() { Text = "不合格", Value = "False" });
        return listData;
    }
}
