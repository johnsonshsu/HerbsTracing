namespace HerbsTracing.Controllers
{
    public class BASP002Controller : Controller
    {
        /// <summary>
        /// 資料初始事件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Init()
        {
            //這裏可以寫入初始程式
            SessionService.PrgNo = "BASP002"; //預設程式編號
            SessionService.PrgName = "農戶資格審核作業"; //預設程式名稱
            SessionService.PageMasterSize = 10; //預設表頭每頁筆數
            SessionService.SearchText = "";
            SessionService.SortColumn = "z_bas_vendor.mno";
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
            using var sqlData = new sql_z_bas_vendor();
            var model = sqlData.GetUnConfirmDataList();
            ViewBag.PageInfo = "";
            ViewBag.SearchText = SessionService.SearchText;
            return View(model);
        }

        /// <summary>
        /// 資料新增
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            ActionService.SetActionName(enAction.Create);
            return RedirectToAction(ActionService.CreateEdit, ActionService.Controller, new { area = ActionService.Area, id = "0" });
        }

        /// <summary>
        /// 資料修改
        /// </summary>
        /// <param name="id">要修改的Key值</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(string id = "")
        {
            ActionService.SetActionName(enAction.Edit);
            return RedirectToAction(ActionService.CreateEdit, ActionService.Controller, new { area = ActionService.Area, id = id });
        }

        /// <summary>
        /// 資料新增或修改輸入 (id = 0 為新增 , id > 0 為修改)
        /// </summary>
        /// <param name="id">要修改的Key值</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CreateEdit(string id = "")
        {
            //設定目前頁面子動作名稱、動作卡片大小
            ActionService.SetSubActionName();
            ActionService.SetActionCardSize(enCardSize.Medium);
            var model = new z_bas_vendor();
            if (string.IsNullOrEmpty(id) || id == "0")
            {
                //新增預設值
                model.msex = "M"; //性別為男性
            }
            else
            {
                //取得新增或修改的員工資料結構及資料
                using var sqlData = new sql_z_bas_vendor();
                model = sqlData.GetData(id);
            }
            return View(model);
        }

        /// <summary>
        /// 資料新增或修改存檔
        /// </summary>
        /// <param name="model">使用者輸入的資料模型</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateEdit(z_bas_vendor model)
        {
            //檢查是否有違反 Metadata 中的 Validation 驗證
            if (!ModelState.IsValid) return View(model);
            //執行新增或修改資料
            using var sqlData = new sql_z_bas_vendor();
            int rowId = string.IsNullOrEmpty(model.rowid.ToString()) ? 0 : 1;
            sqlData.CreateEdit(model, rowId);
            //返回員工資料列表
            return RedirectToAction(ActionService.Index, ActionService.Controller, new { area = ActionService.Area });
        }

        /// <summary>
        /// 資料刪除
        /// </summary>
        /// <param name="id">要刪除的Key值</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(string id = "")
        {
            //執行刪除資料
            using var sqlData = new sql_z_bas_vendor();
            sqlData.Delete(id);
            //返回員工資料列表
            return RedirectToAction(ActionService.Index, ActionService.Controller, new { area = ActionService.Area });
        }

        /// <summary>
        /// 資料刪除
        /// </summary>
        /// <param name="id">要刪除的Key值</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteRow(string id = "")
        {
            using var sqlData = new sql_z_bas_vendor();
            sqlData.Delete(id);
            var result = new dmJsonMessage() { Mode = true, Message = "資料已刪除!!" };
            return Json(result);
        }

        /// <summary>
        /// 查詢
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Search()
        {
            object obj_text = Request.Form["SearchText"];
            SessionService.SearchText = (obj_text == null) ? string.Empty : obj_text.ToString();
            return RedirectToAction(ActionService.Index, ActionService.Controller, new { area = ActionService.Area });
        }

        /// <summary>
        /// 欄位排序
        /// </summary>
        /// <param name="id">指定排序的欄位</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Sort(string id)
        {
            if (SessionService.SortColumn == id)
            {
                SessionService.SortDirection = (SessionService.SortDirection == "asc") ? "desc" : "asc";
            }
            else
            {
                SessionService.SortColumn = id;
                SessionService.SortDirection = "asc";
            }
            return RedirectToAction(ActionService.Index, ActionService.Controller, new { area = ActionService.Area });
        }

        /// <summary>
        /// 資料審核
        /// </summary>
        /// <param name="id">要刪除的Key值</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Confirm(string id = "")
        {
            //執行刪除資料
            using var sqlData = new sql_z_bas_vendor();
            string vendorInfo = sqlData.Confirm(id);
            TempData["SuccessMessage"] = $"{vendorInfo} 審核成功!!";
            //返回員工資料列表
            return RedirectToAction(ActionService.Index, ActionService.Controller, new { area = ActionService.Area });
        }
    }
}
