using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_sys_application : DapperSql<z_sys_application>
    {
        public sql_z_sys_application()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_sys_application.app_name, z_sys_application.app_version";
            DefaultOrderByDirection = "ASC,ASC";
            DropDownValueColumn = "z_sys_application.app_name";
            DropDownTextColumn = "z_sys_application.app_name";
            DropDownOrderColumn = "z_sys_application.app_name ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT z_sys_application.rowid , z_sys_application.app_name , z_sys_application.app_version , 
z_sys_application.footer1 ,  z_sys_application.footer2 , z_sys_application.footer3 , z_sys_application.remark 
FROM z_sys_application 
";
            return str_query;
        }

        public override z_sys_application GetData(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_sys_application.rowid = @id";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("id", id);
            var model = dpr.ReadSingle<z_sys_application>(str_query, parm);
            return model;
        }

        public void CheckApplicationData()
        {
            string str_query = GetSQLSelect();
            var list = dpr.ReadAll<z_sys_application>(str_query);
            if (list.Count == 0)
            {
                z_sys_application model = new z_sys_application();
                model.rowid = Guid.NewGuid().ToString();
                model.app_name = "科達製藥中藥材溯源系統";
                model.app_version = "2025v1";
                model.footer1 = "科達製藥股份有限公司 版權所有 2012 KODA Phamaceutical Co.Ltd. All Rights Reserved.";
                model.footer2 = "地址:桃園縣平鎮市工業三路20-1號 連絡電話:(03)469-6105 連絡信箱:koda@koda.com.tw";
                model.footer3 = "版本建議MS IE6.0以上最佳解析度1024 x 768";
                model.remark = "";
                str_query = @"
INSERT INTO z_sys_application
(rowid,app_name, app_version, footer1, footer2, footer3, remark)
VALUES
(@rowid,@app_name, @app_version, @footer1, @footer2, @footer3, @remark)";
                DynamicParameters parm = dpr.GetSQLInsertParameters(model);
                parm.Add("rowid", model.rowid);
                dpr.Execute(str_query, parm);
            }
        }
    }
}
