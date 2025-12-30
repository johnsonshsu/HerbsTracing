using Microsoft.AspNetCore.Mvc;

namespace HerbsTracing.Controllers
{
    public class TracingController : Controller
    {
        [HttpGet]
        public IActionResult Search(string id = "")
        {
            string str_code = string.IsNullOrEmpty(id) ? "Manual" : "Mobile";
            string str_id = string.IsNullOrEmpty(id) ? SessionService.SearchText : id;
            SessionService.SearchText = "";

            TracingService.TracingCode = str_id;
            var tracingService = new TracingService();
            var errorMessage = tracingService.CheckTracingCode(str_id);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                TempData["ErrorMessage"] = errorMessage;
                return RedirectToAction(ActionService.Index, ActionService.Home, new { area = ActionService.Area });
            }

            //設定登入狀態
            string clientIP = AppService.GetClientIPAddress(HttpContext);
            using var iplog = new sql_z_sys_iplog();
            iplog.LogIP(str_code,str_id , "" ,clientIP);
            return View();
        }

        [HttpGet]
        public IActionResult Language(string id = "")
        {
            SessionService.LanguageNo = id;
            return RedirectToAction(ActionService.Index, ActionService.Controller, new { area = ActionService.Area });
        }


        [HttpGet]
        public IActionResult Index()
        {
            var tracingService = new TracingService();
            var model = tracingService.GetTracingIndexData(TracingService.TracingCode, "", "");
            model.TracingHead.ActionName = "Index";
            return View(model);
        }

        /// <summary>
        /// 藥材溯源碼詳細資訊
        /// </summary>
        /// <param name="id">藥材編號</param>
        /// <returns></returns>
        public IActionResult Detail(string id)
        {
            var tracingService = new TracingService();
            var model = tracingService.GetTracingIndexData(TracingService.TracingCode, id, "");

            model.TracingHead.ActionName = "Index";
            TracingService.ItemSubNo = id;
            tracingService.SetMaterialInfo();
            return View(model);
        }

        /// <summary>
        /// 藥材產地資訊
        /// </summary>
        /// <param name="id">藥材編號</param>
        /// <returns></returns>
        public IActionResult Place(string id)
        {
            var tracingService = new TracingService();
            var model = tracingService.GetTracingIndexData(TracingService.TracingCode, id, "");

            model.TracingHead.ActionName = "Index";
            TracingService.ItemSubNo = id;
            tracingService.SetMaterialInfo();
            return View(model);
        }

        /// <summary>
        /// 推薦銷售據點
        /// </summary>
        /// <returns></returns>
        public IActionResult Recommend(string id = "")
        {
            var tracingService = new TracingService();
            var model = tracingService.GetTracingIndexData(TracingService.TracingCode, "", id);
            ViewBag.CityNo = TracingService.CityNo;
            model.TracingHead.ActionName = "Recommend";
            return View(model);
        }
    }
}
