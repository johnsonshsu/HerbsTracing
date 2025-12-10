using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_bas_test : DapperSql<z_bas_test>
    {
        public sql_z_bas_test()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_bas_test.mno ";
            DefaultOrderByDirection = "ASC";
            DropDownValueColumn = "z_bas_test.mno";
            DropDownTextColumn = "z_bas_test.mname";
            DropDownOrderColumn = "z_bas_test.mno ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT z_bas_test.rowid , z_bas_test.mcode , z_bas_test.mno , z_bas_test.mname , z_bas_test.mename
FROM z_bas_test
";
            return str_query;
        }

        public override z_bas_test GetData(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_bas_test.rowid = @id";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("id", id);
            var model = dpr.ReadSingle<z_bas_test>(str_query, parm);
            return model;
        }

        public z_bas_test GetDataByNo(string testNo)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_bas_test.mno = @mno";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("mno", testNo);
            var model = dpr.ReadSingle<z_bas_test>(str_query, parm);
            return model;
        }

        public List<z_bas_test> GetDataListByCode(string codeNo)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_bas_test.code_no = @code_no";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("code_no", codeNo);
            var model = dpr.ReadAll<z_bas_test>(str_query, parm);
            return model;
        }

        public List<SelectListItem> GetDropDownListByCode(string codeNo)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_bas_test.mcode = @mcode";
            str_query += " ORDER BY z_bas_test.mno ASC";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("mcode", codeNo);
            var models = dpr.ReadAll<z_bas_test>(str_query, parm);
            var model = models.Select(x => new SelectListItem
            {
                Value = x.mno,
                Text = x.mno + " " + x.mname
            }).ToList();
            return model;
        }
    }
}
