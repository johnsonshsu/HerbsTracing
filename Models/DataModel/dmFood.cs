public class FoodObject
{
    public string ItemNo { get; set; }
    public string ItemName { get; set; }
}

public class dmFood : BaseClass
{
    public List<FoodObject> FoodObjectList { get; set; }
    public dmFood()
    {
        FoodObjectList = new List<FoodObject>();
        FoodObjectList.Add(new FoodObject { ItemNo = "A", ItemName = "養生茶飲" });
        FoodObjectList.Add(new FoodObject { ItemNo = "B", ItemName = "養生藥膳" });
    }
    public string GetFoodName(string itemNo)
    {
        var food = FoodObjectList.FirstOrDefault(f => f.ItemNo == itemNo);
        return food?.ItemName ?? "Unknown";
    }
}