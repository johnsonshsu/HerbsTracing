using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_sys_program : DapperSql<z_sys_program>
    {
        public sql_z_sys_program()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_sys_program.moduleno, z_sys_program.msort, z_sys_program.mno ";
            DefaultOrderByDirection = "ASC,ASC,ASC";
            DropDownValueColumn = "z_sys_program.mno";
            DropDownTextColumn = "z_sys_program.mname";
            DropDownOrderColumn = "z_sys_program.mno ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT z_sys_program.rowid, z_sys_program.moduleno, z_sys_module.mname AS module_name, 
z_sys_program.prgcode, z_sys_program.msort, z_sys_program.mno, z_sys_program.mname, 
z_sys_program.urlpath, z_sys_program.urlpage, z_sys_program.isenabled, 
CASE WHEN z_sys_program.isenabled = 'True' THEN 1 ELSE 0 END AS is_enabled 
FROM  z_sys_program 
LEFT OUTER JOIN z_sys_module ON z_sys_program.moduleno = z_sys_module.mno 
";
            return str_query;
        }

        public override z_sys_program GetData(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_sys_program.rowid = @id";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("id", id);
            var model = dpr.ReadSingle<z_sys_program>(str_query, parm);
            return model;
        }

        public z_sys_program GetDataByNo(string no)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_sys_program.mno = @no";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("no", no);
            var model = dpr.ReadSingle<z_sys_program>(str_query, parm);
            return model;
        }

        /// <summary>
        /// 取得多筆資料(同步呼叫)
        /// </summary>
        /// <param name="searchString">模糊搜尋文字</param>
        /// <returns></returns>
        public List<z_sys_program> GetEnabledDataList(string searchString)
        {
            List<string> searchColumns = GetSearchColumns();
            DynamicParameters parm = new DynamicParameters();
            var model = new List<z_sys_program>();
            string sql_query = GetSQLSelect();
            string sql_where = " WHERE z_sys_program.isenabled = @isenabled ";
            sql_query += sql_where;
            if (!string.IsNullOrEmpty(searchString) && searchColumns.Count() > 0)
                sql_query += dpr.GetSQLWhereBySearchColumn(EntityObject, searchColumns, sql_where, searchString);
            sql_query += " ORDER BY z_sys_program.moduleno , z_sys_program.msort , z_sys_program.mno ";
            parm.Add("@isenabled", "True");
            model = dpr.ReadAll<z_sys_program>(sql_query, parm);
            ErrorMessage = dpr.ErrorMessage;
            return model;
        }
    }
}
