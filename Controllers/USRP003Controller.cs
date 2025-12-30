using X.PagedList;
using X.PagedList.Extensions;

namespace HerbsTracing.Controllers
{
    public class USRP003Controller : Controller
    {
        public sql_z_sys_security SqlDatas { get; set; } = new sql_z_sys_security();
        public z_sys_security Model { get; set; } = new z_sys_security();

        /// <summary>
        /// 資料初始事件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Init()
        {
            //這裏可以寫入初始程式
            SessionService.PrgNo = "USRP003"; //預設程式編號
            SessionService.PrgName = "帳號權限設定作業"; //預設程式名稱
            SessionService.PageMasterSize = 10; //預設表頭每頁筆數
            SessionService.SearchText = "";
            SessionService.SortColumn = "z_sys_security.prg_no";
            SessionService.SortDirection = "ASC";
            SessionService.StringValue1 = "user";
            SessionService.StringValue2 = "";
            SessionService.StringValue3 = "";

            using var userData = new sql_z_sys_user();
            var userList = userData.GetDropDownListByRole(SessionService.StringValue1, SessionService.StringValue2).FirstOrDefault();
            if (userList != null)
            {
                SessionService.StringValue2 = userList.Value;
                SessionService.StringValue3 = userList.Text;
            }

            //返回資料列表
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
            string userInfo = $"{SessionService.StringValue2} {SessionService.StringValue3}";
            ActionService.SetActionName(enAction.Index);
            ActionService.SetSubActionName(userInfo);
            ActionService.SetActionCardSize(enCardSize.Max);
            //取得資料列表集合
            var model = SqlDatas.GetUserSecuritys(SessionService.StringValue2).ToPagedList(id, pageSize);
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
            if (string.IsNullOrEmpty(id) || id == "0")
            {
                //新增預設值
                Model = new z_sys_security();
                Model.is_enabled = true;
                Model.is_add = true;
                Model.is_edit = true;
                Model.is_delete = true;
                Model.is_print = true;
                Model.is_confirm = true;
            }
            else
            {
                //取得新增或修改的資料結構及資料
                using var sqlData = new sql_z_sys_security();
                Model = sqlData.GetData(id);
            }
            return View(Model);
        }

        /// <summary>
        /// 資料新增或修改存檔
        /// </summary>
        /// <param name="model">使用者輸入的資料模型</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateEdit(z_sys_security model)
        {
            //檢查是否有違反 Metadata 中的 Validation 驗證
            ModelState.Remove("mno");
            ModelState.Remove("rowid");
            if (!ModelState.IsValid) return View(model);
            //執行新增或修改資料
           // using var sqlData = new sql_z_sys_security();
            int rowId = string.IsNullOrEmpty(model.rowid) ? 0 : 1;
            if (rowId == 0) model.rowid = Guid.NewGuid().ToString();
            using var prgData = new sql_z_sys_program();
            var prg = prgData.GetDataByNo(model.prg_no ?? "");
            model.user_no = SessionService.StringValue2;
            model.module_no = prg?.moduleno ?? "";
            model.prg_name  = prg?.mname ?? "";
            model.isenabled = (model.is_enabled) ? "True" : "False";
            model.isadd = (model.is_add) ? "True" : "False";
            model.isedit = (model.is_edit) ? "True" : "False";
            model.isdelete = (model.is_delete) ? "True" : "False";
            model.isprint = (model.is_print) ? "True" : "False";
            model.isconfirm = (model.is_confirm) ? "True" : "False";

            SqlDatas.CreateEdit(model, rowId);
            //返回資料列表
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
            //using var sqlData = new sql_z_sys_security();
            SqlDatas.Delete(id);
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
            //using var sqlData = new sql_z_sys_security();
            SqlDatas.Delete(id);
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
        /// 查詢
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SetUser()
        {
            object obj_text = Request.Form["userModel.mno"];
            SessionService.StringValue2 = (obj_text == null) ? string.Empty : obj_text.ToString();
            SessionService.StringValue3 = "";
            using var userData = new sql_z_sys_user();
            var user = userData.GetDataByNo(SessionService.StringValue2);
            if (user != null)
            {
                SessionService.StringValue3 = user.mname;
            }
            return RedirectToAction(ActionService.Index, ActionService.Controller, new { area = ActionService.Area });
        }

        /// <summary>
        /// 查詢
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SetUserCode()
        {
            object obj_text = Request.Form["userModel.mcode"];
            using  var userData = new sql_z_sys_user();
            SessionService.StringValue1 = (obj_text == null) ? string.Empty : obj_text.ToString();
            var user = userData.GetDataByRoleAndNo(SessionService.StringValue1 , SessionService.StringValue2);
            SessionService.StringValue2 = user.mno;
            SessionService.StringValue3 = user.mname;
            return RedirectToAction(ActionService.Index, ActionService.Controller, new { area = ActionService.Area });
        }
    }
}
