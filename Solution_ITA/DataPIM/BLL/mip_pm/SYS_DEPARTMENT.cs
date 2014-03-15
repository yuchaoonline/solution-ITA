using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using System.Collections;
using  Mis.DALFactory.ptgl;
using Mis.IDAL.Post;

namespace Mis.BLL.ptgl
{

    /// <summary>
    /// 业务逻辑类 SYS_DEPARTMENT 的摘要说明。
    /// </summary>
    public class SYS_DEPARTMENT
    {
        private static readonly ISYS_DEPARTMENT dal = DataAccess.CreateSYS_DEPARTMENT();
        public SYS_DEPARTMENT()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 是否存在该记录strwhere
        /// </summary>
        public bool Exists(string strwhere)
        {
            return dal.Exists(strwhere);
        }

        /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(Mis.Model.ptgl.SYS_DEPARTMENT model)
        {
            return dal.Existsmodel(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Mis.Model.ptgl.SYS_DEPARTMENT model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 增加一条数据(null)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNotall(Mis.Model.ptgl.SYS_DEPARTMENT model)
        {
            return dal.AddNotall(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Mis.Model.ptgl.SYS_DEPARTMENT model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdateNotall(Mis.Model.ptgl.SYS_DEPARTMENT model)
        {
            return dal.UpdateNotall(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            //将部门删除、会删除掉部门下的自部门和用户
            return dal.Delete(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mis.Model.ptgl.SYS_DEPARTMENT GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 定位数据行
        /// </summary>
        /// <param name="row">数据行</param>
        /// <returns>返回Data</returns>
        public Mis.Model.ptgl.SYS_DEPARTMENT ToLocalData(DataRow row)
        {
            Mis.Model.ptgl.SYS_DEPARTMENT data = new Mis.Model.ptgl.SYS_DEPARTMENT();
            data.ID = int.Parse(row["ID"].ToString());
            data.DEPTNO = (string)row["DEPTNO"].ToString();
            data.DEPTNAME = (string)row["DEPTNAME"].ToString();
            data.SYSLEVEL = (string)row["SYSLEVEL"].ToString();
            data.PARENTID = int.Parse(row["PARENTID"].ToString());
            data.DESCRIPTION = (string)row["DESCRIPTION"].ToString();
            return data;
        }

        /// <summary>
        ///定位数据表 
        /// </summary>
        /// <param name="table">数据表DataTable</param>
        /// <returns>返回Data[]数组</returns>
        public Mis.Model.ptgl.SYS_DEPARTMENT[] ToLocalData(DataTable table)
        {
            Mis.Model.ptgl.SYS_DEPARTMENT[] userobjs = new Mis.Model.ptgl.SYS_DEPARTMENT[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                userobjs[i] = ToLocalData(table.Rows[i]);
            }
            return userobjs;
        }


        public Mis.Model.ptgl.SYS_DEPARTMENT NullToSpace(Mis.Model.ptgl.SYS_DEPARTMENT item)
        {
            if (item.DEPTNO == null)
                item.DEPTNO = "";
            if (item.DEPTNAME == null)
                item.DEPTNAME = "";
            if (item.SYSLEVEL == null)
                item.SYSLEVEL = "";
            if (item.DESCRIPTION == null)
                item.DESCRIPTION = "";
            return item;
        }


        public DataTable GetTable(string strWhere)
        {
            DataSet dts = GetList(strWhere);
            DataTable tb = dts.Tables[0];
            return tb;
        }

        /// <summary>
        /// 获得所有数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return dal.GetList("");
        }

        public DictionaryEntry AddSql(Mis.Model.ptgl.SYS_DEPARTMENT model)
        {
            return dal.AddSql(model);
        }

        public DictionaryEntry DeleteSql(int ID)
        {
            return dal.DeleteSql(ID);
        }

        public int ExecuteTrans(Hashtable tb)
        {
            return dal.ExecuteTrans(tb);
        }

        public int ExecuteSqlTranByArray(ArrayList SQLStringList)
        {
            return dal.ExecuteSqlTranByArray(SQLStringList);
        }

        /// <summary>
        /// 是不是double
        /// </summary>
        /// <returns></returns>
        public bool isofdouble(string content)
        {
            string ValidChars = ".0123456789";
            char Char;
            string sText = content;
            char[] sChar = sText.ToCharArray(0, sText.Length);
            for (int i = 0; i < sText.Length; i++)
            {
                Char = sChar[i];
                if (ValidChars.IndexOf(Char) == -1)
                {
                    return false;
                }
            }
            if (content.IndexOf(".") != content.LastIndexOf("."))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 是不是全是数字
        /// </summary>
        /// <returns></returns>
        public bool isofnumber(string content)
        {
            string ValidChars = "0123456789";
            char Char;
            string sText = content;
            char[] sChar = sText.ToCharArray(0, sText.Length);
            for (int i = 0; i < sText.Length; i++)
            {
                Char = sChar[i];
                if (ValidChars.IndexOf(Char) == -1)
                {
                    return false;
                }
            }
            return true;
        }


        public bool IsofHadUser(string all_delete_deptid)
        {
            string str_sql = "select id from sys_users where deptid in "+all_delete_deptid;
            DataSet ds = DBUtility.DbHelperOra.Query(str_sql);
            if(ds!=null && ds.Tables[0]!=null && ds.Tables[0].Rows.Count>0)
            {
                return true;
            }
            else
                return false;
        }


        public int DeltNodes(ArrayList ids)
        {
            try
            {
                ArrayList allsublist = new ArrayList();
                for (int i = 0; i < ids.Count; i++)
                {
                    int ID = int.Parse(ids[i].ToString());
                    GetAllSubDepart(ID,allsublist);
                }
                /////////////////////////////////////
                string all_delete_deptid = "";
                for(int i = 0;i<allsublist.Count;i++)
                {
                    all_delete_deptid+=allsublist[i].ToString()+",";
                }
                for(int i = 0;i<ids.Count;i++)
                {
                    all_delete_deptid+=ids[i].ToString()+",";
                }
                if(all_delete_deptid!="")
                {
                    all_delete_deptid = "("+all_delete_deptid.Substring(0,all_delete_deptid.Length-1)+")";
                    if(true == IsofHadUser(all_delete_deptid) )
                    {
                        return -2;//部门已经配置了用户，需要先删除这些部门下的用户
                    }
                    else
                    {
                        string delete_sql = "delete from sys_department where id in"+ all_delete_deptid;
                        return DBUtility.DbHelperOra.ExecuteSql(delete_sql);
                    }
                }
            }
            catch
            {
                return -1;
            }
            return 1;

        }

        public void GetAllSubDepart(int p_parentid,ArrayList p_ids)
        {
            string str_sql = "select id from sys_department t where t.parentid = "+p_parentid;
            DataSet ds = DBUtility.DbHelperOra.Query(str_sql);
            if(ds!=null && ds.Tables[0]!=null && ds.Tables[0].Rows.Count>0)
            {
                for(int i = 0; i<ds.Tables[0].Rows.Count;i++)
                {
                    int sub_deptid = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                    GetAllSubDepart(sub_deptid,p_ids);
                    p_ids.Add(sub_deptid);
                }
            }
        }

       
        #endregion  成员方法
    }
}


