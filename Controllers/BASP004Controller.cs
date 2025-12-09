using X.PagedList;
using X.PagedList.Extensions;

namespace HerbsTracing.Controllers
{
    public class BASP004Controller : Controller
    {
        /// <summary>
        /// 資料初始事件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Init()
        {
            //這裏可以寫入初始程式
            SessionService.PrgNo = "BASP004"; //預設程式編號
            SessionService.PrgName = "產地基本資料維護"; //預設程式名稱
            SessionService.PageMaster = 1;
            SessionService.PageMasterSize = 10; //預設表頭每頁筆數
            SessionService.BaseNo = ""; //預設選取的主檔編號
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
            //設定參數
            int pageSize = 10;
            //設定目前頁面動作名稱、子動作名稱、動作卡片大小
            ActionService.SetActionName(enAction.Index);
            ActionService.SetSubActionName();
            ActionService.SetActionCardSize(enCardSize.Max);
            //取得資料列表集合
            using var sqlData = new sql_z_bas_vendor();
            //農戶(F)且已核准(B)
            var model = sqlData.GetDataListByCode("F", "B", SessionService.SearchText).ToPagedList(id, pageSize);
            if (string.IsNullOrEmpty(SessionService.BaseNo)) SessionService.BaseNo = model.FirstOrDefault()?.mno ?? "";
            SessionService.PageMaster = id;
            ViewBag.PageInfo = $"( {id} / {model.PageCount} )";
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
                model.mno = ""; //廠商編號
                model.mcode = "F"; //廠商類別為農戶
                model.mstatus = "B"; //預設狀態為待審核
                model.ismap = "FALSE"; //預設不顯示在地圖上
                model.msex = "M"; //性別為男性
                model.cdate = DateTime.Today; //建立日期為今天
                model.adate = DateTime.Today; //異動日期為今天
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
            if (string.IsNullOrEmpty(model.mno)) model.mno = sqlData.GetNewVendorNo();
            int rowId = string.IsNullOrEmpty(model.rowid.ToString()) ? 0 : 1;
            if (rowId == 0) model.rowid = Guid.NewGuid().ToString();
            model.ismap = model.isshowmap ? "TRUE" : "FALSE";
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

        [HttpGet]
        public IActionResult Select(string id)
        {
            SessionService.BaseNo = id;
            return RedirectToAction(ActionService.Index, ActionService.Controller, new { area = ActionService.Area, id = SessionService.PageMaster });
        }

        /// <summary>
        /// 查詢
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Place()
        {
            object obj_text = Request.Form["placeNo"];
            SessionService.CategoryNo = (obj_text == null) ? string.Empty : obj_text.ToString();
            return RedirectToAction(ActionService.Index, ActionService.Controller, new { area = ActionService.Area });
        }

        /// <summary>
        /// 查詢
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult NewPlace()
        {
            SessionService.CategoryNo = "new";
            return RedirectToAction(ActionService.Index, ActionService.Controller, new { area = ActionService.Area });
        }

        /// <summary>
        /// 查詢
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PlaceData()
        {
            object obj_mno = Request.Form["txtMno"];
            object obj_mname = Request.Form["txtMname"];
            object obj_maddress = Request.Form["txtMaddress"];
            object obj_emaddress = Request.Form["txteMaddress"];
            object obj_area_type = Request.Form["txtAreaType"];
            object obj_earea_type = Request.Form["txteAreaType"];
            object obj_mhight = Request.Form["txtMheight"];
            object obj_emhight = Request.Form["txteMheight"];
            object obj_marea = Request.Form["txtMarea"];
            object obj_emarea = Request.Form["txteMarea"];
            object obj_mtemperature = Request.Form["txtMtemperature"];
            object obj_emtemperature = Request.Form["txteMtemperature"];
            object obj_mrain = Request.Form["txtMrain"];
            object obj_emrain = Request.Form["txteMrain"];
            object obj_mfrost = Request.Form["txtMfrost"];
            object obj_emfrost = Request.Form["txteMfrost"];
            object obj_temp_height = Request.Form["txtTempHeight"];
            object obj_etemp_height = Request.Form["txteTempHeight"];
            object obj_temp_low = Request.Form["txtTempLow"];
            object obj_etemp_low = Request.Form["txteTempLow"];
            object obj_mwater = Request.Form["txtMWater"];
            object obj_emwater = Request.Form["txteMWater"];
            object obj_menvironment = Request.Form["txtMenvironment"];
            object obj_emenvironment = Request.Form["txteMenvironment"];
            object obj_ismap = Request.Form["cbxIsMap"];
            object obj_mapx = Request.Form["txtMmapx"];
            object obj_mapy = Request.Form["txtMmapy"];
            object obj_mapaddr = Request.Form["txtMapAddr"];
            object obj_mapdesc = Request.Form["txtMapDesc"];

            var modelPlace = new z_bas_place();
            modelPlace.mno = (obj_mno == null) ? "" : obj_mno.ToString();
            modelPlace.mname = (obj_mname == null) ? "" : obj_mname.ToString();
            modelPlace.maddress = (obj_maddress == null) ? "" : obj_maddress.ToString();
            modelPlace.emaddress = (obj_emaddress == null) ? "" : obj_emaddress.ToString();
            modelPlace.area_type = (obj_area_type == null) ? "" : obj_area_type.ToString();
            modelPlace.earea_type = (obj_earea_type == null) ? "" : obj_earea_type.ToString();
            modelPlace.mhight = (obj_mhight == null) ? "" : obj_mhight.ToString();
            modelPlace.emhight = (obj_emhight == null) ? "" : obj_emhight.ToString();
            modelPlace.marea = (obj_marea == null) ? "" : obj_marea.ToString();
            modelPlace.emarea = (obj_emarea == null) ? "" : obj_emarea.ToString();
            modelPlace.mtemperature = (obj_mtemperature == null) ? "" : obj_mtemperature.ToString();
            modelPlace.emtemperature = (obj_emtemperature == null) ? "" : obj_emtemperature.ToString();
            modelPlace.mrain = (obj_mrain == null) ? "" : obj_mrain.ToString();
            modelPlace.emrain = (obj_emrain == null) ? "" : obj_emrain.ToString();
            modelPlace.mfrost = (obj_mfrost == null) ? "" : obj_mfrost.ToString();
            modelPlace.emfrost = (obj_emfrost == null) ? "" : obj_emfrost.ToString();
            modelPlace.temp_height = (obj_temp_height == null) ? "" : obj_temp_height.ToString();
            modelPlace.etemp_height = (obj_etemp_height == null) ? "" : obj_etemp_height.ToString();
            modelPlace.temp_low = (obj_temp_low == null) ? "" : obj_temp_low.ToString();
            modelPlace.etemp_low = (obj_etemp_low == null) ? "" : obj_etemp_low.ToString();
            modelPlace.mwater = (obj_mwater == null) ? "" : obj_mwater.ToString();
            modelPlace.emwater = (obj_emwater == null) ? "" : obj_emwater.ToString();
            modelPlace.menvironment = (obj_menvironment == null) ? "" : obj_menvironment.ToString();
            modelPlace.emenvironment = (obj_emenvironment == null) ? "" : obj_emenvironment.ToString();
            modelPlace.ismap = (obj_ismap == null) ? "FALSE" : "TRUE";
            modelPlace.mapx = (obj_mapx == null) ? "" : obj_mapx.ToString();
            modelPlace.mapy = (obj_mapy == null) ? "" : obj_mapy.ToString();
            modelPlace.mapaddr = (obj_mapaddr == null) ? "" : obj_mapaddr.ToString();
            modelPlace.mapdesc = (obj_mapdesc == null) ? "" : obj_mapdesc.ToString();

            using var sqlData = new sql_z_bas_place();
            sqlData.UpdatePlaceData(modelPlace);
            return RedirectToAction(ActionService.Index, ActionService.Controller, new { area = ActionService.Area });
        }

        /// <summary>
        /// 上傳員工照片
        /// </summary>
        /// <param name="id">員工 Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PhotoUpload(int id)
        {
            SessionService.StringValue1 = id.ToString();
            return View();
        }

        /// <summary>
        /// 儲存上傳的員工照片
        /// </summary>
        /// <param name="file">員工照片檔案物件</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PhotoUpload(IFormFile file)
        {
            SessionService.SubActionName = "";
            if (file != null && file.Length > 0)
            {
                // 取得目前專案資料夾目錄路徑
                string FileNameOnServer = Directory.GetCurrentDirectory();
                // 專案目錄路徑
                string WebFolder = Path.Combine(FileNameOnServer, "wwwroot\\images\\Place");
                // 存入的檔案名稱, 以員工編號.jpg 存入
                string FileName = $"{SessionService.CategoryNo}_{SessionService.StringValue1}.jpg";
                // 專案路徑加入要存入的資料夾路徑
                string FilePathName = Path.Combine(WebFolder, FileName);
                try
                {
                    // 刪除已存在檔案
                    if (System.IO.File.Exists(FilePathName)) System.IO.File.Delete(FilePathName);
                    // 建立一個串流物件
                    using var stream = System.IO.File.Create(FilePathName);
                    // 將檔案寫入到此串流物件中
                    file.CopyTo(stream);
                }
                catch (Exception ex)
                {
                    // 無法刪除時顯示錯誤訊息
                    TempData["MessageText"] = ex.Message;
                }
            }
            return RedirectToAction(ActionService.Index, ActionService.Controller, new { area = ActionService.Area, id = SessionService.PageMaster });
        }

    }
}
