using System;
using System.Collections.Generic;

namespace herbstracing.Models;

public partial class z_bas_vendor
{
    public string rowid { get; set; } = null!;

    /// <summary>
    /// 農戶帳號
    /// </summary>
    public string mno { get; set; } = null!;

    public string? mcode { get; set; }

    /// <summary>
    /// 農戶姓名
    /// </summary>
    public string? mname { get; set; }

    public string? marea { get; set; }

    public string? mserialno { get; set; }

    public string? mproduct { get; set; }

    /// <summary>
    /// 申請日期
    /// </summary>
    public DateTime? cdate { get; set; }

    /// <summary>
    /// 核准日期
    /// </summary>
    public DateTime? adate { get; set; }

    /// <summary>
    /// 帳號狀態
    /// </summary>
    public string? mstatus { get; set; }

    /// <summary>
    /// 性    別
    /// </summary>
    public string? msex { get; set; }

    /// <summary>
    /// 連絡電話
    /// </summary>
    public string? mtel { get; set; }

    /// <summary>
    /// 傳真號碼
    /// </summary>
    public string? mfax { get; set; }

    /// <summary>
    /// 行動電話
    /// </summary>
    public string? mmobil { get; set; }

    public string? country_no { get; set; }

    public string? province_no { get; set; }

    public string? city_no { get; set; }

    public string? town_no { get; set; }

    public string? road_no { get; set; }

    public string? maddlead { get; set; }

    /// <summary>
    /// 聯絡地址
    /// </summary>
    public string? maddress { get; set; }

    public string? maddr { get; set; }

    /// <summary>
    /// E-MAIL
    /// </summary>
    public string? memail { get; set; }

    /// <summary>
    /// 評估人員
    /// </summary>
    public string? userno { get; set; }

    /// <summary>
    /// 評估日期
    /// </summary>
    public DateTime? vdate { get; set; }

    public string? remark { get; set; }

    public string? mzipno { get; set; }

    public string? msname { get; set; }

    public string? mboss { get; set; }

    public string? mcontactor { get; set; }

    public string? mweburl { get; set; }

    public string? mtime { get; set; }

    public string? msubject { get; set; }

    public string? mskill { get; set; }

    public string? mdescribe { get; set; }

    public string? mpassword { get; set; }

    public string? mapaddr { get; set; }

    public string? mapdesc { get; set; }

    public string? mapx { get; set; }

    public string? mapy { get; set; }

    public string? ismap { get; set; }
}
