using System;
using System.Data;
 using System.Text;
 using System.Data.OracleClient;
 using System.Collections;
using  hbapp.IDAL.ghdata;
using Mis.DALFactory.ptgl;
namespace hbapp.BLL.ghdata
{

    /// <summary>
    /// 业务逻辑类 GH_TASKINFO 的摘要说明。
    /// </summary>
    public class GH_TASKINFO
    {
        private static readonly IGH_TASKINFO dal = DataAccess.CreateGH_TASKINFO();
        public GH_TASKINFO()
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
        public bool Existsmodel(hbapp.Model.ghdata.GH_TASKINFO model)
        {
            return dal.Existsmodel(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(hbapp.Model.ghdata.GH_TASKINFO model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 增加一条数据(null)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNotall(hbapp.Model.ghdata.GH_TASKINFO model)
        {
            return dal.AddNotall(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(hbapp.Model.ghdata.GH_TASKINFO model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 事务处理更新一条数据
        /// </summary>
        public DictionaryEntry Updatesql(hbapp.Model.ghdata.GH_TASKINFO model)
        {
            return dal.Updatesql(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdateNotall(hbapp.Model.ghdata.GH_TASKINFO model)
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
        public hbapp.Model.ghdata.GH_TASKINFO GetModel(int ID)
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
        public hbapp.Model.ghdata.GH_TASKINFO ToLocalData(DataRow row)
        {
            hbapp.Model.ghdata.GH_TASKINFO data = new hbapp.Model.ghdata.GH_TASKINFO();
            data.ID = int.Parse(row["ID"].ToString());
            data.TASKNO = (string)row["TASKNO"].ToString();
            data.CTVNO = (string)row["CTVNO"].ToString();
            data.TASKNAME = (string)row["TASKNAME"].ToString();
            data.STARTTIME = (string)row["STARTTIME"].ToString();
            data.ENDTIME = (string)row["ENDTIME"].ToString();
            data.TASKTYPE = int.Parse(row["TASKTYPE"].ToString());
            data.ISOFHISTORY = int.Parse(row["ISOFHISTORY"].ToString());
            data.REMARK = (string)row["REMARK"].ToString();
            data.REMARK1 = (string)row["REMARK1"].ToString();
            data.REMARK2 = (string)row["REMARK2"].ToString();
            data.REMARK3 = (string)row["REMARK3"].ToString();
            data.REMARK4 = (string)row["REMARK4"].ToString();
            data.REMARK5 = (string)row["REMARK5"].ToString();
            data.REMARK6 = (string)row["REMARK6"].ToString();
            data.REMARK7 = (string)row["REMARK7"].ToString();
            data.REMARK8 = (string)row["REMARK8"].ToString();
            data.REMARK9 = (string)row["REMARK9"].ToString();
            data.REMARK10 = (string)row["REMARK10"].ToString();
            data.REMARK11 = (string)row["REMARK11"].ToString();
            data.REMARK12 = (string)row["REMARK12"].ToString();
            data.REMARK13 = (string)row["REMARK13"].ToString();
            data.REMARK14 = (string)row["REMARK14"].ToString();
            data.REMARK15 = (string)row["REMARK15"].ToString();
            return data;
        }

        /// <summary>
        ///定位数据表 
        /// </summary>
        /// <param name="table">数据表DataTable</param>
        /// <returns>返回Data[]数组</returns>
        public hbapp.Model.ghdata.GH_TASKINFO[] ToLocalData(DataTable table)
        {
            hbapp.Model.ghdata.GH_TASKINFO[] userobjs = new hbapp.Model.ghdata.GH_TASKINFO[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                userobjs[i] = ToLocalData(table.Rows[i]);
            }
            return userobjs;
        }


        public hbapp.Model.ghdata.GH_TASKINFO NullToSpace(hbapp.Model.ghdata.GH_TASKINFO item)
        {
            if (item.TASKNO == null)
                item.TASKNO = "";
            if (item.CTVNO == null)
                item.CTVNO = "";
            if (item.TASKNAME == null)
                item.TASKNAME = "";
            if (item.STARTTIME == null)
                item.STARTTIME = "";
            if (item.ENDTIME == null)
                item.ENDTIME = "";
            if (item.REMARK == null)
                item.REMARK = "";
            if (item.REMARK1 == null)
                item.REMARK1 = "";
            if (item.REMARK2 == null)
                item.REMARK2 = "";
            if (item.REMARK3 == null)
                item.REMARK3 = "";
            if (item.REMARK4 == null)
                item.REMARK4 = "";
            if (item.REMARK5 == null)
                item.REMARK5 = "";
            if (item.REMARK6 == null)
                item.REMARK6 = "";
            if (item.REMARK7 == null)
                item.REMARK7 = "";
            if (item.REMARK8 == null)
                item.REMARK8 = "";
            if (item.REMARK9 == null)
                item.REMARK9 = "";
            if (item.REMARK10 == null)
                item.REMARK10 = "";
            if (item.REMARK11 == null)
                item.REMARK11 = "";
            if (item.REMARK12 == null)
                item.REMARK12 = "";
            if (item.REMARK13 == null)
                item.REMARK13 = "";
            if (item.REMARK14 == null)
                item.REMARK14 = "";
            if (item.REMARK15 == null)
                item.REMARK15 = "";
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

        public DictionaryEntry AddSql(hbapp.Model.ghdata.GH_TASKINFO model)
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


