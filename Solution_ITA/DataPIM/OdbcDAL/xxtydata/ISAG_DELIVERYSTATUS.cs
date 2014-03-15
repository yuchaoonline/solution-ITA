using System;
using System.Data;
using System.Text;
using System.Data.Odbc;
using  xxty.IDAL.Post;
using DBUtility;
 using System.Collections;

namespace xxty.OdbcDAL.Post
{

    /// <summary>
    /// 数据访问类ISAG_DELIVERYSTATUS
    /// </summary>
    public class ISAG_DELIVERYSTATUS : IISAG_DELIVERYSTATUS
    {
        public ISAG_DELIVERYSTATUS()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMysqlOdbc.GetMaxID("ID", "ISAG_DELIVERYSTATUS");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ISAG_DELIVERYSTATUS");
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
            strSql.Append("select count(1) from ISAG_DELIVERYSTATUS");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID");
            return DbHelperMysqlOdbc.Exists(strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(xxty.Model.Post.ISAG_DELIVERYSTATUS model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ISAG_DELIVERYSTATUS(");
            strSql.Append("ID,CORRELATOR,ADDRESS,DELIVERYSTATUS)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? )");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@CORRELATOR", OdbcType.VarChar,20),
					new OdbcParameter("@ADDRESS", OdbcType.VarChar,20),
					new OdbcParameter("@DELIVERYSTATUS", OdbcType.VarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.CORRELATOR;
            parameters[2].Value = model.ADDRESS;
            parameters[3].Value = model.DELIVERYSTATUS;

            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }

        /// <summary>
        /// 事务处理增加一个model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public DictionaryEntry AddSql(xxty.Model.Post.ISAG_DELIVERYSTATUS model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ISAG_DELIVERYSTATUS(");
            strSql.Append("CORRELATOR,ADDRESS,DELIVERYSTATUS)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? )");
            OdbcParameter[] parameters = {  


};
            parameters[0].Value = model.CORRELATOR;
            parameters[1].Value = model.ADDRESS;
            parameters[2].Value = model.DELIVERYSTATUS;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(xxty.Model.Post.ISAG_DELIVERYSTATUS model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ISAG_DELIVERYSTATUS(");
            strSql.Append("ID");
            //列出需哟插入的表字段
            int Param_Num = 0;
            if (model.CORRELATOR != "")
            {
                Param_Num++;
                strSql.Append(",CORRELATOR");
            }
            if (model.ADDRESS != "")
            {
                Param_Num++;
                strSql.Append(",ADDRESS");
            }
            if (model.DELIVERYSTATUS != "")
            {
                Param_Num++;
                strSql.Append(",DELIVERYSTATUS");
            }
            strSql.Append(" ) ");
            strSql.Append(" values (");
            strSql.Append("?");
            //列出需哟插入的表字段value对象 
            if (model.CORRELATOR != "")
            {
                strSql.Append(",?");
            }
            if (model.ADDRESS != "")
            {
                strSql.Append(",?");
            }
            if (model.DELIVERYSTATUS != "")
            {
                strSql.Append(",?");
            }
            strSql.Append(" ) ");
            OdbcParameter[] parameters = new OdbcParameter[(Param_Num + 1)];
            parameters[0] = new OdbcParameter("@ID", OdbcType.Int);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            if (model.CORRELATOR != "")
            {
                parameters[index_num] = new OdbcParameter("@CORRELATOR", OdbcType.VarChar, 20);//关联发送编号
                parameters[index_num].Value = model.CORRELATOR;
                index_num++;
            }
            if (model.ADDRESS != "")
            {
                parameters[index_num] = new OdbcParameter("@ADDRESS", OdbcType.VarChar, 20);//地址
                parameters[index_num].Value = model.ADDRESS;
                index_num++;
            }
            if (model.DELIVERYSTATUS != "")
            {
                parameters[index_num] = new OdbcParameter("@DELIVERYSTATUS", OdbcType.VarChar, 50);//回执状态
                parameters[index_num].Value = model.DELIVERYSTATUS;
                index_num++;
            }
            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters); return model.ID;
        } /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(xxty.Model.Post.ISAG_DELIVERYSTATUS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ISAG_DELIVERYSTATUS");
            strSql.Append(" where  CORRELATOR=? and ADDRESS=? and DELIVERYSTATUS=?");
            OdbcParameter[] parameters = {  


};
            parameters[0].Value = model.CORRELATOR;
            parameters[1].Value = model.ADDRESS;
            parameters[2].Value = model.DELIVERYSTATUS;

            return DbHelperMysqlOdbc.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(xxty.Model.Post.ISAG_DELIVERYSTATUS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ISAG_DELIVERYSTATUS set ");
            strSql.Append("CORRELATOR= ?,");
            strSql.Append("ADDRESS= ?,");
            strSql.Append("DELIVERYSTATUS= ?");
            strSql.Append(" where ID= ?");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@CORRELATOR", OdbcType.VarChar,20),
					new OdbcParameter("@ADDRESS", OdbcType.VarChar,20),
					new OdbcParameter("@DELIVERYSTATUS", OdbcType.VarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.CORRELATOR;
            parameters[2].Value = model.ADDRESS;
            parameters[3].Value = model.DELIVERYSTATUS;

            return DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ISAG_DELIVERYSTATUS ");
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
            strSql.Append("delete ISAG_DELIVERYSTATUS ");
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
        public xxty.Model.Post.ISAG_DELIVERYSTATUS GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ISAG_DELIVERYSTATUS ");
            strSql.Append(" where ID=?");
            OdbcParameter[] parameters = {
   				new OdbcParameter("@ID", OdbcType.Int)};
            parameters[0].Value = ID;
            xxty.Model.Post.ISAG_DELIVERYSTATUS model = new xxty.Model.Post.ISAG_DELIVERYSTATUS();
            DataSet ds = DbHelperMysqlOdbc.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.CORRELATOR = ds.Tables[0].Rows[0]["CORRELATOR"].ToString();
                model.ADDRESS = ds.Tables[0].Rows[0]["ADDRESS"].ToString();
                model.DELIVERYSTATUS = ds.Tables[0].Rows[0]["DELIVERYSTATUS"].ToString();
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
            strSql.Append("select * from ISAG_DELIVERYSTATUS ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return DbHelperMysqlOdbc.Query(strSql.ToString());
        }
        #endregion  成员方法

        #region IISAG_DELIVERYSTATUS 成员


        public DictionaryEntry Updatesql(xxty.Model.Post.ISAG_DELIVERYSTATUS model)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UpdateNotall(xxty.Model.Post.ISAG_DELIVERYSTATUS model)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}


