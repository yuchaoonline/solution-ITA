using System;
using System.Data;
using System.Text;
using System.Data.Odbc;
using DBUtility;
using System.Collections;
using Mis.IDAL.Post;

namespace Mis.OdbcDAL.Post
{

    /// <summary>
    /// 数据访问类SYSVISIT_LOG
    /// </summary>
    public class SYSVISIT_LOG : ISYSVISIT_LOG
    {
        public SYSVISIT_LOG()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMysqlOdbc.GetMaxID("ID", "SYSVISIT_LOG");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYSVISIT_LOG");
            strSql.Append(" where ID= ?");
            OdbcParameter[] parameters = {
				new OdbcParameter("@ID", OdbcType.Int)
			};
            parameters[0].Value = ID;
            return DbHelperMysqlOdbc.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYSVISIT_LOG");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID");
            return DbHelperMysqlOdbc.Exists(strSql.ToString(),null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Djdw.Model.Post.SYSVISIT_LOG model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYSVISIT_LOG(");
            strSql.Append("ID,IP,DATTIM,MAC,URL)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? , ? )");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@IP", OdbcType.VarChar,20),
					new OdbcParameter("@DATTIM", OdbcType.DateTime),
					new OdbcParameter("@MAC", OdbcType.VarChar,20),
					new OdbcParameter("@URL", OdbcType.VarChar,256)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.IP;
            parameters[2].Value = model.DATTIM;
            parameters[3].Value = model.MAC;
            parameters[4].Value = model.URL;

            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }

        /// <summary>
        /// 事务处理增加一个model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public DictionaryEntry AddSql(Djdw.Model.Post.SYSVISIT_LOG model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYSVISIT_LOG(");
            strSql.Append("IP,DATTIM,MAC,URL)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? )");
            OdbcParameter[] parameters = {  

					new OdbcParameter("@DATTIM", OdbcType.DateTime),

};
            parameters[0].Value = model.IP;
            parameters[1].Value = model.DATTIM;
            parameters[2].Value = model.MAC;
            parameters[3].Value = model.URL;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(Djdw.Model.Post.SYSVISIT_LOG model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYSVISIT_LOG(");
            strSql.Append("ID");
            //列出需哟插入的表字段
            int Param_Num = 0;
            if (model.IP != "")
            {
                Param_Num++;
                strSql.Append(",IP");
            }
            if (model.DATTIM != "")
            {
                Param_Num++;
                strSql.Append(",DATTIM");
            }
            if (model.MAC != "")
            {
                Param_Num++;
                strSql.Append(",MAC");
            }
            if (model.URL != "")
            {
                Param_Num++;
                strSql.Append(",URL");
            }
            strSql.Append(" ) ");
            strSql.Append(" values (");
            strSql.Append("?");
            //列出需哟插入的表字段value对象 
            if (model.IP != "")
            {
                strSql.Append(",?");
            }
            if (model.DATTIM != "")
            {
                strSql.Append(",?");
            }
            if (model.MAC != "")
            {
                strSql.Append(",?");
            }
            if (model.URL != "")
            {
                strSql.Append(",?");
            }
            strSql.Append(" ) ");
            OdbcParameter[] parameters = new OdbcParameter[(Param_Num + 1)];
            parameters[0] = new OdbcParameter("@ID", OdbcType.Int);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            if (model.IP != "")
            {
                parameters[index_num] = new OdbcParameter("@IP", OdbcType.VarChar, 20);//IP地址
                parameters[index_num].Value = model.IP;
                index_num++;
            }
            if (model.DATTIM != "")
            {
                parameters[index_num] = new OdbcParameter("@DATTIM", OdbcType.DateTime);//访问时间
                parameters[index_num].Value = model.DATTIM;
                index_num++;
            }
            if (model.MAC != "")
            {
                parameters[index_num] = new OdbcParameter("@MAC", OdbcType.VarChar, 20);//MAC地址
                parameters[index_num].Value = model.MAC;
                index_num++;
            }
            if (model.URL != "")
            {
                parameters[index_num] = new OdbcParameter("@URL", OdbcType.VarChar, 256);//具体访问页面
                parameters[index_num].Value = model.URL;
                index_num++;
            }
            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters); return model.ID;
        } /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(Djdw.Model.Post.SYSVISIT_LOG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYSVISIT_LOG");
            strSql.Append(" where  IP=? and date_format(DATTIM,'%Y-%m-%d') =? and MAC=? and URL=?");
            OdbcParameter[] parameters = {  

					new OdbcParameter("@DATTIM", OdbcType.DateTime),

};
            parameters[0].Value = model.IP;
            parameters[1].Value = model.DATTIM;
            parameters[2].Value = model.MAC;
            parameters[3].Value = model.URL;

            return DbHelperMysqlOdbc.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Djdw.Model.Post.SYSVISIT_LOG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYSVISIT_LOG set ");
            strSql.Append("IP= ?,");
            strSql.Append("DATTIM= ?,");
            strSql.Append("MAC= ?,");
            strSql.Append("URL= ?");
            strSql.Append(" where ID= ?");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@IP", OdbcType.VarChar,20),
					new OdbcParameter("@DATTIM", OdbcType.DateTime),
					new OdbcParameter("@MAC", OdbcType.VarChar,20),
					new OdbcParameter("@URL", OdbcType.VarChar,256)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.IP;
            parameters[2].Value = model.DATTIM;
            parameters[3].Value = model.MAC;
            parameters[4].Value = model.URL;

            return DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYSVISIT_LOG ");
            strSql.Append(" where ID=?");
            OdbcParameter[] parameters = {
				new OdbcParameter("@ID", OdbcType.Int)
			};
            parameters[0].Value = ID;
            return DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 事务处理删除 (int ID)
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DictionaryEntry DeleteSql(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SYSVISIT_LOG ");
            strSql.Append(" where ID=?");
            OdbcParameter[] parameters = {
				new OdbcParameter("@ID", OdbcType.Int)
			};
            parameters[0].Value = ID;
            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        /// <summary>
        /// 事务处理Hashtable
        /// </summary>
        /// <param name="tb">Hashtable</param>
        /// <returns>int</returns>
        public int ExecuteTrans(Hashtable tb)
        {
            return DbHelperMysqlOdbc.ExecuteSqlTran(tb);
        }

        /// <summary>
        /// 事务处理
        /// </summary>
        /// <param name="SQLStringList">ArrayList</param>
        /// <returns>int</returns>
        public int ExecuteSqlTranByArray(ArrayList SQLStringList)
        {
            return DbHelperMysqlOdbc.ExecuteSqlTranByArray(SQLStringList);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Djdw.Model.Post.SYSVISIT_LOG GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYSVISIT_LOG ");
            strSql.Append(" where ID=?");
            OdbcParameter[] parameters = {
   				new OdbcParameter("@ID", OdbcType.Int)};
            parameters[0].Value = ID;
            Djdw.Model.Post.SYSVISIT_LOG model = new Djdw.Model.Post.SYSVISIT_LOG();
            DataSet ds = DbHelperMysqlOdbc.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.IP = ds.Tables[0].Rows[0]["IP"].ToString();
                model.DATTIM = ds.Tables[0].Rows[0]["DATTIM"].ToString();
                model.MAC = ds.Tables[0].Rows[0]["MAC"].ToString();
                model.URL = ds.Tables[0].Rows[0]["URL"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYSVISIT_LOG ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID desc");
            return DbHelperMysqlOdbc.Query(strSql.ToString());
        }
        #endregion  成员方法

        #region ISYSVISIT_LOG 成员


        public DictionaryEntry Updatesql(Djdw.Model.Post.SYSVISIT_LOG model)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UpdateNotall(Djdw.Model.Post.SYSVISIT_LOG model)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}


