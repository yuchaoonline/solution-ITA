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
    /// 数据访问类ISMP_ORDERUPDATENOTIFY
    /// </summary>
    public class ISMP_ORDERUPDATENOTIFY : IISMP_ORDERUPDATENOTIFY
    {
        public ISMP_ORDERUPDATENOTIFY()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMysqlOdbc.GetMaxID("ID", "ISMP_ORDERUPDATENOTIFY");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ISMP_ORDERUPDATENOTIFY");
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
            strSql.Append("select count(1) from ISMP_ORDERUPDATENOTIFY");
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
        public int Add(xxty.Model.Post.ISMP_ORDERUPDATENOTIFY model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ISMP_ORDERUPDATENOTIFY(");
            strSql.Append("ID,STREAMINGNO,PRODUCTID,USERID,USERIDTYPE,OPTYPE,HANDLETIME,STATUS)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? , ? , ? , ? , ? )");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@STREAMINGNO", OdbcType.VarChar,50),
					new OdbcParameter("@PRODUCTID", OdbcType.VarChar,50),
					new OdbcParameter("@USERID", OdbcType.VarChar,50),
					new OdbcParameter("@USERIDTYPE", OdbcType.VarChar,50),
					new OdbcParameter("@OPTYPE", OdbcType.VarChar,50),
					new OdbcParameter("@HANDLETIME", OdbcType.VarChar,20),
					new OdbcParameter("@STATUS", OdbcType.Int)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.STREAMINGNO;
            parameters[2].Value = model.PRODUCTID;
            parameters[3].Value = model.USERID;
            parameters[4].Value = model.USERIDTYPE;
            parameters[5].Value = model.OPTYPE;
            parameters[6].Value = model.HANDLETIME;
            parameters[7].Value = model.STATUS;

            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }

        /// <summary>
        /// 事务处理增加一个model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public DictionaryEntry AddSql(xxty.Model.Post.ISMP_ORDERUPDATENOTIFY model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ISMP_ORDERUPDATENOTIFY(");
            strSql.Append("STREAMINGNO,PRODUCTID,USERID,USERIDTYPE,OPTYPE,HANDLETIME,STATUS)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? , ? , ? , ? )");
            OdbcParameter[] parameters = {  






					new OdbcParameter("@STATUS", OdbcType.Int),					new OdbcParameter("@STATUS", OdbcType.VarChar,3)};
            parameters[0].Value = model.STREAMINGNO;
            parameters[1].Value = model.PRODUCTID;
            parameters[2].Value = model.USERID;
            parameters[3].Value = model.USERIDTYPE;
            parameters[4].Value = model.OPTYPE;
            parameters[5].Value = model.HANDLETIME;
            parameters[6].Value = model.STATUS;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(xxty.Model.Post.ISMP_ORDERUPDATENOTIFY model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ISMP_ORDERUPDATENOTIFY(");
            strSql.Append("ID");
            //列出需哟插入的表字段
            int Param_Num = 0;
            if (model.STREAMINGNO != "")
            {
                Param_Num++;
                strSql.Append(",STREAMINGNO");
            }
            if (model.PRODUCTID != "")
            {
                Param_Num++;
                strSql.Append(",PRODUCTID");
            }
            if (model.USERID != "")
            {
                Param_Num++;
                strSql.Append(",USERID");
            }
            if (model.USERIDTYPE != "")
            {
                Param_Num++;
                strSql.Append(",USERIDTYPE");
            }
            if (model.OPTYPE != "")
            {
                Param_Num++;
                strSql.Append(",OPTYPE");
            }
            if (model.HANDLETIME != "")
            {
                Param_Num++;
                strSql.Append(",HANDLETIME");
            }
            //if (model.STATUS != 0 )
            {
                Param_Num++;
                strSql.Append(",STATUS");
            }
            strSql.Append(" ) ");
            strSql.Append(" values (");
            strSql.Append("?");
            //列出需哟插入的表字段value对象 
            if (model.STREAMINGNO != "")
            {
                strSql.Append(",?");
            }
            if (model.PRODUCTID != "")
            {
                strSql.Append(",?");
            }
            if (model.USERID != "")
            {
                strSql.Append(",?");
            }
            if (model.USERIDTYPE != "")
            {
                strSql.Append(",?");
            }
            if (model.OPTYPE != "")
            {
                strSql.Append(",?");
            }
            if (model.HANDLETIME != "")
            {
                strSql.Append(",?");
            }
            strSql.Append(",?");
            strSql.Append(" ) ");
            OdbcParameter[] parameters = new OdbcParameter[(Param_Num + 1)];
            parameters[0] = new OdbcParameter("@ID", OdbcType.Int);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            if (model.STREAMINGNO != "")
            {
                parameters[index_num] = new OdbcParameter("@STREAMINGNO", OdbcType.VarChar, 50);//流水号
                parameters[index_num].Value = model.STREAMINGNO;
                index_num++;
            }
            if (model.PRODUCTID != "")
            {
                parameters[index_num] = new OdbcParameter("@PRODUCTID", OdbcType.VarChar, 50);//产品编号
                parameters[index_num].Value = model.PRODUCTID;
                index_num++;
            }
            if (model.USERID != "")
            {
                parameters[index_num] = new OdbcParameter("@USERID", OdbcType.VarChar, 50);//用户编号
                parameters[index_num].Value = model.USERID;
                index_num++;
            }
            if (model.USERIDTYPE != "")
            {
                parameters[index_num] = new OdbcParameter("@USERIDTYPE", OdbcType.VarChar, 50);//用户类型
                parameters[index_num].Value = model.USERIDTYPE;
                index_num++;
            }
            if (model.OPTYPE != "")
            {
                parameters[index_num] = new OdbcParameter("@OPTYPE", OdbcType.VarChar, 50);//操作类型
                parameters[index_num].Value = model.OPTYPE;
                index_num++;
            }
            if (model.HANDLETIME != "")
            {
                parameters[index_num] = new OdbcParameter("@HANDLETIME", OdbcType.VarChar, 20);//处理时间
                parameters[index_num].Value = model.HANDLETIME;
                index_num++;
            }
            {
                parameters[index_num] = new OdbcParameter("@STATUS", OdbcType.Int);//状态
                parameters[index_num].Value = model.STATUS;
                index_num++;
            }
            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters); return model.ID;
        } /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(xxty.Model.Post.ISMP_ORDERUPDATENOTIFY model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ISMP_ORDERUPDATENOTIFY");
            strSql.Append(" where  STREAMINGNO=? and PRODUCTID=? and USERID=? and USERIDTYPE=? and OPTYPE=? and HANDLETIME=? and STATUS=?");
            OdbcParameter[] parameters = {  






					new OdbcParameter("@STATUS", OdbcType.Int),					new OdbcParameter("@STATUS", OdbcType.VarChar,3)};
            parameters[0].Value = model.STREAMINGNO;
            parameters[1].Value = model.PRODUCTID;
            parameters[2].Value = model.USERID;
            parameters[3].Value = model.USERIDTYPE;
            parameters[4].Value = model.OPTYPE;
            parameters[5].Value = model.HANDLETIME;
            parameters[6].Value = model.STATUS;

            return DbHelperMysqlOdbc.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(xxty.Model.Post.ISMP_ORDERUPDATENOTIFY model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ISMP_ORDERUPDATENOTIFY set ");
            strSql.Append("STREAMINGNO= ?,");
            strSql.Append("PRODUCTID= ?,");
            strSql.Append("USERID= ?,");
            strSql.Append("USERIDTYPE= ?,");
            strSql.Append("OPTYPE= ?,");
            strSql.Append("HANDLETIME= ?,");
            strSql.Append("STATUS= ?");
            strSql.Append(" where ID= ?");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@STREAMINGNO", OdbcType.VarChar,50),
					new OdbcParameter("@PRODUCTID", OdbcType.VarChar,50),
					new OdbcParameter("@USERID", OdbcType.VarChar,50),
					new OdbcParameter("@USERIDTYPE", OdbcType.VarChar,50),
					new OdbcParameter("@OPTYPE", OdbcType.VarChar,50),
					new OdbcParameter("@HANDLETIME", OdbcType.VarChar,20),
					new OdbcParameter("@STATUS", OdbcType.Int)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.STREAMINGNO;
            parameters[2].Value = model.PRODUCTID;
            parameters[3].Value = model.USERID;
            parameters[4].Value = model.USERIDTYPE;
            parameters[5].Value = model.OPTYPE;
            parameters[6].Value = model.HANDLETIME;
            parameters[7].Value = model.STATUS;

            return DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ISMP_ORDERUPDATENOTIFY ");
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
            strSql.Append("delete ISMP_ORDERUPDATENOTIFY ");
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
        public xxty.Model.Post.ISMP_ORDERUPDATENOTIFY GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ISMP_ORDERUPDATENOTIFY ");
            strSql.Append(" where ID=?");
            OdbcParameter[] parameters = {
   				new OdbcParameter("@ID", OdbcType.Int)};
            parameters[0].Value = ID;
            xxty.Model.Post.ISMP_ORDERUPDATENOTIFY model = new xxty.Model.Post.ISMP_ORDERUPDATENOTIFY();
            DataSet ds = DbHelperMysqlOdbc.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.STREAMINGNO = ds.Tables[0].Rows[0]["STREAMINGNO"].ToString();
                model.PRODUCTID = ds.Tables[0].Rows[0]["PRODUCTID"].ToString();
                model.USERID = ds.Tables[0].Rows[0]["USERID"].ToString();
                model.USERIDTYPE = ds.Tables[0].Rows[0]["USERIDTYPE"].ToString();
                model.OPTYPE = ds.Tables[0].Rows[0]["OPTYPE"].ToString();
                model.HANDLETIME = ds.Tables[0].Rows[0]["HANDLETIME"].ToString();
                if (ds.Tables[0].Rows[0]["STATUS"].ToString() != "")
                {
                    model.STATUS = int.Parse(ds.Tables[0].Rows[0]["STATUS"].ToString().Trim());
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
            strSql.Append("select * from ISMP_ORDERUPDATENOTIFY ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return DbHelperMysqlOdbc.Query(strSql.ToString());
        }
        #endregion  成员方法

        #region IISMP_ORDERUPDATENOTIFY 成员


        public DictionaryEntry Updatesql(xxty.Model.Post.ISMP_ORDERUPDATENOTIFY model)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UpdateNotall(xxty.Model.Post.ISMP_ORDERUPDATENOTIFY model)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IISMP_ORDERUPDATENOTIFY 成员


        public DictionaryEntry UpdateStatusHdTmsqlByID(xxty.Model.Post.ISMP_ORDERUPDATENOTIFY model)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}


