using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_sys_module : DapperSql<z_sys_module>
    {
        public sql_z_sys_module()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_sys_module.mcode, z_sys_module.msort,z_sys_module.mno";
            DefaultOrderByDirection = "ASC,ASC,ASC";
            DropDownValueColumn = "z_sys_module.mno";
            DropDownTextColumn = "z_sys_module.mname";
            DropDownOrderColumn = "z_sys_module.mno ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT z_sys_module.rowid , z_sys_module.mcode ,z_sys_module.msort ,  
z_sys_module.mno , z_sys_module.mname ,z_sys_module.isenabled  , 
case when z_sys_module.isenabled = 'True' then 1 else 0 end as is_enabled 
FROM z_sys_module 
";
            return str_query;
        }

        /// <summary>
        /// 取得多筆資料(同步呼叫)
        /// </summary>
        /// <param name="searchString">模糊搜尋文字</param>
        /// <returns></returns>
        public List<z_sys_module> GetEnabledDataList(string searchString)
        {
            List<string> searchColumns = GetSearchColumns();
            DynamicParameters parm = new DynamicParameters();
            var model = new List<z_sys_module>();
            string sql_query = GetSQLSelect();
            string sql_where = " WHERE z_sys_module.isenabled = @isenabled ";
            sql_query += sql_where;
            if (!string.IsNullOrEmpty(searchString) && searchColumns.Count() > 0)
                sql_query += dpr.GetSQLWhereBySearchColumn(EntityObject, searchColumns, sql_where, searchString);
            sql_query += GetSQLOrderBy();
            parm.Add("@isenabled", "True");
            model = dpr.ReadAll<z_sys_module>(sql_query, parm);
            ErrorMessage = dpr.ErrorMessage;
            return model;
        }

        public override z_sys_module GetData(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_sys_module.rowid = @id";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("id", id);
            var model = dpr.ReadSingle<z_sys_module>(str_query, parm);
            return model;
        }
    }
}
