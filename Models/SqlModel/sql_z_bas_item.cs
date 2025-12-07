using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_bas_item : DapperSql<z_bas_item>
    {
        public sql_z_bas_item()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_bas_item.mno";
            DefaultOrderByDirection = "ASC";
            DropDownValueColumn = "z_bas_item.mno";
            DropDownTextColumn = "z_bas_item.mname";
            DropDownOrderColumn = "z_bas_item.mno ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT z_bas_item.rowid,z_bas_item.mcode,z_bas_item.mtype,z_bas_item.mno,z_bas_item.mname
,z_bas_item.mename,z_bas_item.munit,z_bas_item.mplace,z_bas_item.mparts,z_bas_item.msource
,z_bas_item.mdescribe,z_bas_item.mremark,z_bas_item.msale,z_bas_item.mprice,z_bas_item.issale
,z_bas_item.ispicture,z_bas_item.pictureurl,z_bas_item.cart_unit,z_bas_item.cart_price
,z_bas_item.cart_undiscount 
FROM z_bas_item 
";
            return str_query;
        }

        public override z_bas_item GetData(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_bas_item.mno = @id";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("id", id);
            var model = dpr.ReadSingle<z_bas_item>(str_query, parm);
            return model;
        }
    }
}