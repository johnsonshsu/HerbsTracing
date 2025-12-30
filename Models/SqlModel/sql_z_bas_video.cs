using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_bas_video : DapperSql<z_bas_video>
    {
        public sql_z_bas_video()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_bas_video.mdate ";
            DefaultOrderByDirection = "DESC";
            DropDownValueColumn = "z_bas_video.mfile";
            DropDownTextColumn = "z_bas_video.mtitle";
            DropDownOrderColumn = "z_bas_video.mdate desc";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT z_bas_video.rowid , z_bas_video.mcode , z_bas_video.mdate ,
z_bas_video.mtitle , z_bas_video.mfile , z_bas_video.isenabled ,
CASE WHEN z_bas_video.isenabled = 'True' THEN 1 ELSE 0 END AS misenabled
FROM z_bas_video
";
            return str_query;
        }

        public override z_bas_video GetData(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_bas_video.rowid = @rowid";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("rowid", id);
            var model = dpr.ReadSingle<z_bas_video>(str_query, parm);
            return model;
        }
    }
}
