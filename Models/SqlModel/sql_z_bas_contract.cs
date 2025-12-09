using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_bas_contract : DapperSql<z_bas_contract>
    {
        public sql_z_bas_contract()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_bas_contract.mno";
            DefaultOrderByDirection = "ASC";
            DropDownValueColumn = "z_bas_contract.mno";
            DropDownTextColumn = "z_bas_contract.mno";
            DropDownOrderColumn = "z_bas_contract.mno ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT z_bas_contract.rowid, z_bas_contract.user_no, z_bas_vendor.mname AS user_name,
z_bas_contract.place_no,z_bas_place.mname AS place_name, z_bas_contract.item_no,
z_bas_item.mname AS item_name, z_bas_contract.mno, z_bas_contract.mdate,
z_bas_contract.mdate1, z_bas_contract.mdate2, z_bas_contract.lot_no,
z_bas_contract.isconfirm, z_bas_contract.isclose, z_bas_contract.remark
FROM z_bas_contract
LEFT OUTER JOIN z_bas_place ON z_bas_contract.place_no = z_bas_place.mno
LEFT OUTER JOIN z_bas_item ON z_bas_contract.item_no = z_bas_item.mno
LEFT OUTER JOIN z_bas_vendor ON z_bas_contract.user_no = z_bas_vendor.mno
";
            return str_query;
        }

        public List<z_bas_contract> GetUserContractList(string userNo ,string searchText = "")
        {
            var models = GetDataList(searchText);
            return models.Where(m => m.user_no == userNo).ToList();
        }

        public override z_bas_contract GetData(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_bas_contract.rowid = @id";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("id", id);
            var model = dpr.ReadSingle<z_bas_contract>(str_query, parm);
            return model;
        }

        public void SetMaterialInfo(string lotNo)
        {
            TracingService.VendorNo = "";
            TracingService.PlaceNo = "";
            string str_query = GetSQLSelect();
            str_query += " WHERE z_bas_contract.lot_no = @lot_no";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("lot_no", lotNo);
            var model = dpr.ReadSingle<z_bas_contract>(str_query, parm);
            if (model == null) return;
            TracingService.VendorNo = model.user_no;
            TracingService.PlaceNo = model.place_no;
        }
    }
}
