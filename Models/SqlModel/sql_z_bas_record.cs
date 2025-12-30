using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_bas_record : DapperSql<z_bas_record>
    {
        public sql_z_bas_record()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_bas_record.mdate";
            DefaultOrderByDirection = "DESC";
            DropDownValueColumn = "z_bas_record.item_no";
            DropDownTextColumn = "z_bas_record.item_no";
            DropDownOrderColumn = "z_bas_record.mdate DESC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT z_bas_record.rowid, z_bas_record.vender_no, z_bas_vendor.mname AS vender_name,
z_bas_record.place_no, z_bas_place.mname AS place_name, z_bas_record.item_no,
z_bas_item.mname AS item_name, z_bas_record.lot_no, z_bas_record.mdate, z_bas_record.mdescribe
FROM  z_bas_record
LEFT OUTER JOIN z_bas_item ON z_bas_record.item_no = z_bas_item.mno
LEFT OUTER JOIN z_bas_place ON z_bas_record.place_no = z_bas_place.mno
LEFT OUTER JOIN z_bas_vendor ON z_bas_record.vender_no = z_bas_vendor.mno
";
            return str_query;
        }

        public string GetPlaceItemLotSQLSelect()
        {
            string str_query = @"
SELECT DISTINCT
z_bas_record.vender_no, z_bas_vendor.mname AS vender_name,
z_bas_record.place_no, z_bas_place.mname AS place_name,
z_bas_record.item_no,z_bas_item.mname AS item_name,
z_bas_record.lot_no , '' AS remark
FROM z_bas_record
LEFT OUTER JOIN z_bas_item ON z_bas_record.item_no = z_bas_item.mno
LEFT OUTER JOIN z_bas_place ON z_bas_record.place_no = z_bas_place.mno
LEFT OUTER JOIN z_bas_vendor ON z_bas_record.vender_no = z_bas_vendor.mno
";
            return str_query;
        }

        public string GetPlaceItemLotSQLOrderBy()
        {
            string str_query = "ORDER BY z_bas_record.place_no ASC, z_bas_record.item_no ASC, z_bas_record.lot_no ASC ";
            return str_query;
        }

        public List<string> GetPlaceItemLotSearchColumns()
        {
            List<string> columns = new List<string>()
            {
                "z_bas_record.vender_no",
                "z_bas_vendor.mname",
                "z_bas_record.place_no",
                "z_bas_place.mname",
                "z_bas_record.item_no",
                "z_bas_item.mname",
                "z_bas_record.lot_no"
            };
            return columns;
        }

        public override z_bas_record GetData(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_bas_record.rowid = @rowid";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("rowid", id);
            var model = dpr.ReadSingle<z_bas_record>(str_query, parm);
            return model;
        }

        public List<z_bas_record> GetPlaceItemLotDataList(string searchString = "")
        {
            List<string> searchColumns = GetPlaceItemLotSearchColumns();
            var model = new List<z_bas_record>();
            string sql_query = GetPlaceItemLotSQLSelect();
            string sql_where = "";
            if (!string.IsNullOrEmpty(searchString) && searchColumns.Count() > 0)
                sql_query += dpr.GetSQLWhereBySearchColumn(EntityObject, searchColumns, sql_where, searchString);
            sql_query += GetPlaceItemLotSQLOrderBy();
            model = dpr.ReadAll<z_bas_record>(sql_query);
            ErrorMessage = dpr.ErrorMessage;
            return model;
        }

        public List<z_bas_record> GetPlaceItemLotDetailList(string searchString = "")
        {
            List<string> searchColumns = GetPlaceItemLotSearchColumns();
            var model = new List<z_bas_record>();
            string sql_query = GetSQLSelect();
            string sql_where = " WHERE place_no = @place_no AND item_no = @item_no AND lot_no = @lot_no ";
            if (!string.IsNullOrEmpty(searchString) && searchColumns.Count() > 0)
                sql_query += dpr.GetSQLWhereBySearchColumn(EntityObject, searchColumns, sql_where, searchString);
            sql_query += " ORDER BY z_bas_record.mdate DESC ";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("@place_no", SessionService.StringValue1);
            parm.Add("@item_no", SessionService.StringValue2);
            parm.Add("@lot_no", SessionService.StringValue3);
            model = dpr.ReadAll<z_bas_record>(sql_query, parm);
            ErrorMessage = dpr.ErrorMessage;
            return model;
        }

    }
}
