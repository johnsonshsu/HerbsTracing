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
SELECT z_qcm_item_testitem.test_base, z_qcm_item_testitem.test_unit, 
z_qcm_item_testitem.test_result, z_qcm_item_testitem.mno, z_bas_test.mname AS test_name 
FROM z_qcm_item_testitem 
INNER JOIN z_bas_test ON z_qcm_item_testitem.test_no = z_bas_test.mno 
";
            return str_query;
        }

        /// <summary>
        /// 取得檢驗項目清單
        /// </summary>
        /// <param name="itemNo">藥材編號</param>
        /// <param name="codeNo">參數,預設為I</param>
        /// <returns></returns>
        public List<z_qcm_item_testitem> GetDataList(string itemNo, string codeNo)
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