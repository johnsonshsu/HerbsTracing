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
        ViewBag.PageInfo = $"( {id} / {model.PageCount} )";
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
    /// 檢驗中心
    /// </summary>
    /// <returns></returns> 
    public IActionResult Tester()
    {
        return View();
    }

    /// <summary>
    /// 取得地圖資料 (AJAX API)
    /// </summary>
    /// <param name="dataSource">資料來源</param>
    /// <param name="searchType">搜尋類型</param>
    /// <returns></returns>
    public JsonResult GetMapData(string dataSource, string searchType)
    {
        try
        {
            var data = new List<object>();

            switch (dataSource?.ToLower())
            {
                case "P":
                    data = GetHerbsData(searchType);
                    break;
                case "F":
                    data = GetSuppliersData(searchType);
                    break;
                case "V":
                    data = GetWarehousesData(searchType);
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
    /// <param name="searchType">搜尋類型</param>
    /// <returns></returns>
    private List<object> GetHerbsData(string searchType)
    {
        // 範例資料，實際應該從資料庫讀取
        var herbsData = new List<object>();

        if (searchType == "address")
        {
            herbsData.AddRange(new[]
            {
                new { name = "台灣當歸產地", address = "花蓮縣秀林鄉", type = "herbs", description = "優質當歸種植區", phone = "03-1234567" },
                new { name = "紅棗種植園", address = "苗栗縣公館鄉", type = "herbs", description = "有機紅棗栽培", phone = "037-123456" },
                new { name = "何首烏農場", address = "南投縣魚池鄉", type = "herbs", description = "傳統何首烏種植", phone = "049-123456" },
                new { name = "甘草種植區", address = "台中市新社區", type = "herbs", description = "甘草專業栽培", phone = "04-12345678" },
                new { name = "枸杞農園", address = "嘉義縣阿里山鄉", type = "herbs", description = "高海拔枸杞種植", phone = "05-1234567" }
            });
        }
        else if (searchType == "coordinates")
        {
            herbsData.AddRange(new[]
            {
                new { name = "台灣當歸產地", lat = 24.1569, lng = 121.6739, type = "herbs", description = "優質當歸種植區", phone = "03-1234567" },
                new { name = "紅棗種植園", lat = 24.5152, lng = 120.8298, type = "herbs", description = "有機紅棗栽培", phone = "037-123456" },
                new { name = "何首烏農場", lat = 23.8577, lng = 120.9368, type = "herbs", description = "傳統何首烏種植", phone = "049-123456" },
                new { name = "甘草種植區", lat = 24.1951, lng = 120.8072, type = "herbs", description = "甘草專業栽培", phone = "04-12345678" },
                new { name = "枸杞農園", lat = 23.5081, lng = 120.8056, type = "herbs", description = "高海拔枸杞種植", phone = "05-1234567" }
            });
        }

        return herbsData;
    }

    /// <summary>
    /// 取得供應商資料
    /// </summary>
    /// <param name="searchType">搜尋類型</param>
    /// <returns></returns>
    private List<object> GetSuppliersData(string searchType)
    {
        var suppliersData = new List<object>();

        if (searchType == "address")
        {
            suppliersData.AddRange(new[]
            {
                new { name = "順天堂藥品", address = "台北市中山區", type = "suppliers", description = "中藥材供應商", phone = "02-12345678" },
                new { name = "明通化學製藥", address = "台中市西屯區", type = "suppliers", description = "藥品製造供應", phone = "04-87654321" },
                new { name = "生達製藥", address = "台南市新營區", type = "suppliers", description = "藥品生產供應", phone = "06-12345678" },
                new { name = "港香蘭藥品", address = "桃園市龜山區", type = "suppliers", description = "中藥材批發", phone = "03-87654321" }
            });
        }
        else if (searchType == "coordinates")
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
    /// <param name="searchType">搜尋類型</param>
    /// <returns></returns>
    private List<object> GetWarehousesData(string searchType)
    {
        var warehousesData = new List<object>();

        if (searchType == "address")
        {
            warehousesData.AddRange(new[]
            {
                new { name = "台北物流中心", address = "新北市五股區", type = "warehouses", description = "北部配送中心", phone = "02-22334455" },
                new { name = "台中倉儲中心", address = "台中市烏日區", type = "warehouses", description = "中部儲存倉庫", phone = "04-23456789" },
                new { name = "高雄配送中心", address = "高雄市鳳山區", type = "warehouses", description = "南部物流據點", phone = "07-12345678" },
                new { name = "桃園國際倉", address = "桃園市大園區", type = "warehouses", description = "國際貿易倉庫", phone = "03-33445566" }
            });
        }
        else if (searchType == "coordinates")
        {
            warehousesData.AddRange(new[]
            {
                new { name = "台北物流中心", lat = 25.0838, lng = 121.4639, type = "warehouses", description = "北部配送中心", phone = "02-22334455" },
                new { name = "台中倉儲中心", lat = 24.1042, lng = 120.6235, type = "warehouses", description = "中部儲存倉庫", phone = "04-23456789" },
                new { name = "高雄配送中心", lat = 22.6273, lng = 120.3014, type = "warehouses", description = "南部物流據點", phone = "07-12345678" },
                new { name = "桃園國際倉", lat = 25.0569, lng = 121.2319, type = "warehouses", description = "國際貿易倉庫", phone = "03-33445566" }
            });
        }

        return warehousesData;
    }
}
