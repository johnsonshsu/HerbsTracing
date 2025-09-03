public class vmFood : BaseClass
{
    public string CodeNo { get; set; }
    public string CodeName { get; set; }
    public List<SelectListItem> FoodCodeList { get; set; }
    public List<z_bas_recipes> RecipeList { get; set; }
    public vmFood(string codeNo)
    {
        FoodCodeList = new List<SelectListItem>();
        RecipeList = new List<z_bas_recipes>();
        using var food = new dmFood();
        using var recipes = new sql_z_bas_recipes();
        CodeNo = codeNo;
        CodeName = food.GetFoodName(codeNo);
        RecipeList = recipes.GetDataList(codeNo);
    }
}