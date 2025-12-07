using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_bas_item_bom : DapperSql<z_bas_item_bom>
    {
        public sql_z_bas_item_bom()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_bas_item_bom.mno ";
            DefaultOrderByDirection = "ASC";
            DropDownValueColumn = "z_bas_item_bom.mno";
            DropDownTextColumn = "z_bas_item_bom.mno";
            DropDownOrderColumn = "z_bas_item_bom.mno ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT  z_bas_item_bom.rowid, z_bas_item_bom.parentid, z_bas_item_bom.mno, z_bas_item.mname, z_bas_item_bom.item_no
FROM  z_bas_item_bom 
INNER JOIN z_bas_item ON z_bas_item_bom.mno = z_bas_item.mno 
";
            return str_query;
        }

        public override string GetSQLWhere()
        {
            string str_query = " WHERE z_bas_item_bom.item_no = @item_no";
            return str_query;
        }

        /// <summary>
        /// 取得多筆資料(同步呼叫)
        /// </summary>
        /// <param name="itemNo">品項編號</param>
        /// <param name="searchString">模糊搜尋文字</param>
        /// <returns></returns>
        public List<z_bas_item_bom> GetDataList(string itemNo, string searchString)
        {
            DynamicParameters parm = new DynamicParameters();
            var model = GetDataList(itemNo, parm, searchString);
            return model;
        }

        /// <summary>
        /// 取得多筆資料(同步呼叫)
        /// </summary>
        /// <param name="itemNo">品項編號</param>
        /// <param name="parm">參數</param>
        /// <param name="searchString">模糊搜尋文字</param>
        /// <returns></returns>
        public List<z_bas_item_bom> GetDataList(string itemNo, DynamicParameters parm, string searchString)
        {
            List<string> searchColumns = GetSearchColumns();
            var model = new List<z_bas_item_bom>();
            string sql_query = GetSQLSelect();
            string sql_where = GetSQLWhere();
            sql_query += sql_where;
            if (!string.IsNullOrEmpty(searchString) && searchColumns.Count() > 0)
                sql_query += dpr.GetSQLWhereBySearchColumn(EntityObject, searchColumns, sql_where, searchString);
            sql_query += GetSQLOrderBy();
            parm.Add("@item_no", itemNo);
            if (parm.ParameterNames.Count() > 0)
                model = dpr.ReadAll<z_bas_item_bom>(sql_query, parm);
            else
                model = dpr.ReadAll<z_bas_item_bom>(sql_query);
            ErrorMessage = dpr.ErrorMessage;
            return model;
        }
    }
}