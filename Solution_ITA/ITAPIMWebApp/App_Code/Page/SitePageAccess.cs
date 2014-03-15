using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
namespace PageBaseFun
{
    /// <summary>
    /// SitePageAccess 的摘要说明
    /// </summary>
    public class SitePageAccess
    {
        public SitePageAccess()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 获取用户的角色列表
        protected ArrayList GetRolebyUserid(string p_userid)
        {
            ArrayList ret_list = new ArrayList();
            Mis.BLL.ptgl.SYS_ROLEUSER roleuser_handle = new Mis.BLL.ptgl.SYS_ROLEUSER();
            DataSet ds = roleuser_handle.GetList(" USERID = " + p_userid + " ");
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string nowroleid = ds.Tables[0].Rows[i]["ROLEID"].ToString();


                    ret_list.Add(nowroleid);
                }
            }
            return ret_list;
        }

        protected string GetRoleliststrbyUserid(string p_userid)
        {
            string ret_list = "";
            Mis.BLL.ptgl.SYS_ROLEUSER roleuser_handle = new Mis.BLL.ptgl.SYS_ROLEUSER();
            DataSet ds = roleuser_handle.GetList(" USERID = " + p_userid + " ");
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string nowroleid = ds.Tables[0].Rows[i]["ROLEID"].ToString();

                    Mis.BLL.ptgl.SYS_ROLES role_handle = new Mis.BLL.ptgl.SYS_ROLES();
                    Mis.Model.ptgl.SYS_ROLES rolemodel = role_handle.GetModel(int.Parse(nowroleid));

                    ret_list += rolemodel.ID;
                    ret_list += ",";
                }
            }
            if (ret_list.Length > 0 && ret_list.Substring(ret_list.Length - 1).CompareTo(",") == 0)
                ret_list = ret_list.Substring(0, ret_list.Length - 1);
            return ret_list;
        }

        private bool IsofInList(ArrayList sysdatatype_list, string p_node)
        {
            for (int i = 0; i < sysdatatype_list.Count; i++)
            {
                if (sysdatatype_list[i].ToString().CompareTo(p_node) == 0)
                    return true;
            }
            return false;
        }

        protected ArrayList GetRoleTypebyUserid(string p_userid)
        {
            Mis.BLL.ptgl.SYS_ROLEUSER roleuser_handle = new Mis.BLL.ptgl.SYS_ROLEUSER();
            DataSet ds = roleuser_handle.GetList(" USERID = " + p_userid + " ");
            ArrayList sysdatatype_list = new ArrayList();
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string nowroleid = ds.Tables[0].Rows[i]["ROLEID"].ToString();

                    Mis.BLL.ptgl.SYS_ROLES role_handle = new Mis.BLL.ptgl.SYS_ROLES();
                    Mis.Model.ptgl.SYS_ROLES rolemodel = role_handle.GetModel(int.Parse(nowroleid));

                    if (false == IsofInList(sysdatatype_list, rolemodel.SYSDATATYPE))
                    {
                        sysdatatype_list.Add(rolemodel.SYSDATATYPE);
                    }

                }
            }

            return sysdatatype_list;
        }


        #endregion


        #region 检查用md5算法加密的密码是否正确

        public int CheckPassword(string username, string Password)
        {
            Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "MD5");
            Mis.BLL.ptgl.SYS_USERS handle = new Mis.BLL.ptgl.SYS_USERS();

            DataSet ds = handle.GetList("USERNAME='" + username + "' ");
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PASSWORD"].ToString().Trim().CompareTo(Password) != 0)
                    return 0; //密码不正确
                else
                    return 1; //密码正确 
            }
            else
                return 3; //找不到该用户

        }

        public user GetUserObjext(string username, string Password)
        {
            Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "MD5");
            Mis.BLL.ptgl.SYS_USERS handle = new Mis.BLL.ptgl.SYS_USERS();
            DataSet ds = handle.GetList("USERNAME='" + username + "' ");
            user user_obj = new user();

            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                user_obj.id = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                user_obj.uid = ds.Tables[0].Rows[0]["USERNAME"].ToString();
                user_obj.realname = ds.Tables[0].Rows[0]["USERREALNAME"].ToString();
                user_obj.DepartmentID = ds.Tables[0].Rows[0]["DEPTID"].ToString();
                user_obj.phone = ds.Tables[0].Rows[0]["MOBILEPHONE"].ToString() + "," + ds.Tables[0].Rows[0]["PHONENO"].ToString();
                //model.DEPTID
                user_obj.rolelist = GetRoleliststrbyUserid(ds.Tables[0].Rows[0]["ID"].ToString());
                user_obj.roledatatypelist = GetRoleTypebyUserid(ds.Tables[0].Rows[0]["ID"].ToString());

                if (user_obj.rolelist.Length > 0)
                {
                    user_obj.rolemenulist = GetAllMenuListByroleid(user_obj.rolelist);
                }
                else
                    user_obj.rolemenulist = new ArrayList();
            }
            return user_obj; //找不到该用户
        }

        public CUserInfo GetUserInfoObject(string username, string Password)
        {
            Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "MD5");
            Mis.BLL.ptgl.SYS_USERS handle = new Mis.BLL.ptgl.SYS_USERS();
            DataSet ds = handle.GetList("USERNAME='" + username + "' ");
            CUserInfo user_obj = new CUserInfo();

            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                user_obj.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                user_obj.Username = ds.Tables[0].Rows[0]["USERNAME"].ToString();
                user_obj.Realname = ds.Tables[0].Rows[0]["USERREALNAME"].ToString();
                user_obj.DepartmentID = ds.Tables[0].Rows[0]["DEPTID"].ToString();
                user_obj.phone = ds.Tables[0].Rows[0]["MOBILEPHONE"].ToString() + "," + ds.Tables[0].Rows[0]["PHONENO"].ToString();

                string sql_str = "select deptno from sys_department t where syslevel=0";
                object objcompanyid = PageDBHelper.GetSingleBySql(sql_str);
                if (objcompanyid != null && objcompanyid.ToString() != "")
                {
                    user_obj.CompanyID = objcompanyid.ToString();
                }
                else
                    user_obj.CompanyID = "1";

            }
            return user_obj; //找不到该用户
        }

        /// <summary>
        /// 所有的权限列表
        /// </summary>
        /// <param name="p_roleidlist"></param>
        /// <returns></returns>
        public ArrayList GetAllMenuListByroleid(string p_roleidlist)
        {
            string sql_str = "select distinct(menuid) as menuid from sys_roleplmenusrights t where roleplid in (" + p_roleidlist + ") ";
            DataSet ds = GetDataSetBySql(sql_str);
            ArrayList allinfos = new ArrayList();
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string p_menuidstr = ds.Tables[0].Rows[i]["menuid"].ToString();
                    allinfos.Add(p_menuidstr);
                }
            }
            return allinfos;
        }

        private DataSet GetDataSetBySql(string p_sql)
        {
            return PageBaseFun.PageDBHelper.GetDataSetBySql(p_sql);
        }

        #endregion
    }
}
