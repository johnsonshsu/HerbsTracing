using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class SecurityAttribute : ActionFilterAttribute
{
    /// <summary>
    /// 程式代號
    /// </summary>
    /// <value></value>
    public string PrgNo { get; set; } = SessionService.PrgNo;

    /// <summary>
    /// 權限模式
    /// </summary>
    public enSecurityMode Mode { get; set; } = enSecurityMode.Allow;

    /// <summary>
    /// 覆寫驗證程式
    /// </summary>
    /// <param name="context"></param>
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        Mode = enSecurityMode.Allow;
        // 不檢查權限
        if (Mode == enSecurityMode.Allow) return;

        // 檢查是否為除錯模式 (除錯模式不管權限問題)
        if (AppService.DebugMode) return;

        // 檢查是否已登入
        if (!SessionService.IsLogin)
        {
            //未登入則自動導向到登入頁
            context.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                            { "controller", "Home" },
                            { "action", "Index" },
                            { "area" , "Menu"}
                });
        }
        else
        {
            //檢查權限
            if (SecurityService.HasPermission(Mode)) return;

            if (Mode == enSecurityMode.Display)
            {
                //權限檢查程式失敗
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                    { "controller", "Home" },
                    { "action", "Index" },
                    { "area" , "Menu"}
                    });
            }
            else
            {
                //權限檢查程式失敗
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                    { "controller", ActionService.Controller },
                    { "action", ActionService.SecurityError },
                    { "area" , ActionService.Area}
                    });
            }
        }
    }
}

