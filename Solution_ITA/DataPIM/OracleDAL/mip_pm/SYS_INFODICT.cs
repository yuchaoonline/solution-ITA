using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using DBUtility;
using System.Collections;
using Mis.IDAL.Post;//请先添加引用;

namespace Mis.OracleDAL.Post
{
	/// <summary>
	/// 数据访问类SYS_INFODICT。
	/// </summary>
	public class SYS_INFODICT : ISYS_INFODICT
	{
		public SYS_INFODICT()
		{}
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOra.GetMaxID("ID", "SYS_INFODICT");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_INFODICT");
            strSql.Append(" where ID= :ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number)
				};
            parameters[0].Value = ID;
            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_INFODICT");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID");
            return DbHelperOra.Exists(strSql.ToString());
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Djdw.Model.Post.SYS_INFODICT model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_INFODICT(");
            strSql.Append("ID,INFONO,INFONAME,PARENTID,DESCRIPTION,ACTIONPEOPLE,INFOLEVEL)");
            strSql.Append(" values (");
            strSql.Append(":ID,:INFONO,:INFONAME,:PARENTID,:DESCRIPTION,:ACTIONPEOPLE,:INFOLEVEL)");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4),
					new OracleParameter(":INFONO", OracleType.VarChar,10),
					new OracleParameter(":INFONAME", OracleType.VarChar,50),
					new OracleParameter(":PARENTID", OracleType.Number,4),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,256),
					new OracleParameter(":ACTIONPEOPLE", OracleType.VarChar,30),
					new OracleParameter(":INFOLEVEL", OracleType.Number,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.INFONO;
            parameters[2].Value = model.INFONAME;
            parameters[3].Value = model.PARENTID;
            parameters[4].Value = model.DESCRIPTION;
            parameters[5].Value = model.ACTIONPEOPLE;
            parameters[6].Value = model.INFOLEVEL;

            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Djdw.Model.Post.SYS_INFODICT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_INFODICT set ");
            strSql.Append("INFONO=:INFONO,");
            strSql.Append("INFONAME=:INFONAME,");
            strSql.Append("PARENTID=:PARENTID,");
            strSql.Append("DESCRIPTION=:DESCRIPTION,");
            strSql.Append("ACTIONPEOPLE=:ACTIONPEOPLE,");
            strSql.Append("INFOLEVEL=:INFOLEVEL");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4),
					new OracleParameter(":INFONO", OracleType.VarChar,10),
					new OracleParameter(":INFONAME", OracleType.VarChar,50),
					new OracleParameter(":PARENTID", OracleType.Number,4),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,256),
					new OracleParameter(":ACTIONPEOPLE", OracleType.VarChar,30),
					new OracleParameter(":INFOLEVEL", OracleType.Number,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.INFONO;
            parameters[2].Value = model.INFONAME;
            parameters[3].Value = model.PARENTID;
            parameters[4].Value = model.DESCRIPTION;
            parameters[5].Value = model.ACTIONPEOPLE;
            parameters[6].Value = model.INFOLEVEL;

            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SYS_INFODICT ");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number)
				};
            parameters[0].Value = ID;
            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 事务处理增加一个model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public DictionaryEntry AddSql(Djdw.Model.Post.SYS_INFODICT model)
        {

            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_INFODICT(");
            strSql.Append("ID,INFONO,INFONAME,PARENTID,DESCRIPTION,ACTIONPEOPLE,INFOLEVEL)");
            strSql.Append(" values (");
            strSql.Append(":ID,:INFONO,:INFONAME,:PARENTID,:DESCRIPTION,:ACTIONPEOPLE,:INFOLEVEL)");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4),
					new OracleParameter(":INFONO", OracleType.VarChar,10),
					new OracleParameter(":INFONAME", OracleType.VarChar,50),
					new OracleParameter(":PARENTID", OracleType.Number,4),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,256),
					new OracleParameter(":ACTIONPEOPLE", OracleType.VarChar,30),
					new OracleParameter(":INFOLEVEL", OracleType.Number,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.INFONO;
            parameters[2].Value = model.INFONAME;
            parameters[3].Value = model.PARENTID;
            parameters[4].Value = model.DESCRIPTION;
            parameters[5].Value = model.ACTIONPEOPLE;
            parameters[6].Value = model.INFOLEVEL;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(Djdw.Model.Post.SYS_INFODICT model)
        {
            return -1;
        } /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(Djdw.Model.Post.SYS_INFODICT model)
        {

            return false;
        }

        public int UpdateNotall(Djdw.Model.Post.SYS_INFODICT model)
        {
            
            return -1;
        }


        /// <summary>
        /// 事务处理删除 (int ID)
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DictionaryEntry DeleteSql(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete  from SYS_INFODICT ");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number)
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
            return DbHelperOra.ExecuteSqlTran(tb);
        }

        /// <summary>
        /// 事务处理
        /// </summary>
        /// <param name="SQLStringList">ArrayList</param>
        /// <returns>int</returns>
        public int ExecuteSqlTranByArray(ArrayList SQLStringList)
        {
            return DbHelperOra.ExecuteSqlTranByArray(SQLStringList);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Djdw.Model.Post.SYS_INFODICT GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_INFODICT ");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number)};
            parameters[0].Value = ID;
            Djdw.Model.Post.SYS_INFODICT model = new Djdw.Model.Post.SYS_INFODICT();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.INFONO = ds.Tables[0].Rows[0]["INFONO"].ToString();
                model.INFONAME = ds.Tables[0].Rows[0]["INFONAME"].ToString();
                if (ds.Tables[0].Rows[0]["PARENTID"].ToString() != "")
                {
                    model.PARENTID = int.Parse(ds.Tables[0].Rows[0]["PARENTID"].ToString());
                }
                model.DESCRIPTION = ds.Tables[0].Rows[0]["DESCRIPTION"].ToString();
                model.ACTIONPEOPLE = ds.Tables[0].Rows[0]["ACTIONPEOPLE"].ToString();
                if (ds.Tables[0].Rows[0]["INFOLEVEL"].ToString() != "")
                {
                    model.INFOLEVEL = int.Parse(ds.Tables[0].Rows[0]["INFOLEVEL"].ToString());
                }
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
            strSql.Append("select ID,INFONO,INFONAME,PARENTID,DESCRIPTION,ACTIONPEOPLE,INFOLEVEL ");
            strSql.Append(" FROM SYS_INFODICT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion  成员方法



  
    }
}

