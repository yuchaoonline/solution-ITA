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
using System.Data.OracleClient;

namespace PageBaseFun
{
    /// <summary>
    /// CPermissionScope 的摘要说明
    /// </summary>
    public class CPermissionScope
    {
        public CPermissionScope()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 系统增加资源的时候，设置资源和人员部门的关联-在具体的添加事务中处理
        /// </summary>
        /// <param name="p_restype">资源类别</param>
        /// <param name="p_resid">资源编号</param>
        /// <param name="p_linkerid">相关者ID</param>
        /// <param name="p_linkdeptid">相关部门ID</param>
        /// <returns></returns>
        static public int AddResLinkInfo(string p_restype, string p_resid, string p_linkerid, string p_linkdeptid)
        {
            string sql_str = "insert into sys_respermissionscope(id,restype,resid,linkerid,linkdeptid) values (SEQSYS_RESPERMISSIONSCOPE.NEXTVAL,'" + p_restype + "','" + p_resid + "','" + p_linkerid + "','" + p_linkdeptid + "')";
            return PageDBHelper.ExecuteSql(sql_str);
        }

        /// <summary>
        /// 系统增加资源的时候，设置资源和人员部门的关联-在具体的添加事务的中间数据
        /// </summary>
        /// <param name="p_restype">资源类别</param>
        /// <param name="p_resid">资源编号</param>
        /// <param name="p_linkerid">相关者ID</param>
        /// <param name="p_linkdeptid">相关部门ID</param>
        /// <returns></returns>
        static public DictionaryEntry AddResLinkInfoSql(string p_restype, string p_resid, string p_linkerid, string p_linkdeptid)
        {
            string sql_str = "insert into sys_respermissionscope(id,restype,resid,linkerid,linkdeptid) values (SEQSYS_RESPERMISSIONSCOPE.NEXTVAL,'" + p_restype + "','" + p_resid + "','" + p_linkerid + "','" + p_linkdeptid + "')";
            OracleParameter[] parameters = new OracleParameter[0];
            DictionaryEntry ret_boj = new DictionaryEntry(sql_str, parameters);
            return ret_boj;
        }

        /// <summary>
        /// 系统删除资源的时候，删除资源和人员部门的关联-在具体的添加事务中处理
        /// </summary>
        /// <param name="p_restype">资源类别</param>
        /// <param name="p_resid">资源编号</param>
        /// <param name="p_linkerid">相关者ID</param>
        /// <returns></returns>
        static public int DelResLinkInfo(string p_restype, string p_resid, string p_linkerid)
        {
            string sql_str = "delete from sys_respermissionscope where restype='" + p_restype + "' and resid='" + p_resid + "' and linkerid='" + p_linkerid + "'";
            return PageDBHelper.ExecuteSql(sql_str);
        }

        /// <summary>
        /// 系统删除资源的时候，删除资源和人员部门的关联-在具体的添加事务的中间数据
        /// </summary>
        /// <param name="p_restype">资源类别</param>
        /// <param name="p_resid">资源编号</param>
        /// <param name="p_linkerid">相关者ID</param>
        /// <returns></returns>
        static public DictionaryEntry DelResLinkInfoSql(string p_restype, string p_resid, string p_linkerid)
        {
            string sql_str = "delete from sys_respermissionscope where restype='" + p_restype + "' and resid='" + p_resid + "' and linerid='" + p_linkerid + "'";
            OracleParameter[] parameters = new OracleParameter[0];
            DictionaryEntry ret_boj = new DictionaryEntry(sql_str, parameters);
            return ret_boj;
        }


        /// <summary>
        /// 获取该操作范围的ID编号
        /// </summary>
        /// <param name="p_permissionScopeCode"></param>
        /// <returns></returns>
        static public string Get_permissionScopeCodeID(string p_permissionScopeCode)
        {
            string sql_str = "select id from sys_moudleaction t where t.description ='" + p_permissionScopeCode + "' and t.isofdatafilter=2";
            object ret_obj = PageDBHelper.GetSingleBySql(sql_str);
            if (ret_obj != null)
            {
                return ret_obj.ToString();
            }
            else
                return "";
        }

        /// <summary>
        /// 获取动作的ID编号
        /// </summary>
        /// <param name="p_permissionScopeCode"></param>
        /// <returns></returns>
        static public string Get_ActionCodeID(string p_ActionCode)
        {
            string sql_str = "select id from sys_moudleaction t where t.description ='" + p_ActionCode + "' and t.isofdatafilter=1";
            object ret_obj = PageDBHelper.GetSingleBySql(sql_str);
            if (ret_obj != null)
            {
                return ret_obj.ToString();
            }
            else
                return "";
        }



        private void sys_department_tree(string parentid, ArrayList p_deptidlist)
        {
            p_deptidlist.Add(parentid);
            string sql_str = "select id from sys_department  where parentid=" + parentid;
            DataSet ds = PageDBHelper.GetDataSetBySql(sql_str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string id_str = ds.Tables[0].Rows[i]["id"].ToString();
                    sys_department_tree(id_str, p_deptidlist);
                }
            }
        }


        private string[] GetOrganizeIDsByPermission(CUserInfo p_userinfo, string p_userinfoid, string p_permissionScopeCode)
        {
            //第一步：获取该操作范围的ID编号
            string _permissionScopeCodeID = CPermissionScope.Get_permissionScopeCodeID(p_permissionScopeCode);
            if (_permissionScopeCodeID == "")
            {
                return null;
            }
            //第二步：获取该用户和该操作ID的关系
            string sql_str = "select rightscopetype from sys_datasetright where DATASETRIGHTID='" + _permissionScopeCodeID + "' and USERID='" + p_userinfoid + "'";
            object rightscopetype = PageDBHelper.GetSingleBySql(sql_str);
            if (rightscopetype != null && rightscopetype.ToString() != "")
            {
                //1 所有数据 2 全公司数据 3 所在部门 4 所在工作组 5 仅本人 6 按明细设置 7 无 
                if (rightscopetype.ToString().CompareTo("1") == 0)
                {
                    //1 所有数据
                    ArrayList p_deptidlist = new ArrayList();
                    sys_department_tree(p_userinfo.CompanyID, p_deptidlist);
                    string[] ret_strlist = new string[p_deptidlist.Count];
                    for (int i = 0; i < p_deptidlist.Count; i++)
                    {
                        ret_strlist[i] = p_deptidlist[i].ToString();
                    }
                    return ret_strlist;

                }
                else if (rightscopetype.ToString().CompareTo("2") == 0)
                {
                    //2 全公司数据
                    ArrayList p_deptidlist = new ArrayList();
                    sys_department_tree(p_userinfo.CompanyID, p_deptidlist);
                    string[] ret_strlist = new string[p_deptidlist.Count];
                    for (int i = 0; i < p_deptidlist.Count; i++)
                    {
                        ret_strlist[i] = p_deptidlist[i].ToString();
                    }
                    return ret_strlist;
                }
                else if (rightscopetype.ToString().CompareTo("3") == 0)
                {
                    //3 所在部门
                    ArrayList p_deptidlist = new ArrayList();
                    sys_department_tree(p_userinfo.DepartmentID, p_deptidlist);
                    string[] ret_strlist = new string[p_deptidlist.Count];
                    for (int i = 0; i < p_deptidlist.Count; i++)
                    {
                        ret_strlist[i] = p_deptidlist[i].ToString();
                    }
                    return ret_strlist;
                }
                else if (rightscopetype.ToString().CompareTo("4") == 0)
                {
                    //4 所在工作组
                    return null;
                }
                else if (rightscopetype.ToString().CompareTo("5") == 0)
                {
                    //5 仅本人
                    return null;
                }
                else if (rightscopetype.ToString().CompareTo("6") == 0)
                {
                    //6 按明细设置
                    sql_str = "select detailid from sys_datasetright where DATASETRIGHTID='" + _permissionScopeCodeID + "' and USERID='" + p_userinfoid + "' and detailtype=1";
                    DataSet ds = PageDBHelper.GetDataSetBySql(sql_str);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string[] ret_strlist = new string[ds.Tables[0].Rows.Count];
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            string id_str = ds.Tables[0].Rows[i]["detailid"].ToString();
                            ret_strlist[i] = id_str;
                        }
                        return ret_strlist;
                    }
                    else
                        return null;
                }
                else if (rightscopetype.ToString().CompareTo("7") == 0)
                {
                    //7 无
                    return null;
                }
                else
                    return null;
            }
            else
                return null;
        }


        private string[] GetUserIDsByPermission(CUserInfo p_userinfo, string p_userinfoid, string p_permissionScopeCode)
        {

            //第一步：获取该操作范围的ID编号
            string _permissionScopeCodeID = CPermissionScope.Get_permissionScopeCodeID(p_permissionScopeCode);
            if (_permissionScopeCodeID == "")
            {
                return null;
            }
            //第二步：获取该用户和该操作ID的关系
            string sql_str = "select rightscopetype from sys_datasetright where DATASETRIGHTID='" + _permissionScopeCodeID + "' and USERID='" + p_userinfoid + "'";
            object rightscopetype = PageDBHelper.GetSingleBySql(sql_str);
            if (rightscopetype != null && rightscopetype.ToString() != "")
            {
                //1 所有数据 2 全公司数据 3 所在部门 4 所在工作组 5 仅本人 6 按明细设置 7 无 
                if (rightscopetype.ToString().CompareTo("1") == 0)
                {
                    //1 所有数据
                    return null;
                }
                else if (rightscopetype.ToString().CompareTo("2") == 0)
                {
                    //2 全公司数据
                    return null;
                }
                else if (rightscopetype.ToString().CompareTo("3") == 0)
                {
                    //3 所在部门
                    return null;
                }
                else if (rightscopetype.ToString().CompareTo("4") == 0)
                {
                    //4 所在工作组
                    return null;
                }
                else if (rightscopetype.ToString().CompareTo("5") == 0)
                {
                    //5 仅本人
                    string[] ret_strlist = new string[1];
                    ret_strlist[0] = p_userinfoid;
                    return ret_strlist;
                }
                else if (rightscopetype.ToString().CompareTo("6") == 0)
                {
                    //6 按明细设置
                    sql_str = "select detailid from sys_datasetright where DATASETRIGHTID='" + _permissionScopeCodeID + "' and USERID='" + p_userinfoid + "' and detailtype=2";
                    DataSet ds = PageDBHelper.GetDataSetBySql(sql_str);
                    
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string[] ret_strlist = new string[ds.Tables[0].Rows.Count];
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            string id_str = ds.Tables[0].Rows[i]["detailid"].ToString();
                            ret_strlist[i] = id_str;
                        }
                        return ret_strlist;
                    }
                    else
                        return null;
                }
                else if (rightscopetype.ToString().CompareTo("7") == 0)
                {
                    //7 无
                    return null;
                }
                else
                    return null;
            }
            else
                return null;
        }


        public ArrayList GetInfoIDsByPermission(CUserInfo p_userinfo, string p_userinfoid, string p_permissionScopeCode, string p_tablenameinfo)
        {
            string[] _OrganizeIDs = GetOrganizeIDsByPermission(p_userinfo, p_userinfoid, p_permissionScopeCode);
            string[] _UserIDs = GetUserIDsByPermission(p_userinfo, p_userinfoid, p_permissionScopeCode);
            string sql_str = GetSqlStrByOrgUser(_OrganizeIDs, _UserIDs, p_tablenameinfo);

            ArrayList ret_list = new ArrayList();
            if (sql_str != "")
            {
                DataSet ds = PageDBHelper.GetDataSetBySql(sql_str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string id_str = ds.Tables[0].Rows[i]["resid"].ToString();
                        ret_list.Add(id_str);
                    }
                }
                return ret_list;
            }
            else
                return ret_list;
        }


        private string GetSqlStrByOrgUser(string[] _OrganizeIDs, string[] _UserIDs, string p_tablenameinfo)
        {
            string str_OrganizeIDs = "";
            if (_OrganizeIDs != null)
            {
                for (int i = 0; i < _OrganizeIDs.Length; i++)
                {
                    str_OrganizeIDs += _OrganizeIDs[i];
                    str_OrganizeIDs += ",";
                }
                if (str_OrganizeIDs.Length > 0)
                {
                    str_OrganizeIDs = str_OrganizeIDs.Substring(0, str_OrganizeIDs.Length - 1);
                }
            }

            string str_UserIDs = "";
            if (_UserIDs != null)
            {
                for (int i = 0; i < _UserIDs.Length; i++)
                {
                    str_UserIDs += _UserIDs[i];
                    str_UserIDs += ",";
                }
                if (str_UserIDs.Length > 0)
                {
                    str_UserIDs = str_UserIDs.Substring(0, str_UserIDs.Length - 1);
                }
            }
            //////////////////////////////
            if (str_OrganizeIDs == "" && str_UserIDs == "")
            {
                return "";
            }
            else if (str_OrganizeIDs != "" && str_UserIDs != "")
            {
                string sql_str = "select resid from sys_respermissionscope  where restype='" + p_tablenameinfo + "' and (linkerid in (" + str_UserIDs + ") or linkdeptid in (" + str_OrganizeIDs + "))";
                return sql_str;
            }
            else
            {
                if (str_OrganizeIDs != "")
                {
                    string sql_str = "select resid from sys_respermissionscope  where restype='" + p_tablenameinfo + "' and  linkdeptid in (" + str_OrganizeIDs + ")";
                    return sql_str;
                }
                if (str_UserIDs != "")
                {
                    string sql_str = "select resid from sys_respermissionscope  where restype='" + p_tablenameinfo + "' and linkerid in (" + str_UserIDs + ")";
                    return sql_str;
                }
                return "";

            }//
        }


        static public bool IsAuthorizedInaction(string p_roleliststr, string p_actioncode)
        {
            //第一步：获取该操作范围的ID编号
            string p_actionid = CPermissionScope.Get_ActionCodeID(p_actioncode);
            if (p_actionid == "")
            {
                return false;
            }
            //第二步：判断权限
            string sql_str = "select id from sys_roleactrights t where  rolesname=1 and type=1 and actionid='" + p_actionid + "' and roleplid in (" + p_roleliststr + ")";
            DataSet ds = PageDBHelper.GetDataSetBySql(sql_str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }

    }

}