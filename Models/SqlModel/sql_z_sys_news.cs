using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_sys_news : DapperSql<z_sys_news>
    {
        public sql_z_sys_news()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_sys_news.mdate ";
            DefaultOrderByDirection = "DESC";
            DropDownValueColumn = "z_sys_news.mcode";
            DropDownTextColumn = "z_sys_news.mtitle";
            DropDownOrderColumn = "z_sys_news.mcode ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT z_sys_news.rowid , z_sys_news.mcode , z_sys_news.mdate ,  
z_sys_news.mtitle , z_sys_news.mdescribe , z_sys_news.isenabled  ,
substring(z_sys_news.mdescribe, 1, 30) + '...' as mshort_describe 
FROM z_sys_news  
";
            return str_query;
        }

        public override z_sys_news GetData(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_sys_news.rowid = @id";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("id", id);
            var model = dpr.ReadSingle<z_sys_news>(str_query, parm);
            return model;
        }
    }
}