using X.PagedList;
using X.PagedList.Extensions;
namespace herbstracing.Controllers;

public class HomeController : Controller
{
    public IActionResult Index(int id = 1)
    {
        var sqlModel = new sql_z_sys_news();
        var model = sqlModel.GetDataList()
            .OrderByDescending(x => x.mdate)
            .ThenByDescending(x => x.mtime)
            .ToPagedList(id, 10);
        SessionService.Page = id;
        ViewBag.PageInfo = $"( {id} / {model.PageCount} )";
        ViewBag.ErrorMessage = TempData["ErrorMessage"] == null ? string.Empty : TempData["ErrorMessage"].ToString();
        return View(model);
    }

    /// <summary>
    /// 最新消息
    /// </summary>
    /// <param name="id">記錄 Id</param>
    /// <returns></returns> 
    public IActionResult News(string id = "")
    {
        var sqlModel = new sql_z_sys_news();
        var model = sqlModel.GetData(id);
        return View(model);
    }

    /// <summary>
    /// 產地地圖
    /// </summary>
    /// <returns></returns> 
    public IActionResult Map()
    {
        return View();
    }

    /// <summary>
    /// 栽種影片
    /// </summary>
    public IActionResult Video()
    {
        var sqlModel = new sql_z_bas_video();
        var model = sqlModel.GetDataList();
        return View(model);
    }

    /// <summary>
    /// 履歷流程
    /// </summary>
    /// <returns></returns> 
    public IActionResult Flow()
    {
        return View();
    }

    /// <summary>
    /// 藥材簡介
    /// </summary>
    /// <returns></returns> 
    public IActionResult Item(string id = "A")
    {
        ViewBag.ItemNo = id;
        return View();
    }

    /// <summary>
    /// 藥材食譜
    /// </summary>
    /// <returns></returns> 
    public IActionResult Food(string id = "A")
    {
        using var model = new vmFood(id);
        return View(model);
    }

    /// <summary>
    /// 查詢溯源碼
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Search()
    {
        SessionService.SearchText = string.Empty;
        object obj_text = Request.Form["SearchText"];
        string str_text = obj_text == null ? string.Empty : obj_text.ToString().Trim();
        TracingService tracingService = new TracingService();
        var errorMessage = tracingService.CheckTracingCode(str_text);
        if (!string.IsNullOrEmpty(errorMessage))
        {
            TempData["ErrorMessage"] = errorMessage;
            return RedirectToAction(ActionService.Index, ActionService.Home, new { area = ActionService.Area, id = SessionService.Page });
        }
        SessionService.SearchText = str_text;
        return RedirectToAction(ActionService.Search, "Tracing", new { area = ActionService.Area, id = str_text });
    }

    /// <summary>
    /// 檢驗中心
    /// </summary>
    /// <returns></returns> 
    public IActionResult Tester()
    {
        return View();
    }

    /// <summary>
    /// 取得行政區資料 (AJAX API)
    /// </summary>
    /// <param name="country">國家</param>
    /// <returns></returns>
    public JsonResult GetRegions(string country)
    {
        try
        {
            var regions = new List<object>();

            switch (country?.ToUpper())
            {
                case "TW":
                    regions = GetTaiwanRegions();
                    break;
                case "CN":
                    regions = GetChinaRegions();
                    break;
                default:
                    return Json(new { success = false, message = "無效的國家" });
            }

            return Json(new { success = true, data = regions });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = $"載入行政區資料時發生錯誤: {ex.Message}" });
        }
    }

    /// <summary>
    /// 取得台灣行政區
    /// </summary>
    private List<object> GetTaiwanRegions()
    {
        using var city = new sql_z_bas_city();
        var cityList = city.GetDataList("TW");
        var model = new List<object>();

        foreach (var item in cityList)
        {
            model.Add(new { value = item.mno, text = item.mname });
        }
        return model;
    }

    /// <summary>
    /// 取得中國行政區
    /// </summary>
    private List<object> GetChinaRegions()
    {
        using var city = new sql_z_bas_city();
        var cityList = city.GetDataList("CN");
        var model = new List<object>();

        foreach (var item in cityList)
        {
            model.Add(new { value = item.mno, text = item.mname });
        }
        return model;
    }

    /// <summary>
    /// 取得地圖資料 (AJAX API)
    /// </summary>
    /// <param name="dataSource">資料來源</param>
    /// <param name="country">國家</param>
    /// <param name="region">行政區</param>
    /// <returns></returns>
    public JsonResult GetMapData(string dataSource, string country, string region)
    {
        try
        {
            var data = new List<object>();

            switch (dataSource?.ToUpper())
            {
                case "P":
                    data = GetHerbsData(country, region);
                    break;
                case "F":
                    data = GetSuppliersData(country, region);
                    break;
                case "V":
                    data = GetWarehousesData(country, region);
                    break;
                default:
                    return Json(new { success = false, message = "無效的資料來源" });
            }

            return Json(new { success = true, data = data });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = $"載入資料時發生錯誤: {ex.Message}" });
        }
    }

    /// <summary>
    /// 取得藥草產地資料
    /// </summary>
    /// <param name="country">國家</param>
    /// <param name="region">行政區</param>
    /// <returns></returns>
    private List<object> GetHerbsData(string country, string region)
    {
        // 範例資料，實際應該從資料庫讀取
        var herbsData = new List<object>();
        using var vendor = new sql_z_bas_vendor();
        var model = vendor.GetMapData("P", "");
        foreach (var item in model)
        {
            if (!string.IsNullOrEmpty(item.mapx) && !string.IsNullOrEmpty(item.mapy) &&
                item.mapx != "0" && item.mapy != "0")
            {
                herbsData.Add(new
                {
                    name = item.mname,
                    address = item.maddr,
                    type = "P",
                    description = item.mdescribe,
                    phone = item.mtel,
                    lat = item.mapy,
                    lng = item.mapx
                });
            }
        }
        return herbsData;
    }

    /// <summary>
    /// 取得供應商資料
    /// </summary>
    /// <param name="country">國家</param>
    /// <param name="region">行政區</param>
    /// <returns></returns>
    private List<object> GetSuppliersData(string country, string region)
    {
        var suppliersData = new List<object>();

        if (country == "TW")
        {
            suppliersData.AddRange(new[]
            {
                new { name = "順天堂藥品", address = "台北市中山區", type = "suppliers", description = "中藥材供應商", phone = "02-12345678" },
                new { name = "明通化學製藥", address = "台中市西屯區", type = "suppliers", description = "藥品製造供應", phone = "04-87654321" },
                new { name = "生達製藥", address = "台南市新營區", type = "suppliers", description = "藥品生產供應", phone = "06-12345678" },
                new { name = "港香蘭藥品", address = "桃園市龜山區", type = "suppliers", description = "中藥材批發", phone = "03-87654321" }
            });
        }
        else if (country == "CN")
        {
            suppliersData.AddRange(new[]
            {
                new { name = "順天堂藥品", lat = 25.0738, lng = 121.5319, type = "suppliers", description = "中藥材供應商", phone = "02-12345678" },
                new { name = "明通化學製藥", lat = 24.1659, lng = 120.6478, type = "suppliers", description = "藥品製造供應", phone = "04-87654321" },
                new { name = "生達製藥", lat = 23.3059, lng = 120.3175, type = "suppliers", description = "藥品生產供應", phone = "06-12345678" },
                new { name = "港香蘭藥品", lat = 25.0112, lng = 121.3674, type = "suppliers", description = "中藥材批發", phone = "03-87654321" }
            });
        }

        return suppliersData;
    }

    /// <summary>
    /// 取得倉庫資料
    /// </summary>
    /// <param name="country">國家</param>
    /// <param name="region">行政區</param>
    /// <returns></returns>
    private List<object> GetWarehousesData(string country, string region)
    {
        // 範例資料，實際應該從資料庫讀取
        var herbsData = new List<object>();
        using var vendor = new sql_z_bas_vendor();
        var model = vendor.GetMapData("V", region);
        foreach (var item in model)
        {
            herbsData.Add(new
            {
                name = item.mname,
                address = item.maddr,
                type = "V",
                description = item.mdescribe,
                phone = item.mtel,
                lat = item.mapy,
                lng = item.mapx
            });

        }
        return herbsData;
    }
}
