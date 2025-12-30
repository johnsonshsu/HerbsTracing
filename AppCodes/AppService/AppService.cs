using System.Reflection;
using Microsoft.AspNetCore.Http;

/// <summary>
/// 應用程式參數類別
/// </summary>
public static class AppService
{
    public static string ProjectName { get { return Assembly.GetCallingAssembly().GetName().Name; } }
    /// <summary>
    /// 應用程式名稱
    /// </summary>
    /// <value></value>
    public static string AppName
    {
        get
        {
            return GetApplicationString("AppName");
        }
    }
    /// <summary>
    /// 應用程式版本
    /// </summary>
    /// <value></value>
    public static string AppVersion
    {
        get
        {
            return GetApplicationString("AppVersion");
        }
    }
    /// <summary>
    /// 應用程式版本
    /// </summary>
    /// <value></value>
    public static string AppDescription
    {
        get
        {
            return GetApplicationString("AppDescription");
        }
    }
    /// <summary>
    /// 應用程式版本
    /// </summary>
    /// <value></value>
    public static string AppKeywords
    {
        get
        {
            return GetApplicationString("AppKeywords");
        }
    }
    /// <summary>
    /// 網站設計者
    /// </summary>
    /// <value></value>
    public static string Designer
    {
        get
        {
            return GetApplicationString("Designer");
        }
    }
    /// <summary>
    /// 系統管理者名稱
    /// </summary>
    /// <value></value>
    public static string AdminName
    {
        get
        {
            return GetApplicationString("AdminName");
        }
    }
    /// <summary>
    /// 系統管理者電子信箱
    /// </summary>
    /// <value></value>
    public static string AdminEmail
    {
        get
        {
            return GetApplicationString("AdminEmail");
        }
    }
    /// <summary>
    /// 除錯模式(開發階段不管權限模式)
    /// </summary>
    /// <value></value>
    public static bool DebugMode
    {
        get
        {
            string str_value = GetApplicationString("DebugMode");
            return (str_value == "1");
        }
    }
    /// <summary>
    /// 登入模式(一進入系統即登入)
    /// </summary>
    /// <value></value>
    public static bool LoginMode
    {
        get
        {
            string str_value = GetApplicationString("LoginMode");
            return (str_value == "1");
        }
    }
    /// <summary>
    /// 後台選單區域名稱
    /// </summary>
    public static string MenuArea { get { return "Menu"; } }
    /// <summary>
    /// 後台選單控制器名稱
    /// </summary>
    /// <value></value>
    public static string MenuController { get { return "Home"; } }
    /// <summary>
    /// 後台選單動作名稱
    /// </summary>
    /// <value></value>
    public static string MenuAction { get { return "Init"; } }
    /// <summary>
    /// 取得連線字串
    /// </summary>
    /// <param name="KeyName">參數名稱</param>
    /// <returns></returns>
    public static string GetApplicationString(string KeyName)
    {
        string str_section = $"Applications:{KeyName}";
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
        var config = builder.Build();
        return config.GetValue<string>(str_section) ?? "";
    }
    /// <summary>
    /// 取得目前使用者的 IP 位址
    /// </summary>
    /// <param name="httpContext">HTTP 內容</param>
    /// <returns>IP 位址字串</returns>
    public static string GetClientIPAddress(HttpContext httpContext)
    {
        string ipAddress = string.Empty;

        // 檢查是否有 X-Forwarded-For 標頭(透過代理伺服器或負載平衡器)
        if (httpContext.Request.Headers.TryGetValue("X-Forwarded-For", out var forwardedFor))
        {
            ipAddress = forwardedFor.ToString().Split(',')[0].Trim();
        }
        // 檢查是否有 X-Real-IP 標頭
        else if (httpContext.Request.Headers.TryGetValue("X-Real-IP", out var realIp))
        {
            ipAddress = realIp.ToString();
        }
        // 取得遠端 IP 位址
        else
        {
            ipAddress = httpContext.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
        }

        return ipAddress;
    }
}
