using Microsoft.AspNetCore.Mvc;

namespace HerbsTracing.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// 登出系統
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Logout()
        {
            SessionService.IsLogin = false;
            return RedirectToAction("Login", "User", new { area = "" });
        }

        /// <summary>
        /// 登入系統
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            SessionService.IsLogin = false;
            ActionService.SetActionName(enAction.Login);
            ActionService.SetSubActionName();
            ActionService.SetActionCardSize(enCardSize.Small);
            vmLogin model = new vmLogin();
            return View(model);
        }

        /// <summary>
        /// 登入系統
        /// </summary>
        /// <param name="model">使用者輸入的資料模型</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(vmLogin model)
        {
            if (!ModelState.IsValid) return View(model);
            using var user = new sql_z_sys_user();
            if (!user.CheckLogin(model))
            {
                ModelState.AddModelError("UserNo", "登入帳號或密碼輸入不正確!!");
                model.UserNo = "";
                model.Password = "";
                return View(model);
            }

            //設定登入狀態
            string clientIP = AppService.GetClientIPAddress(HttpContext);
            using var iplog = new sql_z_sys_iplog();
            iplog.LogIP("Login","" , "" ,clientIP);

            //判斷使用者角色，進入不同的首頁
            var data = user.GetDataByNo(model.UserNo);
            if (data.roleno == "user" || data.roleno == "admin" || data.roleno == "boss")
                return RedirectToAction(ActionService.Index, "Admin", new { area = ActionService.Area });

            //角色不正確,引發自定義錯誤,並重新輸入
            ModelState.AddModelError("UserNo", "登入帳號角色設定不正確!!");
            model.UserNo = "";
            model.Password = "";
            return View(model);
        }
    }
}
