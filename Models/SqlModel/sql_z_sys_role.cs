using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_sys_role : DapperSql<z_sys_role>
    {
        public sql_z_sys_role()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_sys_role.msort, z_sys_role.mno ";
            DefaultOrderByDirection = "ASC,ASC";
            DropDownValueColumn = "z_sys_role.mno";
            DropDownTextColumn = "z_sys_role.mname";
            DropDownOrderColumn = "z_sys_role.mno ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT z_sys_role.rowid , z_sys_role.mno , z_sys_role.mname ,
z_sys_role.msort ,  z_sys_role.isenabled  , case when z_sys_role.isenabled = 'True' then 1 else 0 end as isenable 
FROM z_sys_role 
";
            return str_query;
        }

        public override z_sys_role GetData(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_sys_role.rowid = @id";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("id", id);
            var model = dpr.ReadSingle<z_sys_role>(str_query, parm);
            return model;
        }
    }
}
