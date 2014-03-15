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
using PageBaseFun;

/// <summary>
/// CePage 的摘要说明
/// </summary>
/// 
namespace System.Web.UI
{
    public class CePage : System.Web.UI.Page
    {
        /*
         关闭整个框架转到其他页面 

        一.带提示的转出到别的页面 同时关闭整个框架 

        <a href="#" LANGUAGE="javascript" onclick="if (confirm('确认要离开本系统?')){;href='logout.aspx';target='_top';}">转出系统</a> 

        二.没有提示关闭框架 转到指定页面. 
        <a href="#" LANGUAGE=javascript onclick="{href='../default.aspx';target='_top';}">返回首页</A> 

        三.直接关闭框架网页 
        <a href="javascript:window.opener=null;window.parent.close()">关闭系统</a> 

         */

        public CePage()
        {

        }

        protected override void OnInit(EventArgs e)
        {

        }



        protected void _isallowaccess(string SystemID, string PageID, string ActionID)
        {
            if (Session["userobj"] != null)
            {
                user userobj = (user)Session["userobj"];

                for (int i = 0; i < userobj.rolemenulist.Count; i++)
                {
                    if (userobj.rolemenulist[i].ToString().CompareTo(PageID) == 0)
                        return;
                }
            }
            Response.Write("目前你无权浏览该网页!");
            Response.End();
        }


        protected void _isReLogin()
        {
            if (Session["userobj"] != null)
            {
                return;
            }
            Response.Write("时间过长，请退出本系统重新登录!");
            Response.End();
        }


        protected string _GetNowUserID()
        {
            if (Session["userobj"] != null)
            {
                user userobj = (user)Session["userobj"];

                return userobj.id.ToString();
            }
            return "";
        }

        protected string _GetNowUserName()
        {
            if (Session["userobj"] != null)
            {
                user userobj = (user)Session["userobj"];
                return userobj.realname;
            }
            return "";
        }

        protected string _GetNowUserPhone()
        {
            if (Session["userobj"] != null)
            {
                user userobj = (user)Session["userobj"];
                return userobj.phone;
            }
            return "";
        }

        protected string _GetSysUserName()
        {
            if (Session["userobj"] != null)
            {
                user userobj = (user)Session["userobj"];
                return userobj.uid;
            }
            return "";
        }

        protected string _GetNowRequestIp()
        {
            return Page.Request.UserHostAddress;
        }

        protected string _GetNowWorkArea()
        {
            if (Session["userobj"] != null)
            {
                user _userobj = (user)Session["userobj"];
                return _userobj.WorkArea;
            }
            return "";
        }

        protected string _GetNowDepartMent()
        {
            if (Session["userobj"] != null)
            {
                user _userobj = (user)Session["userobj"];
                return _userobj.Department;
            }
            return "";
        }

        protected string _GetNowDepartMentID()
        {
            if (Session["userobj"] != null)
            {
                user _userobj = (user)Session["userobj"];
                return _userobj.DepartmentID;
            }
            return "";
        }

        protected string _GetNowRoles()
        {
            if (Session["userobj"] != null)
            {
                user _userobj = (user)Session["userobj"];
                return _userobj.rolelist;
            }
            return "";
        }

        protected string _GetMngCityList()
        {
            if (Session["userobj"] != null)
            {
                user _userobj = (user)Session["userobj"];

                Mis.BLL.ptgl.SYS_USERS handle = new Mis.BLL.ptgl.SYS_USERS();
                Mis.Model.ptgl.SYS_USERS model = handle.GetModel(_userobj.id);
                return model.REMARK5;
            }
            return "";
        }

        protected string _GetMngProList()
        {
            if (Session["userobj"] != null)
            {
                user _userobj = (user)Session["userobj"];

                Mis.BLL.ptgl.SYS_USERS handle = new Mis.BLL.ptgl.SYS_USERS();
                Mis.Model.ptgl.SYS_USERS model = handle.GetModel(_userobj.id);
                return model.REMARK6;
            }
            return "";
        }

        protected string[] _GetMngUserStatusList()
        {
            if (Session["userobj"] != null)
            {
                user _userobj = (user)Session["userobj"];

                Mis.BLL.ptgl.SYS_USERS handle = new Mis.BLL.ptgl.SYS_USERS();
                Mis.Model.ptgl.SYS_USERS model = handle.GetModel(_userobj.id);
                string[] ret_value = new string[3];
                ret_value[0] = "";
                ret_value[1] = "";
                ret_value[2] = "";

                if (model.REMARK4 != "")
                {
                    string[] p_valuelist = model.REMARK4.Split('|');
                    if (p_valuelist.Length >= 1)
                    {
                        ret_value[0] = p_valuelist[0];
                    }
                    if (p_valuelist.Length >= 2)
                    {
                        ret_value[1] = p_valuelist[1];
                    }
                    if (p_valuelist.Length >= 3)
                    {
                        ret_value[2] = p_valuelist[2];
                    }
                }
                return ret_value;
            }
            return null;
        }

        protected string[] _GetMngTmMaxnumList()
        {
            if (Session["userobj"] != null)
            {
                user _userobj = (user)Session["userobj"];

                Mis.BLL.ptgl.SYS_USERS handle = new Mis.BLL.ptgl.SYS_USERS();
                Mis.Model.ptgl.SYS_USERS model = handle.GetModel(_userobj.id);
                string[] ret_value = new string[2];
                ret_value[0] = "00,00,00,00";
                ret_value[1] = "0";

                if (model.REMARK4 != "")
                {
                    string[] p_valuelist = model.REMARK4.Split('|');
                    if (p_valuelist.Length >= 5)
                    {
                        ret_value[0] = p_valuelist[3].Trim();
                        ret_value[1] = p_valuelist[4].Trim();
                    }
                }
                return ret_value;
            }
            return null;
        }

        protected string _GetRoleTypeListStr()
        {
            if (Session["userobj"] != null)
            {
                user _userobj = (user)Session["userobj"];
                string ret_str = "";
                for (int i = 0; i < _userobj.roledatatypelist.Count; i++)
                {
                    ret_str += _userobj.roledatatypelist[i].ToString();
                    ret_str += ",";
                }
                if (ret_str.Length > 0)
                {
                    return ret_str.Substring(0, ret_str.Length - 1);
                }
            }
            return "";
        }

        protected bool _IsofInRoleTypeList(string p_RoleType)
        {
            if (Session["userobj"] != null)
            {
                user _userobj = (user)Session["userobj"];
                for (int i = 0; i < _userobj.roledatatypelist.Count; i++)
                {
                    if (p_RoleType.CompareTo(_userobj.roledatatypelist[i].ToString()) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected CUserInfo _GetUserInfoObj()
        {
            if (Session["userinfoobj"] != null)
            {
                CUserInfo _userinfoobj = (CUserInfo)Session["userinfoobj"];
                return _userinfoobj;
            }
            return null;
        }
        ////////////////////

        protected bool _IsAuthorizedInaction(string p_actioncode)
        {
            string roleliststr = _GetNowRoles();
            if (roleliststr == "") return false;
            else
            {
                return CPermissionScope.IsAuthorizedInaction(roleliststr, p_actioncode);
            }
        }
        //

        protected bool _AddResLinkInfo(string p_restype, string p_resid)
        {
            CUserInfo _userinfoobj = _GetUserInfoObj();
            if (_userinfoobj == null) return false;
            string p_linkerid = _userinfoobj.ID;
            string p_linkdeptid = _userinfoobj.DepartmentID;
            int ret_value = CPermissionScope.AddResLinkInfo(p_restype, p_resid, p_linkerid, p_linkdeptid);
            if (ret_value > 0) return true;
            else return false;
        }

        protected bool _DelResLinkInfo(string p_restype, string p_resid)
        {
            CUserInfo _userinfoobj = _GetUserInfoObj();
            if (_userinfoobj == null) return false;
            string p_linkerid = _userinfoobj.ID;
            string p_linkdeptid = _userinfoobj.DepartmentID;
            int ret_value = CPermissionScope.DelResLinkInfo(p_restype, p_resid, p_linkerid);
            if (ret_value > 0) return true;
            else return false;
        }

        protected DataTable _FilterDataTable(DataTable p_selecttable, string p_permissionScopeCode, string p_tablenameinfo)
        {
            CUserInfo p_userinfo = _GetUserInfoObj();
            if (p_userinfo == null)
            {
                DataTable ret_tb = p_selecttable.Copy();
                ret_tb.Rows.Clear();
                return ret_tb;
            }
            else
            {
                string p_userinfoid = p_userinfo.ID;

                CPermissionScope PermissionScopeHanle = new CPermissionScope();
                ArrayList filteridlist = PermissionScopeHanle.GetInfoIDsByPermission(p_userinfo, p_userinfoid, p_permissionScopeCode, p_tablenameinfo);
                //
                DataRow[] drs = p_selecttable.Select();
                DataTable ret_tb = p_selecttable.Copy();
                ret_tb.Rows.Clear();
                foreach (DataRow dr in drs)
                {
                    if (_IsofInIDList(dr["ID"].ToString(), filteridlist))
                    {
                        DataRow row2 = ret_tb.NewRow();
                        for (int i = 0; i < row2.Table.Columns.Count; i++)
                            row2[i] = dr[i];
                        ret_tb.Rows.Add(row2);
                    }
                }
                return ret_tb;
            }
        }
        //fun

        protected bool _FilterDataAction(string p_idstr, string p_permissionScopeCode, string p_tablenameinfo)
        {
            CUserInfo p_userinfo = _GetUserInfoObj();
            if (p_userinfo == null)
            {
                return false;
            }
            else
            {
                string p_userinfoid = p_userinfo.ID;

                CPermissionScope PermissionScopeHanle = new CPermissionScope();
                ArrayList filteridlist = PermissionScopeHanle.GetInfoIDsByPermission(p_userinfo, p_userinfoid, p_permissionScopeCode, p_tablenameinfo);
                //
                return _IsofInIDList(p_idstr, filteridlist);
            }
        }
        //fun

        private bool _IsofInIDList(string p_idstr, ArrayList p_filteridlist)
        {
            for (int i = 0; i < p_filteridlist.Count; i++)
            {
                if (p_idstr.CompareTo(p_filteridlist[i].ToString()) == 0)
                    return true;
            }
            return false;
        }

        protected int AddLog(string p_opname)
        {
            CUserInfo _userobj = _GetUserInfoObj();
            if (_userobj != null)
            {
                gtled.Model.Post.SYS_OPLOG oplogmodel = new gtled.Model.Post.SYS_OPLOG();
                oplogmodel.OPTIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                oplogmodel.REMARK = "";
                oplogmodel.REMARK1 = "";
                oplogmodel.OPTYPE = p_opname;
                oplogmodel.USERID = _userobj.Username;
                oplogmodel.USERNAME = _userobj.Realname;
                Mis.BLL.ptgl.SYS_OPLOG oploghandle = new Mis.BLL.ptgl.SYS_OPLOG();

                return oploghandle.Add(oplogmodel);
            }
            else
                return -1;
        }

        /// <summary>
        /// 获取管理的示范区列表
        /// </summary>
        /// <returns></returns>
        protected CUserHxRight _GetMngSAList()
        {
            CUserHxRight userhxright = new CUserHxRight();
            if (Session["userobj"] != null)
            {
                user _userobj = (user)Session["userobj"];

                string[] userrolelist = _userobj.rolelist.Split(',');
                for (int i = 0; i < userrolelist.Length; i++)
                {
                    if (userrolelist[i] == "1")
                    {
                        //系统管理员
                        userhxright.isof_sysadmin = true;
                    }
                    if (userrolelist[i] == "2")
                    {
                        //群组管理员
                        userhxright.isof_qzadmin = true;
                    }
                    if (userrolelist[i] == "3")
                    {
                        //小群组管理员
                        userhxright.isof_xqzadmin = true;
                    }
                }//for
                /////////////////////////////////////////////
                if (userhxright.isof_sysadmin == true)
                {
                    return userhxright;
                }
                if (userhxright.isof_qzadmin == true || userhxright.isof_xqzadmin == true)
                {
                    //xxty.BLL.Post.XXTY_SHOWAREA_INFO _sahandle = new xxty.BLL.Post.XXTY_SHOWAREA_INFO();
                    //xxty.BLL.Post.XXTY_SHOWAREA_INFO_MNGDF handle = new xxty.BLL.Post.XXTY_SHOWAREA_INFO_MNGDF();
                    //ArrayList allist = handle.GetFilterListByUserID(_userobj.id.ToString());
                    //userhxright.mng_saliststr = "";
                    //for (int i = 0; i < allist.Count; i++)
                    //{
                    //    xxty.Model.Post.XXTY_SHOWAREA_INFO_MNGDF mngdf_obj = (xxty.Model.Post.XXTY_SHOWAREA_INFO_MNGDF)allist[i];
                    //    xxty.Model.Post.XXTY_SHOWAREA_INFO _samodel = _sahandle.GetModel(int.Parse(mngdf_obj.SHOWAREAID));
                    //    userhxright.mng_saliststr += "'" + _samodel.CODE + "',";
                    //}
                    //if (userhxright.mng_saliststr.Length > 0)
                    //{
                    //    userhxright.mng_saliststr = userhxright.mng_saliststr.Substring(0, userhxright.mng_saliststr.Length - 1);
                    //}
                    return userhxright;
                }
                return userhxright;

            }//if
            else
                return userhxright;
        }

    }//class
}
