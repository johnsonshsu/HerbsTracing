using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace herbstracing.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            SessionService.PrgNo = ""; //預設程式編號
            SessionService.PrgName = "後台管理首頁"; //預設程式名稱
            SessionService.StringValue1 = "";
            SessionService.StringValue2 = "";
            SessionService.StringValue3 = "";
            ActionService.SetActionName(enAction.None);
            ActionService.SetSubActionName();
            ActionService.SetActionCardSize(enCardSize.Max);
            return View();
        }
    }
}
