using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_bas_pHPLC : DapperSql<z_bas_pHPLC>
    {
        public sql_z_bas_pHPLC()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_bas_pHPLC.mno ";
            DefaultOrderByDirection = "ASC";
            DropDownValueColumn = "z_bas_pHPLC.mno";
            DropDownTextColumn = "z_bas_pHPLC.mno";
            DropDownOrderColumn = "z_bas_pHPLC.mno ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT z_bas_pHPLC.rowid , z_bas_pHPLC.mno , z_bas_pHPLC.z_bas_item_bom_no
FROM z_bas_pHPLC
";
            return str_query;
        }
    }
}
