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
SELECT  z_qcm_finish_bom.rowid, z_qcm_finish_bom.form_no, z_qcm_finish_bom.plot_no, 
z_qcm_finish_bom.clot_no, z_qcm_finish_bom.item_no, z_bas_item.mname
FROM z_qcm_finish_bom 
LEFT OUTER JOIN z_bas_item ON z_qcm_finish_bom.item_no = z_bas_item.mno 
LEFT OUTER JOIN z_qcm_finish ON z_qcm_finish_bom.form_no = z_qcm_finish.mno
";
            return str_query;
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