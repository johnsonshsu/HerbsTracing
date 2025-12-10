using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_qcm_finish_bom : DapperSql<z_qcm_finish_bom>
    {
        public sql_z_qcm_finish_bom()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_qcm_finish_bom.plot_no,z_qcm_finish_bom.clot_no";
            DefaultOrderByDirection = "ASC,ASC";
            DropDownValueColumn = "z_qcm_finish_bom.plot_no";
            DropDownTextColumn = "z_qcm_finish_bom.plot_no";
            DropDownOrderColumn = "z_qcm_finish_bom.plot_no ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT z_qcm_finish_bom.rowid, z_qcm_finish_bom.form_no, z_qcm_finish_bom.plot_no,
z_qcm_finish_bom.clot_no, z_qcm_finish_bom.item_no, z_bas_item.mname AS item_name
FROM z_qcm_finish_bom
LEFT OUTER JOIN z_bas_item ON z_qcm_finish_bom.item_no = z_bas_item.mno
";
            return str_query;
        }

public override string GetSQLWhere()
        {
            string str_query = " WHERE z_qcm_finish_bom.form_no = @form_no ";
            return str_query;
        }

        public override z_qcm_finish_bom GetData(string valueNo)
        {
            string sql_query = GetSQLSelect();
            sql_query += " WHERE z_qcm_finish_bom.rowid = @rowid ";
            sql_query += GetSQLOrderBy();
            DynamicParameters parm = new DynamicParameters();
            parm.Add("rowid", valueNo);
            var model = dpr.ReadSingle<z_qcm_finish_bom>(sql_query, parm);
            ErrorMessage = dpr.ErrorMessage;
            return model;
        }

        /// <summary>
        /// 取得多筆資料(同步呼叫)
        /// </summary>
        /// <param name="mno">品項編號</param>
        /// <param name="searchString">模糊搜尋文字</param>
        /// <returns></returns>
        public List<z_qcm_finish_bom> GetDataList(string mno, string searchString)
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
        public List<z_qcm_finish_bom> GetDataList(string mno, DynamicParameters parm, string searchString)
        {
            List<string> searchColumns = GetSearchColumns();
            var model = new List<z_qcm_finish_bom>();
            string sql_query = GetSQLSelect();
            string sql_where = GetSQLWhere();
            sql_query += sql_where;
            if (!string.IsNullOrEmpty(searchString) && searchColumns.Count() > 0)
                sql_query += dpr.GetSQLWhereBySearchColumn(EntityObject, searchColumns, sql_where, searchString);
            sql_query += GetSQLOrderBy();
            parm.Add("@form_no", mno);
            if (parm.ParameterNames.Count() > 0)
                model = dpr.ReadAll<z_qcm_finish_bom>(sql_query, parm);
            else
                model = dpr.ReadAll<z_qcm_finish_bom>(sql_query);
            ErrorMessage = dpr.ErrorMessage;
            return model;
        }


        public void SetMaterialInfo(string plotNo, string itemNo)
        {
            TracingService.CLotNo = "";
            string str_query = GetSQLSelect();
            str_query += " WHERE z_qcm_finish.plot_no = @plot_no AND z_qcm_finish_bom.item_no = @item_no";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("plot_no", plotNo);
            parm.Add("item_no", itemNo);
            var model = dpr.ReadSingle<z_qcm_finish_bom>(str_query, parm);
            if (model == null) return;
            TracingService.CLotNo = model.clot_no;
        }
    }
}
