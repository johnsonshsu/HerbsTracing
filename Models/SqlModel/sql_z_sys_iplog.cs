using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_sys_iplog : DapperSql<z_sys_iplog>
    {
        public List<string> TextData { get; set; } = new List<string>();
        public List<int> ValueData { get; set; } = new List<int>();

        public sql_z_sys_iplog()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_sys_iplog.rowid";
            DefaultOrderByDirection = "DESC";
            DropDownValueColumn = "z_sys_iplog.rowid";
            DropDownTextColumn = "z_sys_iplog.rowid";
            DropDownOrderColumn = "z_sys_iplog.rowid ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT z_sys_iplog.rowid, z_sys_iplog.mcode, z_sys_iplog.mlotno, z_sys_iplog.mno,
z_sys_iplog.mdate, z_sys_iplog.mtime, z_sys_iplog.ipaddr
FROM z_sys_iplog
";
            return str_query;
        }

        public override z_sys_iplog GetData(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_sys_iplog.rowid = @id";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("id", id);
            var model = dpr.ReadSingle<z_sys_iplog>(str_query, parm);
            return model;
        }

        public void LogIP(string mcode, string mlotno, string mno , string ipaddr)
        {
            string str_query = @"
INSERT INTO z_sys_iplog
(rowid, mcode, mlotno, mno, mdate, mtime, ipaddr)
VALUES
(NEWID(), @mcode, @mlotno, @mno, GETDATE(), GETDATE(), @ipaddr)";

            DynamicParameters parm = new DynamicParameters();
            parm.Add("mcode", mcode);
            parm.Add("mlotno", mlotno);
            parm.Add("mno", mno);
            parm.Add("ipaddr", ipaddr);
            dpr.Execute (str_query, parm);
        }

        public void GetChartData(string codeNo , DateTime startDate, DateTime endDate)
        {
            TextData  = new List<string>();
            ValueData  = new List<int>();
            string str_query = @"";
            string str_date = "";
            DateTime indexDate = startDate;
            while (indexDate <= endDate)
            {
                str_date = indexDate.ToString("yyyy-MM-dd");
                str_query = $"SELECT COUNT(*) as count FROM z_sys_iplog WHERE mcode = @mcode AND mdate = @mdate";
                DynamicParameters parm = new DynamicParameters();
                parm.Add("mcode", codeNo);
                parm.Add("mdate", str_date);
                int count = dpr.ReadSingle<int>(str_query, parm);
                TextData.Add(indexDate.ToString("yyyy-MM-dd"));
                ValueData.Add(count);
                indexDate = indexDate.AddDays(1);
            }
        }
    }
}
