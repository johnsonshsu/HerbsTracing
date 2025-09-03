/// <summary>
/// 權限控管服務程式
/// </summary>
public static class SecurityService
{
    /// <summary>
    /// 檢查限定模式是否有權限
    /// </summary>
    /// <param name="mode">限定模式</param>
    /// <returns></returns>
    public static bool HasPermission(enSecurityMode mode)
    {
        switch (mode)
        {
            case enSecurityMode.Allow: return true;
            case enSecurityMode.Display: return SessionService.FormSecurity.IsDisplay;
            case enSecurityMode.Add: return SessionService.FormSecurity.IsAdd;
            case enSecurityMode.Edit: return SessionService.FormSecurity.IsEdit;
            case enSecurityMode.AddEdit: return SessionService.FormSecurity.IsAddEdit;
            case enSecurityMode.Delete: return SessionService.FormSecurity.IsDelete;
            case enSecurityMode.Confirm: return SessionService.FormSecurity.IsConfirm;
            case enSecurityMode.Undo: return SessionService.FormSecurity.IsUndo;
            case enSecurityMode.Invalid: return SessionService.FormSecurity.IsInvalid;
            case enSecurityMode.Upload: return SessionService.FormSecurity.IsUpload;
            case enSecurityMode.Download: return SessionService.FormSecurity.IsDownload;
            case enSecurityMode.Print: return SessionService.FormSecurity.IsPrint;
            default: return false;
        }
    }
    /// <summary>
    /// 檢查權限
    /// </summary>
    /// <param name="mode"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public static bool CheckSecurity(enSecurityMode mode, int id = 0)
    {
        //除錯模式無權限問題
        if (AppService.DebugMode) return true;
        //檢查權限
        bool bln_value = false;
        if (mode == enSecurityMode.Display && SessionService.FormSecurity.IsDisplay) bln_value = true;
        if (mode == enSecurityMode.Add && SessionService.FormSecurity.IsAdd) bln_value = true;
        if (mode == enSecurityMode.Edit && SessionService.FormSecurity.IsEdit) bln_value = true;
        if (mode == enSecurityMode.AddEdit && id == 0 && SessionService.FormSecurity.IsAdd) bln_value = true;
        if (mode == enSecurityMode.AddEdit && id > 0 && SessionService.FormSecurity.IsEdit) bln_value = true;
        if (mode == enSecurityMode.Delete && SessionService.FormSecurity.IsDelete) bln_value = true;
        if (mode == enSecurityMode.Confirm && SessionService.FormSecurity.IsConfirm) bln_value = true;
        if (mode == enSecurityMode.Undo && SessionService.FormSecurity.IsUndo) bln_value = true;
        if (mode == enSecurityMode.Invalid && SessionService.FormSecurity.IsInvalid) bln_value = true;
        if (mode == enSecurityMode.Upload && SessionService.FormSecurity.IsUpload) bln_value = true;
        if (mode == enSecurityMode.Download && SessionService.FormSecurity.IsDownload) bln_value = true;
        if (mode == enSecurityMode.Print && SessionService.FormSecurity.IsPrint) bln_value = true;
        return bln_value;
    }

    /// <summary>
    /// 取得權限
    /// </summary>
    /// <returns></returns>
    public static FormSecurity GetSecurity()
    {
        FormSecurity security = new FormSecurity();
        security.IsDisplay = CheckSecurity(enSecurityMode.Display);
        security.IsAdd = CheckSecurity(enSecurityMode.Add);
        security.IsEdit = CheckSecurity(enSecurityMode.Edit);
        security.IsDelete = CheckSecurity(enSecurityMode.Delete);
        security.IsConfirm = CheckSecurity(enSecurityMode.Confirm);
        security.IsUndo = CheckSecurity(enSecurityMode.Undo);
        security.IsInvalid = CheckSecurity(enSecurityMode.Invalid);
        security.IsUpload = CheckSecurity(enSecurityMode.Upload);
        security.IsDownload = CheckSecurity(enSecurityMode.Download);
        security.IsPrint = CheckSecurity(enSecurityMode.Print);
        security.IsAddEdit = (security.IsAdd || security.IsEdit);
        security.IsAddEditDelete = (security.IsAdd || security.IsEdit || security.IsDelete);
        return security;
    }
}

/// <summary>
/// 程式權限
/// </summary>
public class FormSecurity()
{
    public string PrgNo { get; set; } = "";
    public string PrgName { get; set; } = "";
    public string TargetNo { get; set; } = SessionService.UserNo;
    public string CodeNo { get; set; } = "";
    public string CodeName { get; set; } = "";
    public bool IsDisplay { get; set; } = false;
    public bool IsAdd { get; set; } = false;
    public bool IsEdit { get; set; } = false;
    public bool IsAddEdit { get; set; } = false;
    public bool IsAddEditDelete { get; set; } = false;
    public bool IsDelete { get; set; } = false;
    public bool IsConfirm { get; set; } = false;
    public bool IsUndo { get; set; } = false;
    public bool IsInvalid { get; set; } = false;
    public bool IsUpload { get; set; } = false;
    public bool IsDownload { get; set; } = false;
    public bool IsPrint { get; set; } = false;
}