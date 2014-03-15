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
    /// 业务逻辑类 SYS_USERS 的摘要说明。
    /// </summary>
    public class SYS_USERS
    {
        private static readonly ISYS_USERS dal = DataAccess.CreateSYS_USERS();
        public SYS_USERS()
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
        public bool Existsmodel(Mis.Model.ptgl.SYS_USERS model)
        {
            return dal.Existsmodel(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Mis.Model.ptgl.SYS_USERS model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 增加一条数据(null)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNotall(Mis.Model.ptgl.SYS_USERS model)
        {
            return dal.AddNotall(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Mis.Model.ptgl.SYS_USERS model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdateNotall(Mis.Model.ptgl.SYS_USERS model)
        {
            return dal.UpdateNotall(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            //将用户删除，会删除掉用户和角色的关系
            ArrayList delete_list = new ArrayList();
            string sql_delete_sys_users = "delete from SYS_USERS where id=" + ID.ToString();
            delete_list.Add(sql_delete_sys_users);
            string sql_delete_sys_roleuser = "delete from sys_roleuser where userid = " + ID.ToString();
            delete_list.Add(sql_delete_sys_roleuser);
            return DBUtility.DbHelperOra.ExecuteSqlTran(delete_list);
            //return dal.Delete(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mis.Model.ptgl.SYS_USERS GetModel(int ID)
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
        public Mis.Model.ptgl.SYS_USERS ToLocalData(DataRow row)
        {
            Mis.Model.ptgl.SYS_USERS data = new Mis.Model.ptgl.SYS_USERS();
            data.ID = int.Parse(row["ID"].ToString());
            data.DEPTID = (string)row["DEPTID"].ToString();
            data.USERNO = (string)row["USERNO"].ToString();
            data.USERREALNAME = (string)row["USERREALNAME"].ToString();
            data.USERNAME = (string)row["USERNAME"].ToString();
            data.PASSWORD = (string)row["PASSWORD"].ToString();
            data.SEX = int.Parse(row["SEX"].ToString());
            data.AGE = int.Parse(row["AGE"].ToString());
            return data;
        }

        /// <summary>
        ///定位数据表 
        /// </summary>
        /// <param name="table">数据表DataTable</param>
        /// <returns>返回Data[]数组</returns>
        public Mis.Model.ptgl.SYS_USERS[] ToLocalData(DataTable table)
        {
            Mis.Model.ptgl.SYS_USERS[] userobjs = new Mis.Model.ptgl.SYS_USERS[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                userobjs[i] = ToLocalData(table.Rows[i]);
            }
            return userobjs;
        }


        public Mis.Model.ptgl.SYS_USERS NullToSpace(Mis.Model.ptgl.SYS_USERS item)
        {
            if (item.DEPTID == null)
                item.DEPTID = "";
            if (item.USERNO == null)
                item.USERNO = "";
            if (item.USERREALNAME == null)
                item.USERREALNAME = "";
            if (item.USERNAME == null)
                item.USERNAME = "";
            if (item.PASSWORD == null)
                item.PASSWORD = "";
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

        public DictionaryEntry AddSql(Mis.Model.ptgl.SYS_USERS model)
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

        #endregion  成员方法
    }
}


