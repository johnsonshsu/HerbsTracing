using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_bas_test_item : DapperSql<z_bas_test_item>
    {
        public sql_z_bas_test_item()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_bas_test_item.seq ";
            DefaultOrderByDirection = "ASC";
            DropDownValueColumn = "z_bas_test_item.test_no";
            DropDownTextColumn = "z_bas_test_item.test_no";
            DropDownOrderColumn = "z_bas_test_item.seq ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT z_bas_test_item.test_no, z_bas_test.mname AS test_name,
z_bas_test_item.rowid, z_bas_test_item.mcode, z_bas_test_item.seq
FROM  z_bas_test_item
LEFT OUTER JOIN z_bas_test ON z_bas_test_item.test_no = z_bas_test.mno
";
            return str_query;
        }

        public override z_bas_test_item GetData(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_bas_test_item.rowid = @id";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("id", id);
            var model = dpr.ReadSingle<z_bas_test_item>(str_query, parm);
            return model;
        }

        public List<z_bas_test_item> GetDataListByCode(string codeNo)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_bas_test_item.mcode = @mcode";
            str_query += " ORDER BY z_bas_test_item.seq";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("mcode", codeNo);
            var model = dpr.ReadAll<z_bas_test_item>(str_query, parm);
            return model;
        }
    }
}
