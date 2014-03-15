using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using System.Collections;
using Mis.DALFactory.ptgl;
using Mis.IDAL.Post;

namespace Mis.BLL.ptgl
{

    /// <summary>
    /// 业务逻辑类 SYSVISIT_LOG 的摘要说明。
    /// </summary>
    public class SYSVISIT_LOG
    {
        private static readonly ISYSVISIT_LOG dal = DataAccess.CreateSYSVISIT_LOG();
        public SYSVISIT_LOG()
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
        public bool Existsmodel(Djdw.Model.Post.SYSVISIT_LOG model)
        {
            return dal.Existsmodel(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Djdw.Model.Post.SYSVISIT_LOG model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 增加一条数据(null)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNotall(Djdw.Model.Post.SYSVISIT_LOG model)
        {
            return dal.AddNotall(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Djdw.Model.Post.SYSVISIT_LOG model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 事务处理更新一条数据
        /// </summary>
        public DictionaryEntry Updatesql(Djdw.Model.Post.SYSVISIT_LOG model)
        {
            return dal.Updatesql(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdateNotall(Djdw.Model.Post.SYSVISIT_LOG model)
        {
            return dal.UpdateNotall(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            return dal.Delete(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Djdw.Model.Post.SYSVISIT_LOG GetModel(int ID)
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
        public Djdw.Model.Post.SYSVISIT_LOG ToLocalData(DataRow row)
        {
            Djdw.Model.Post.SYSVISIT_LOG data = new Djdw.Model.Post.SYSVISIT_LOG();
            data.ID = int.Parse(row["ID"].ToString());
            data.IP = (string)row["IP"].ToString();
            data.DATTIM = (string)row["DATTIM"].ToString();
            data.MAC = (string)row["MAC"].ToString();
            data.URL = (string)row["URL"].ToString();
            return data;
        }

        /// <summary>
        ///定位数据表 
        /// </summary>
        /// <param name="table">数据表DataTable</param>
        /// <returns>返回Data[]数组</returns>
        public Djdw.Model.Post.SYSVISIT_LOG[] ToLocalData(DataTable table)
        {
            Djdw.Model.Post.SYSVISIT_LOG[] userobjs = new Djdw.Model.Post.SYSVISIT_LOG[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                userobjs[i] = ToLocalData(table.Rows[i]);
            }
            return userobjs;
        }


        public Djdw.Model.Post.SYSVISIT_LOG NullToSpace(Djdw.Model.Post.SYSVISIT_LOG item)
        {
            if (item.IP == null)
                item.IP = "";
            if (item.DATTIM == null)
                item.DATTIM = "";
            if (item.MAC == null)
                item.MAC = "";
            if (item.URL == null)
                item.URL = "";
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

        public DictionaryEntry AddSql(Djdw.Model.Post.SYSVISIT_LOG model)
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


