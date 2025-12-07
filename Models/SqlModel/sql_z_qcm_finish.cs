using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_qcm_finish : DapperSql<z_qcm_finish>
    {
        public sql_z_qcm_finish()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_qcm_finish.mdate ";
            DefaultOrderByDirection = "DESC";
            DropDownValueColumn = "z_qcm_finish.mcode";
            DropDownTextColumn = "z_qcm_finish.mtitle";
            DropDownOrderColumn = "z_qcm_finish.mcode ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT rowid,mno,mdate,plot_no,prod_no,prod_name,clot_no,slot_no,item_no 
,item_name,expire_date,report_date,isconfirm,report_no,remark 
FROM z_qcm_finish 
";
            return str_query;
        }

        /// <summary>
        /// 取得溯源表頭資訊
        /// </summary>
        /// <param name="tracingCode">溯源碼</param>
        /// <returns></returns>
        public TracingHeadModel GetTracingHeadModel(string tracingCode)
        {
            TracingHeadModel headModel = new TracingHeadModel();
            TracingService tracingService = new TracingService();
            TracingService.TracingCode = tracingCode;
            string prodLotNo = tracingService.ProdLotNo;
            string serialNo = tracingService.SerialNo;
            string str_plot_no = prodLotNo + "%";
            string str_slot_no = "%" + serialNo;
            string str_query = GetSQLSelect();
            str_query += " WHERE z_qcm_finish.plot_no LIKE @plot_no AND z_qcm_finish.slot_no LIKE @slot_no";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("plot_no", str_plot_no);
            parm.Add("slot_no", str_slot_no);
            var model = dpr.ReadSingle<z_qcm_finish>(str_query, parm);
            if (model == null) return headModel;

            model.prod_name = "";
            str_query = "SELECT mname FROM z_bas_item WHERE mno = @mno";
            parm = new DynamicParameters();
            parm.Add("mno", model.prod_no);
            var item = dpr.ReadSingle<z_bas_item>(str_query, parm);
            if (item != null) model.prod_name = item.mname;

            headModel.TracingCode = tracingCode;
            headModel.FinishId = model.rowid;
            headModel.ProdNo = model.prod_no;
            headModel.ProdName = model.prod_name;
            headModel.PLotNo = model.plot_no;
            headModel.ProdLotNo = model.slot_no;
            headModel.SerialNo = model.slot_no;
            headModel.ReportDate = model.report_date?.ToString("yyyy/MM/dd");
            headModel.ValidDate = model.expire_date?.ToString("yyyy/MM/dd");
            headModel.ReportNo = model.report_no;
            headModel.CheckInfo = "本產品經SGS檢驗合格，請安心使用。";
            headModel.LotCode = "99";
            return headModel;
        }
    }
}