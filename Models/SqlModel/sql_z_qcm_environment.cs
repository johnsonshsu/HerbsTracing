using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_qcm_environment : DapperSql<z_qcm_environment>
    {
        public sql_z_qcm_environment()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_qcm_environment.mno ";
            DefaultOrderByDirection = "DESC";
            DropDownValueColumn = "z_qcm_environment.mno";
            DropDownTextColumn = "z_qcm_environment.mno";
            DropDownOrderColumn = "z_qcm_environment.mno ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT  z_qcm_environment.rowid, z_qcm_environment.mcode, z_qcm_environment.mno,
z_qcm_environment.user_no, z_bas_vendor.mname AS user_name, z_qcm_environment.place_no,
z_bas_place.mname AS place_name, z_qcm_environment.lot_no, z_qcm_environment.mdate,
z_qcm_environment.sdate, z_qcm_environment.handle_no, z_qcm_environment.remark,
z_qcm_environment.isconfirm
FROM z_qcm_environment
LEFT OUTER JOIN z_bas_place ON z_qcm_environment.place_no = z_bas_place.mno
LEFT OUTER JOIN z_bas_vendor ON z_qcm_environment.user_no = z_bas_vendor.mno
";
            return str_query;
        }

        public List<z_qcm_environment> GetDataList(string codeNo , string searchString = "")
        {
            List<string> searchColumns = GetSearchColumns();
            var model = new List<z_qcm_environment>();
            string sql_query = GetSQLSelect();
            string sql_where = " WHERE z_qcm_environment.mcode = @mcode AND z_qcm_environment.isconfirm = @isconfirm ";
            sql_query += sql_where;
            if (!string.IsNullOrEmpty(searchString) && searchColumns.Count() > 0)
                sql_query += dpr.GetSQLWhereBySearchColumn(EntityObject, searchColumns, sql_where, searchString);
            sql_query += GetSQLOrderBy();
            DynamicParameters parm = new DynamicParameters();
            parm.Add("@mcode", codeNo);
            parm.Add("@isconfirm", "True");
            if (parm.ParameterNames.Count() > 0)
                model = dpr.ReadAll<z_qcm_environment>(sql_query, parm);
            else
                model = dpr.ReadAll<z_qcm_environment>(sql_query);
            ErrorMessage = dpr.ErrorMessage;
            return model;
        }

        public override z_qcm_environment GetData(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_qcm_environment.rowid = @id";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("id", id);
            var model = dpr.ReadSingle<z_qcm_environment>(str_query, parm);
            return model;
        }
    }
}
