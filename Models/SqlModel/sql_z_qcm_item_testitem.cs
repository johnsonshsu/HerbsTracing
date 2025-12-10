using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_qcm_item_testitem : DapperSql<z_qcm_item_testitem>
    {
        public sql_z_qcm_item_testitem()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_qcm_item_testitem.test_base ";
            DefaultOrderByDirection = "ASC";
            DropDownValueColumn = "z_qcm_item_testitem.test_base";
            DropDownTextColumn = "z_qcm_item_testitem.test_base";
            DropDownOrderColumn = "z_qcm_item_testitem.test_base ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT z_qcm_item_testitem.rowid , z_qcm_item_testitem.parentid,
z_qcm_item_testitem.mno,z_qcm_item_testitem.seq,
z_qcm_item_testitem.test_no, z_bas_test.mname AS test_name,
z_qcm_item_testitem.test_value,z_qcm_item_testitem.test_base,
z_qcm_item_testitem.test_unit,z_qcm_item_testitem.test_result
FROM z_qcm_item_testitem
LEFT OUTER JOIN z_bas_test ON z_qcm_item_testitem.test_no = z_bas_test.mno
";
            return str_query;
        }

        public override string GetSQLWhere()
        {
            string str_query = " WHERE z_qcm_item_testitem.mno = @mno ";
            return str_query;
        }

        /// <summary>
        /// 取得多筆資料(同步呼叫)
        /// </summary>
        /// <param name="mno">品項編號</param>
        /// <param name="searchString">模糊搜尋文字</param>
        /// <returns></returns>
        public List<z_qcm_item_testitem> GetDataList(string mno, string searchString)
        {
            DynamicParameters parm = new DynamicParameters();
            var model = GetDataList(mno, parm, searchString);
            return model;
        }

        /// <summary>
        /// 取得多筆資料(同步呼叫)
        /// </summary>
        /// <param name="mno">品項編號</param>
        /// <param name="parm">參數</param>
        /// <param name="searchString">模糊搜尋文字</param>
        /// <returns></returns>
        public List<z_qcm_item_testitem> GetDataList(string mno, DynamicParameters parm, string searchString)
        {
            List<string> searchColumns = GetSearchColumns();
            var model = new List<z_qcm_item_testitem>();
            string sql_query = GetSQLSelect();
            string sql_where = GetSQLWhere();
            sql_query += sql_where;
            if (!string.IsNullOrEmpty(searchString) && searchColumns.Count() > 0)
                sql_query += dpr.GetSQLWhereBySearchColumn(EntityObject, searchColumns, sql_where, searchString);
            sql_query += GetSQLOrderBy();
            parm.Add("@mno", mno);
            if (parm.ParameterNames.Count() > 0)
                model = dpr.ReadAll<z_qcm_item_testitem>(sql_query, parm);
            else
                model = dpr.ReadAll<z_qcm_item_testitem>(sql_query);
            ErrorMessage = dpr.ErrorMessage;
            return model;
        }

        public override z_qcm_item_testitem GetData(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_qcm_item_testitem.rowid = @rowid";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("rowid", id);
            var model = dpr.ReadSingle<z_qcm_item_testitem>(str_query, parm);
            return model;
        }


        /// <summary>
        /// 取得檢驗項目清單
        /// </summary>
        /// <param name="itemNo">藥材編號</param>
        /// <param name="codeNo">參數,預設為I</param>
        /// <returns></returns>
        public List<z_qcm_item_testitem> GetDataListByItemCode(string itemNo, string codeNo)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_qcm_item_testitem.mno = @mno AND z_bas_test.mcode = @codeNo";
            str_query += " ORDER BY z_bas_test.mname";
            var parm = new DynamicParameters();
            parm.Add("@mno", itemNo);
            parm.Add("@codeNo", codeNo);
            var model = dpr.ReadAll<z_qcm_item_testitem>(str_query, parm);
            return model;
        }
    }
}
