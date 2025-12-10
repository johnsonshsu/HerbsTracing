using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_qcm_environment_d : DapperSql<z_qcm_environment_d>
    {
        public sql_z_qcm_environment_d()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_qcm_environment_d.seq ";
            DefaultOrderByDirection = "ASC";
            DropDownValueColumn = "z_qcm_environment_d.test_no";
            DropDownTextColumn = "z_qcm_environment_d.test_no";
            DropDownOrderColumn = "z_qcm_environment_d.test_no ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public List<z_qcm_environment_d> GetDataList(string codeNo , string mno , string searchString = "")
        {
            List<string> searchColumns = GetSearchColumns();
            var model = new List<z_qcm_environment_d>();
            string sql_query = GetSQLSelect();
            string sql_where = " WHERE z_qcm_environment_d.mcode = @mcode AND z_qcm_environment_d.mno = @mno ";
            sql_query += sql_where;
            if (!string.IsNullOrEmpty(searchString) && searchColumns.Count() > 0)
                sql_query += dpr.GetSQLWhereBySearchColumn(EntityObject, searchColumns, sql_where, searchString);
            sql_query += GetSQLOrderBy();
            DynamicParameters parm = new DynamicParameters();
            parm.Add("@mcode", codeNo);
            parm.Add("@mno", mno);
            if (parm.ParameterNames.Count() > 0)
                model = dpr.ReadAll<z_qcm_environment_d>(sql_query, parm);
            else
                model = dpr.ReadAll<z_qcm_environment_d>(sql_query);
            ErrorMessage = dpr.ErrorMessage;
            return model;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT  z_qcm_environment_d.rowid, z_qcm_environment_d.mcode,
z_qcm_environment_d.mno, z_qcm_environment_d.seq,
z_qcm_environment_d.test_no, z_bas_test.mname AS test_name,
z_qcm_environment_d.test_value, z_qcm_environment_d.stand_value
FROM  z_qcm_environment_d
LEFT OUTER JOIN z_bas_test ON z_qcm_environment_d.test_no = z_bas_test.mno AND
z_qcm_environment_d.mcode = z_bas_test.mcode
";
            return str_query;
        }

        public override z_qcm_environment_d GetData(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_qcm_environment_d.rowid = @id";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("id", id);
            var model = dpr.ReadSingle<z_qcm_environment_d>(str_query, parm);
            return model;
        }
    }
}
