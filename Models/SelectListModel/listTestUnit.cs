public partial class ListItemData : BaseClass
{
    /// <summary>
    /// 取得測試結果列表
    /// </summary>
    /// <returns></returns>
    public List<SelectListItem> TestUnitList()
    {
        List<SelectListItem> listData = new List<SelectListItem>();
        listData.Add(new SelectListItem() { Text = "%", Value = "%" });
        listData.Add(new SelectListItem() { Text = "ppm", Value = "ppm" });
        return listData;
    }
}
