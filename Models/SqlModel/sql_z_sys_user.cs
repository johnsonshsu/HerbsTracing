using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herbstracing.Models
{
    public class sql_z_sys_user : DapperSql<z_sys_user>
    {
        public sql_z_sys_user()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "z_sys_user.mno";
            DefaultOrderByDirection = "ASC";
            DropDownValueColumn = "z_sys_user.mno";
            DropDownTextColumn = "z_sys_user.mname";
            DropDownOrderColumn = "z_sys_user.mno ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT z_sys_user.rowid,z_sys_user.orgno,z_sys_user.mcode,z_sys_user.mno,
z_sys_user.mname,z_sys_user.msname,z_sys_user.mename,z_sys_user.mpassword,
z_sys_user.indate,z_sys_user.checkdate,z_sys_user.confirmdate,z_sys_user.msex,
z_sys_user.roleno,z_sys_user.memail,z_sys_user.mtel,z_sys_user.userno,
z_sys_user.isenabled,z_sys_user.remark , z_sys_role.mname AS role_name ,
case when z_sys_user.isenabled = 'True' then 1 else 0 end as isenable 
FROM z_sys_user 
LEFT OUTER JOIN z_sys_role ON z_sys_role.mno = z_sys_user.roleno 
";
            return str_query;
        }

        public z_sys_user GetDataByNo(string no)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_sys_user.mno = @no";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("no", no);
            var model = dpr.ReadSingle<z_sys_user>(str_query, parm);
            return model;
        }

        public override z_sys_user GetData(string id)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_sys_user.rowid = @id";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("id", id);
            var model = dpr.ReadSingle<z_sys_user>(str_query, parm);
            return model;
        }

        public List<SelectListItem> GetDropDownListByRole(string roleNo , string userNo)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_sys_user.roleno = @roleno ";
            str_query += " ORDER BY z_sys_user.mno";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("roleno", roleNo);
            var userList = dpr.ReadAll<z_sys_user>(str_query, parm);
            var result = userList.Select(item => new SelectListItem
            {
                Text = item.mno + ' ' + item.mname,
                Value = item.mno
            }).ToList();
            if (result.Any(x => x.Value == userNo))
                result.Where(x => x.Value == userNo).ToList().ForEach(x => x.Selected = true);
            return result;
        }

        public bool CheckLogin(vmLogin model)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_sys_user.mno = @mno AND ";
            str_query += " z_sys_user.mcode = @mcode AND ";
            str_query += " z_sys_user.mpassword = @mpassword AND ";
            str_query += " z_sys_user.isenabled = @isenabled ";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("mno", model.UserNo);
            parm.Add("mcode", "N");
            parm.Add("mpassword", model.Password);
            parm.Add("isenabled", "True");
            var data = dpr.ReadSingle<z_sys_user>(str_query, parm);
            if (data == null) return false;
            SessionService.IsLogin = true;
            SessionService.OrgNo = data.orgno;
            SessionService.UserNo = data.mno;
            SessionService.UserName = data.mname;
            SessionService.RoleNo = data.roleno;
            return true;
        }

        public z_sys_user GetDataByRoleAndNo(string roleNo, string userNo)
        {
            string str_query = GetSQLSelect();
            str_query += " WHERE z_sys_user.roleno = @roleno AND z_sys_user.mno = @mno ";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("roleno", roleNo);
            parm.Add("mno", userNo);
            var model = dpr.ReadSingle<z_sys_user>(str_query, parm);
            if (model == null || string.IsNullOrEmpty(model.mno))
            {
                str_query = GetSQLSelect();
                str_query += " WHERE z_sys_user.roleno = @roleno ";
                parm = new DynamicParameters();
                parm.Add("roleno", roleNo);
                model = dpr.ReadSingle<z_sys_user>(str_query, parm);
            }
            return model;
        }
    }
}
