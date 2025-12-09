using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_bas_recipes : DapperSql<z_bas_recipes>
    {
        public sql_z_bas_recipes()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_bas_recipes.msort ";
            DefaultOrderByDirection = "ASC";
            DropDownValueColumn = "z_bas_recipes.mname";
            DropDownTextColumn = "z_bas_recipes.mname";
            DropDownOrderColumn = "z_bas_recipes.msort ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT z_bas_recipes.rowid, z_bas_recipes.mcode, z_bas_recipes.msort, z_bas_recipes.mname,
z_bas_recipes.material, z_bas_recipes.care, z_bas_recipes.effect,
CASE WHEN z_bas_recipes.mcode = 'A' THEN '養生茶飲'
     WHEN z_bas_recipes.mcode = 'B' THEN '養生藥膳'
     ELSE '' END AS mcode_name,
'~/images/photo/' + CAST(z_bas_recipes.rowid AS nvarchar(50)) + '_1.jpg?' + CAST( @@TIMETICKS as nvarchar(50)) AS file1,
'~/images/photo/' + CAST(z_bas_recipes.rowid AS nvarchar(50)) + '_2.jpg?' + CAST( @@TIMETICKS as nvarchar(50)) AS file2
FROM z_bas_recipes
";
            return str_query;
        }

        public List<z_bas_recipes> GetDataListByCode(string codeNo)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_bas_recipes.mcode = @mcode ORDER BY z_bas_recipes.msort ASC";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("mcode", codeNo);
            var model = dpr.ReadAll<z_bas_recipes>(str_query, parm);
            return model;
        }

        public override z_bas_recipes GetData(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_bas_recipes.rowid = @id";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("id", id);
            var model = dpr.ReadSingle<z_bas_recipes>(str_query, parm);
            return model;
        }
    }
}
