using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_bas_vendor : DapperSql<z_bas_vendor>
    {
        public sql_z_bas_vendor()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_bas_vendor.mno ";
            DefaultOrderByDirection = "ASC";
            DropDownValueColumn = "z_bas_vendor.mname";
            DropDownTextColumn = "z_bas_vendor.mname";
            DropDownOrderColumn = "z_bas_vendor.mno ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT z_bas_vendor.rowid, z_bas_vendor.mno, z_bas_vendor.mcode, z_bas_vendor.mname, z_bas_vendor.marea,
z_bas_vendor.mserialno, z_bas_vendor.mproduct, z_bas_vendor.cdate, z_bas_vendor.adate, z_bas_vendor.mstatus,
z_bas_vendor.msex, z_bas_vendor.mtel, z_bas_vendor.mfax, z_bas_vendor.mmobil, z_bas_vendor.country_no,
z_bas_country.mname AS country_name, z_bas_vendor.province_no, z_bas_province.mname AS province_name,
z_bas_vendor.city_no, z_bas_city.mname AS city_name, z_bas_vendor.town_no, z_bas_town.mname AS town_name,
z_bas_vendor.road_no, z_bas_road.mname AS road_name, z_bas_vendor.maddlead, z_bas_vendor.maddress,
z_bas_vendor.maddr, z_bas_vendor.memail, z_bas_vendor.userno, z_bas_vendor.vdate, z_bas_vendor.remark,
z_bas_vendor.mzipno, z_bas_vendor.msname, z_bas_vendor.mboss, z_bas_vendor.mcontactor, z_bas_vendor.mweburl,
z_bas_vendor.mtime, z_bas_vendor.msubject, z_bas_vendor.mskill, z_bas_vendor.mdescribe, z_bas_vendor.mpassword,
z_bas_vendor.mapaddr, z_bas_vendor.mapdesc, z_bas_vendor.mapx, z_bas_vendor.mapy, z_bas_vendor.ismap ,
z_bas_vendor.mname + ' ' + z_bas_vendor.mtel AS mtitle
FROM z_bas_vendor
LEFT OUTER JOIN z_bas_city ON z_bas_vendor.city_no = z_bas_city.mno
LEFT OUTER JOIN z_bas_town ON z_bas_vendor.town_no = z_bas_town.mno
LEFT OUTER JOIN z_bas_road ON z_bas_vendor.road_no = z_bas_road.mno
LEFT OUTER JOIN z_bas_province ON z_bas_vendor.province_no = z_bas_province.mno
LEFT OUTER JOIN z_bas_country ON z_bas_vendor.country_no = z_bas_country.mno
";
            return str_query;
        }

        public List<z_bas_vendor> GetUnConfirmDataList()
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_bas_vendor.mstatus = @mstatus AND ";
            str_query += " (z_bas_vendor.mcode = @mcode1 OR z_bas_vendor.mcode = @mcode2) ";
            str_query += " ORDER BY z_bas_vendor.mno ASC";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("mstatus", "A");
            parm.Add("mcode1", "F");
            parm.Add("mcode2", "V");
            var model = dpr.ReadAll<z_bas_vendor>(str_query, parm);
            return model;
        }

        public List<z_bas_vendor> GetDataListByCode(string codeNo, string statusNo, string searchText = "")
        {
            var models = GetDataList(searchText);
            var model = models.Where(x => x.mcode == codeNo && x.mstatus == statusNo).ToList();
            return model;
        }

        public List<z_bas_vendor> GetDataListByCode(string codeNo, string searchText = "")
        {
            var models = GetDataList(searchText);
            var model = models.Where(x => x.mcode == codeNo).ToList();
            return model;
        }

        public override z_bas_vendor GetData(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_bas_vendor.rowid = @rowid";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("rowid", id);
            var model = dpr.ReadSingle<z_bas_vendor>(str_query, parm);
            return model;
        }

        public z_bas_vendor GetDataByNo(string vendornNo)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_bas_vendor.mno = @mno";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("mno", vendornNo);
            var model = dpr.ReadSingle<z_bas_vendor>(str_query, parm);
            return model;
        }

        public List<z_bas_vendor> GetMapData(string codeNo, string cityNo)
        {
            string str_query = GetSQLSelect();
            DynamicParameters parm = new DynamicParameters();
            if (codeNo == "P")
            {
                str_query += " WHERE (z_bas_vendor.mcode = @mcode) AND z_bas_place.mapaddr IS NOT null ";
                str_query += "AND z_bas_place.mapdesc IS NOT null AND z_bas_place.mapaddr<> ''";
                parm.Add("mcode", "F");
            }
            if (codeNo == "V")
            {
                str_query += " WHERE (z_bas_vendor.mcode = @mcode) AND (z_bas_vendor.mstatus = @mstatus) ";
                str_query += " AND (z_bas_vendor.city_no = @city_no) AND (z_bas_vendor.ismap = @ismap) ";
                parm.Add("mcode", "V");
                parm.Add("mstatus", "B");
                parm.Add("city_no", cityNo);
                parm.Add("ismap", "True");
            }
            str_query += " AND (z_bas_vendor.mapx IS NOT NULL AND z_bas_vendor.mapy IS NOT NULL) ";
            str_query += " AND (z_bas_vendor.mapx <> '0') ";
            str_query += " ORDER BY z_bas_vendor.mno ASC";

            var model = dpr.ReadAll<z_bas_vendor>(str_query, parm);
            return model;
        }

        /// <summary>
        /// 推薦店家清單
        /// </summary>
        /// <param name="cityNo">城市編號</param>
        public List<z_bas_vendor> GetShopCityList(string cityNo)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE (z_bas_vendor.mcode = @mcode) AND (z_bas_vendor.mstatus = @mstatus) ";
            str_query += " AND (z_bas_vendor.city_no = @city_no) ";
            str_query += " ORDER BY z_bas_vendor.mname ASC";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("mcode", "V");
            parm.Add("mstatus", "B");
            parm.Add("city_no", cityNo);
            var model = dpr.ReadAll<z_bas_vendor>(str_query, parm);
            return model;
        }

        public string GetNewVendorNo()
        {
            string str_query = "";
            string new_no = "";
            while (true)
            {
                new_no = new Random().Next(10000, 99999).ToString().PadLeft(5, '0');
                str_query = "SELECT COUNT(*) FROM z_bas_vendor WHERE mno = @mno";
                DynamicParameters parm = new DynamicParameters();
                parm.Add("mno", new_no);
                int count = dpr.ReadSingle<int>(str_query, parm);
                if (count == 0)
                {
                    return new_no;
                }
            }
        }

        public string Confirm(string id = "")
        {
            string str_query = "UPDATE z_bas_vendor SET mstatus = @mstatus, adate = @adate WHERE rowid = @rowid";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("mstatus", "B");
            parm.Add("adate", DateTime.Today);
            parm.Add("rowid", id);
            dpr.Execute(str_query, parm);
            //取得審核的廠商名稱
            str_query = "SELECT mname FROM z_bas_vendor WHERE rowid = @rowid";
            parm = new DynamicParameters();
            parm.Add("rowid", id);
            string vendorName = dpr.ReadSingle<string>(str_query, parm);
            return vendorName;
        }
    }
}
