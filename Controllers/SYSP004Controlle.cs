using Microsoft.AspNetCore.Mvc;

namespace herbstracing.Controllers
{
    public class SYSP004Controller : Controller
    {
        /// <summary>
        /// 資料初始事件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Init()
        {
            //這裏可以寫入初始程式
            SessionService.PrgNo = "SYSP004"; //預設程式編號
            SessionService.PrgName = "人工輸入條碼統計圖"; //預設程式名稱
            SessionService.PageMasterSize = 10; //預設表頭每頁筆數
            SessionService.SearchText = "";
            SessionService.SortColumn = "";
            SessionService.SortDirection = "";

            //返回資料列表
            return RedirectToAction(ActionService.Index, ActionService.Controller, new { area = ActionService.Area });
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(SessionService.StringValue1)) SessionService.StringValue1 = DateTime.Today.ToString("yyyy-MM-dd");
            if (string.IsNullOrEmpty(SessionService.StringValue2)) SessionService.StringValue2 = DateTime.Today.ToString("yyyy-MM-dd");
            var model = new dmDateRange();
            model.StartDate = DateTime.Parse(SessionService.StringValue1);
            model.EndDate = DateTime.Parse(SessionService.StringValue2);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(dmDateRange model)
        {
             if (ModelState.IsValid)
            {
                SessionService.StringValue1 = model.StartDate.ToString("yyyy-MM-dd");
                SessionService.StringValue2 = model.EndDate.ToString("yyyy-MM-dd");
            }
            return RedirectToAction(ActionService.Index, ActionService.Controller, new { area = ActionService.Area });
        }

        /// <summary>
        /// 折線圖 01-資料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult ChartData()
        {
            
            DateTime start;
            DateTime end;
            if (!DateTime.TryParse(SessionService.StringValue1, out start)) start = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd"));
            if (!DateTime.TryParse(SessionService.StringValue2, out end)) end = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd"));
            using var iplogModel = new sql_z_sys_iplog();
            iplogModel.GetChartData("Manual" , start , end);
            var result = new
            {
                Title = SessionService.PrgName,
                SubTitle = $"日期範圍：{SessionService.StringValue1} ~ {SessionService.StringValue2}",
                SerialName = new List<string> { "人工輸入條碼統計" },
                Labels = iplogModel.TextData,
                Values = iplogModel.ValueData
            };
            return Json(result);
        }
    }
}
