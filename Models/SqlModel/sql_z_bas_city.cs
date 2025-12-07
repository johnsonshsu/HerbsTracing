using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_bas_city : DapperSql<z_bas_city>
    {
        public sql_z_bas_city()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_bas_city.country_no,z_bas_city.mno ";
            DefaultOrderByDirection = "ASC,ASC";
            DropDownValueColumn = "z_bas_city.mno";
            DropDownTextColumn = "z_bas_city.mname";
            DropDownOrderColumn = "z_bas_city.country_no ASC, z_bas_city.mno ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT  rowid, country_no, country_name, province_no, province_name, mno, mname, mename
FROM z_bas_city
";
            return str_query;
        }

        public override List<z_bas_city> GetDataList(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_bas_city.country_no = @id ORDER BY z_bas_city.mno ASC";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("id", id);
            var model = dpr.ReadAll<z_bas_city>(str_query, parm);
            return model;
        }

        public override z_bas_city GetData(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_bas_city.mno = @id";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("id", id);
            var model = dpr.ReadSingle<z_bas_city>(str_query, parm);
            return model;
        }

        /// <summary>
        /// 推薦店家所在城市清單
        /// </summary>
        public List<z_bas_city> GetShopCityList()
        {
            string str_query = @"
SELECT DISTINCT z_bas_city.mno, z_bas_city.mname FROM z_bas_vendor LEFT OUTER JOIN z_bas_city ON z_bas_vendor.city_no = z_bas_city.mno 
WHERE (z_bas_vendor.mcode = @mcode) AND (z_bas_vendor.mstatus = @mstatus) AND (z_bas_city.mno IS NOT NULL) AND (z_bas_city.mno <> '') 
ORDER BY z_bas_city.mno
            ";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("mcode", "V");
            parm.Add("mstatus", "B");
            var model = dpr.ReadAll<z_bas_city>(str_query, parm);
            return model;
        }
    }
}