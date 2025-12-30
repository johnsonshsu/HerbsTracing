using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_sys_security : DapperSql<z_sys_security>
    {
        public sql_z_sys_security()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_sys_security.prg_no ";
            DefaultOrderByDirection = "ASC";
            DropDownValueColumn = "z_sys_security.prg_no";
            DropDownTextColumn = "z_sys_security.prg_name";
            DropDownOrderColumn = "z_sys_security.prg_no ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT z_sys_security.rowid, z_sys_security.user_no, z_sys_security.module_no, 
z_sys_module.mname AS module_name,z_sys_security.prg_no, z_sys_security.prg_name, 
z_sys_security.isenabled, z_sys_security.isadd,z_sys_security.isedit, 
z_sys_security.isdelete, z_sys_security.isprint, z_sys_security.isconfirm 
FROM z_sys_security 
INNER JOIN z_sys_module ON z_sys_security.module_no = z_sys_module.mno 
";
            return str_query;
        }

        public List<z_sys_module> GetUserModules(string user_no)
        {
            string str_query = "";
            DynamicParameters parm = new DynamicParameters();
            if (SessionService.RoleNo == "admin")
            {
                str_query = @"
SELECT z_sys_module.mno AS mno, z_sys_module.mname  
FROM z_sys_module 
WHERE (z_sys_module.mcode=@mcode AND z_sys_module.isenabled = @isenabled) 
ORDER BY z_sys_module.msort ASC,z_sys_module.mno ASC";
                parm.Add("@mcode", "SYS");
            }
            else
            {
                str_query = @"
SELECT z_sys_security.module_no AS mno, z_sys_module.mname AS mname  
FROM z_sys_security 
INNER JOIN z_sys_module ON z_sys_security.module_no = z_sys_module.mno
WHERE (z_sys_module.mcode=@mcode AND 
z_sys_security.isenabled = @isenabled) AND 
(z_sys_module.isenabled = @isenabled) AND 
(z_sys_security.user_no = @user_no) 
GROUP BY z_sys_security.module_no, z_sys_module.mname
ORDER BY z_sys_security.module_no ASC";
                parm.Add("@mcode", "APP");
                parm.Add("@user_no", user_no);
            }
            parm.Add("@isenabled", "True");
            var model = dpr.ReadAll<z_sys_module>(str_query, parm);
            return model;
        }

        public List<z_sys_program> GetUserPrograms(string user_no, string module_no)
        {
            string str_query = "";
            DynamicParameters parm = new DynamicParameters();
            if (SessionService.RoleNo == "admin")
            {
                str_query = @"
SELECT z_sys_program.mno , z_sys_program.mname 
FROM z_sys_program 
WHERE (z_sys_program.isenabled = @isenabled) AND (z_sys_program.moduleno = @module_no) 
ORDER BY z_sys_program.msort ASC , z_sys_program.mno ASC
";
            }
            else
            {
                str_query = @"
SELECT z_sys_security.prg_no AS mno, z_sys_security.prg_name AS mname
FROM z_sys_security 
INNER JOIN z_sys_program ON z_sys_security.prg_no = z_sys_program.mno
WHERE (z_sys_security.isenabled = @isenabled) AND 
(z_sys_program.isenabled = @isenabled) AND 
(z_sys_security.user_no = @user_no) AND (z_sys_security.module_no = @module_no)
ORDER BY z_sys_security.prg_no ASC
";
                parm.Add("@user_no", user_no);
            }
            parm.Add("@module_no", module_no);
            parm.Add("@isenabled", "True");
            var model = dpr.ReadAll<z_sys_program>(str_query, parm);
            return model;
        }
        public List<z_sys_security> GetUserSecuritys(string user_no)
        {
            string str_query = "";
            DynamicParameters parm = new DynamicParameters();
            str_query = @"
SELECT z_sys_security.rowid, z_sys_security.user_no, z_sys_security.module_no, 
z_sys_security.prg_no, z_sys_security.prg_name, z_sys_security.isenabled, 
z_sys_security.isadd, z_sys_security.isedit, z_sys_security.isdelete, 
z_sys_security.isprint, z_sys_security.isconfirm , 
CASE WHEN z_sys_security.isenabled = 'True' THEN 1 ELSE 0 END AS is_enabled,
CASE WHEN z_sys_security.isadd = 'True' THEN 1 ELSE 0 END AS is_add,
CASE WHEN z_sys_security.isedit = 'True' THEN 1 ELSE 0 END AS is_edit,
CASE WHEN z_sys_security.isdelete = 'True' THEN 1 ELSE 0 END AS is_delete,
CASE WHEN z_sys_security.isprint = 'True' THEN 1 ELSE 0 END AS is_print,
CASE WHEN z_sys_security.isconfirm = 'True' THEN 1 ELSE 0 END AS is_confirm 
FROM  z_sys_security 
WHERE user_no = @user_no 
ORDER BY prg_no 
";
            parm.Add("@user_no", user_no);
            var model = dpr.ReadAll<z_sys_security>(str_query, parm);
            return model;
        }

    }
}
