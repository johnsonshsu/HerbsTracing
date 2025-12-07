using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_bas_place : DapperSql<z_bas_place>
    {
        public sql_z_bas_place()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_bas_place.mno ";
            DefaultOrderByDirection = "ASC";
            DropDownValueColumn = "z_bas_place.mno";
            DropDownTextColumn = "z_bas_place.mname";
            DropDownOrderColumn = "z_bas_place.mno ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT z_bas_place.rowid,z_bas_place.user_no,z_bas_place.mno,z_bas_place.mname,z_bas_place.country_no
,z_bas_place.province_no,z_bas_place.city_no,z_bas_place.town_no,z_bas_place.road_no,z_bas_place.maddlead
,z_bas_place.maddress,z_bas_place.emaddress,z_bas_place.area_type,z_bas_place.earea_type,z_bas_place.mhight
,z_bas_place.emhight,z_bas_place.marea,z_bas_place.emarea,z_bas_place.mtemperature,z_bas_place.emtemperature
,z_bas_place.mrain,z_bas_place.emrain,z_bas_place.mfrost,z_bas_place.emfrost,z_bas_place.temp_height
,z_bas_place.etemp_height,z_bas_place.temp_low,z_bas_place.etemp_low,z_bas_place.mwater,z_bas_place.emwater
,z_bas_place.menvironment,z_bas_place.emenvironment,z_bas_place.remark,z_bas_place.mapaddr,z_bas_place.mapdesc
,z_bas_place.mapx,z_bas_place.mapy,z_bas_place.ismap ,
'~/images/Place/' + mno + '_1.jpg' AS PlaceImage1, 
'~/images/Place/' + mno + '_2.jpg' AS PlaceImage2 
  FROM z_bas_place  
";
            return str_query;
        }

        public override z_bas_place GetData(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_bas_place.mno = @id";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("id", id);
            var model = dpr.ReadSingle<z_bas_place>(str_query, parm);
            return model;
        }

        /// <summary>
        /// 取得產品產地資訊
        /// </summary>
        /// <param name="vendorNo">廠商編號</param>
        /// <param name="placeNo">產地編號</param>
        /// <returns></returns>
        public z_bas_place GetProductPlace(string vendorNo, string placeNo)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_bas_place.user_no = @vendorNo AND z_bas_place.mno = @placeNo";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("vendorNo", vendorNo);
            parm.Add("placeNo", placeNo);
            var model = dpr.ReadSingle<z_bas_place>(str_query, parm);
            return model;
        }
    }
}