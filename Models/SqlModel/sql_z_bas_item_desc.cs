using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_bas_item_desc : DapperSql<z_bas_item_desc>
    {
        public sql_z_bas_item_desc()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_bas_item_desc.msort ";
            DefaultOrderByDirection = "ASC";
            DropDownValueColumn = "z_bas_item_desc.mname";
            DropDownTextColumn = "z_bas_item_desc.mname";
            DropDownOrderColumn = "z_bas_item_desc.msort ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT z_bas_item_desc.rowid, z_bas_item_desc.msort, z_bas_item_desc.mname,
z_bas_item_desc.mbase, z_bas_item_desc.morigion, z_bas_item_desc.mplace,
z_bas_item_desc.mfix, z_bas_item_desc.mtested, z_bas_item_desc.mfuntion
FROM z_bas_item_desc
";
            return str_query;
        }

        public override z_bas_item_desc GetData(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_bas_item_desc.rowid = @id";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("id", id);
            var model = dpr.ReadSingle<z_bas_item_desc>(str_query, parm);
            return model;
        }
    }
}
