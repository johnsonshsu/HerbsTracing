namespace HerbsTracing.Controllers
{
    public class BASP001Controller : Controller
    {
        /// <summary>
        /// 資料初始事件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Init()
        {
            //這裏可以寫入初始程式
            SessionService.PrgNo = "BASP001"; //預設程式編號
            SessionService.PrgName = "農戶資格申請作業"; //預設程式名稱
            SessionService.PageMasterSize = 10; //預設表頭每頁筆數
            SessionService.SearchText = "";
            SessionService.SortColumn = "Employees.EmpNo";
            SessionService.SortDirection = "ASC";
            //返回員工列表
            return RedirectToAction(ActionService.Index, ActionService.Controller, new { area = ActionService.Area });
        }

        /// <summary>
        /// 資料列表
        /// </summary>
        /// <param name="id">目前頁數</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index(int id = 1)
        {
            //設定目前頁面動作名稱、子動作名稱、動作卡片大小
            ActionService.SetActionName(enAction.Index);
            ActionService.SetSubActionName();
            ActionService.SetActionCardSize(enCardSize.Max);
            //取得資料列表集合
            var model = new z_bas_vendor();
            model.cdate = DateTime.Today;
            model.msex = "M";
            ViewBag.PageInfo = "";
            ViewBag.SearchText = SessionService.SearchText;
            return View(model);
        }

        /// <summary>
        /// 資料新增或修改存檔
        /// </summary>
        /// <param name="model">使用者輸入的資料模型</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(z_bas_vendor model)
        {
            //檢查是否有違反 Metadata 中的 Validation 驗證
            if (!ModelState.IsValid) return View(model);

            //執行新增或修改資料
            using var sqlData = new sql_z_bas_vendor();
            model.rowid = Guid.NewGuid().ToString();
            model.mno = sqlData.GetNewVendorNo();
            model.mstatus = "A"; //設定狀態為申請中
            model.mcode = "F"; //設定廠商類別為農戶
            sqlData.CreateEdit(model, 0);
            TempData["SuccessMessage"] = $"已申請,會員編號為:{model.mno}!!";
            //返回員工資料列表
            return RedirectToAction(ActionService.Index, ActionService.Controller, new { area = ActionService.Area });
        }
    }
}