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
    /// 数据访问类ISAG_NOTIFMESSAGE
    /// </summary>
    public class ISAG_NOTIFMESSAGE : IISAG_NOTIFMESSAGE
    {
        public ISAG_NOTIFMESSAGE()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMysqlOdbc.GetMaxID("ID", "ISAG_NOTIFMESSAGE");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ISAG_NOTIFMESSAGE");
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
            strSql.Append("select count(1) from ISAG_NOTIFMESSAGE");
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
        public int Add(xxty.Model.Post.ISAG_NOTIFMESSAGE model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ISAG_NOTIFMESSAGE(");
            strSql.Append("ID,NOTIFMESSAGE,SENDERADDRESS,LINKID,PRODUCTID,SPID,SPPASSWORD,STATUS,RECIEVETIME,HANDLETIME)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? , ? , ? , ? , ? , ? , ? )");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@NOTIFMESSAGE", OdbcType.VarChar,20),
					new OdbcParameter("@SENDERADDRESS", OdbcType.VarChar,20),
					new OdbcParameter("@LINKID", OdbcType.VarChar,50),
					new OdbcParameter("@PRODUCTID", OdbcType.VarChar,50),
					new OdbcParameter("@SPID", OdbcType.VarChar,50),
					new OdbcParameter("@SPPASSWORD", OdbcType.VarChar,50),
					new OdbcParameter("@STATUS", OdbcType.Int),
					new OdbcParameter("@RECIEVETIME", OdbcType.VarChar,50),
					new OdbcParameter("@HANDLETIME", OdbcType.VarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.NOTIFMESSAGE;
            parameters[2].Value = model.SENDERADDRESS;
            parameters[3].Value = model.LINKID;
            parameters[4].Value = model.PRODUCTID;
            parameters[5].Value = model.SPID;
            parameters[6].Value = model.SPPASSWORD;
            parameters[7].Value = model.STATUS;
            parameters[8].Value = model.RECIEVETIME;
            parameters[9].Value = model.HANDLETIME;

            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }

        /// <summary>
        /// 事务处理增加一个model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public DictionaryEntry AddSql(xxty.Model.Post.ISAG_NOTIFMESSAGE model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ISAG_NOTIFMESSAGE(");
            strSql.Append("NOTIFMESSAGE,SENDERADDRESS,LINKID,PRODUCTID,SPID,SPPASSWORD,STATUS,RECIEVETIME,HANDLETIME)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? , ? , ? , ? , ? , ? )");
            OdbcParameter[] parameters = {  






					new OdbcParameter("@STATUS", OdbcType.Int),					new OdbcParameter("@STATUS", OdbcType.VarChar,2),
};
            parameters[0].Value = model.NOTIFMESSAGE;
            parameters[1].Value = model.SENDERADDRESS;
            parameters[2].Value = model.LINKID;
            parameters[3].Value = model.PRODUCTID;
            parameters[4].Value = model.SPID;
            parameters[5].Value = model.SPPASSWORD;
            parameters[6].Value = model.STATUS;
            parameters[7].Value = model.RECIEVETIME;
            parameters[8].Value = model.HANDLETIME;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(xxty.Model.Post.ISAG_NOTIFMESSAGE model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ISAG_NOTIFMESSAGE(");
            strSql.Append("ID");
            //列出需哟插入的表字段
            int Param_Num = 0;
            if (model.NOTIFMESSAGE != "")
            {
                Param_Num++;
                strSql.Append(",NOTIFMESSAGE");
            }
            if (model.SENDERADDRESS != "")
            {
                Param_Num++;
                strSql.Append(",SENDERADDRESS");
            }
            if (model.LINKID != "")
            {
                Param_Num++;
                strSql.Append(",LINKID");
            }
            if (model.PRODUCTID != "")
            {
                Param_Num++;
                strSql.Append(",PRODUCTID");
            }
            if (model.SPID != "")
            {
                Param_Num++;
                strSql.Append(",SPID");
            }
            if (model.SPPASSWORD != "")
            {
                Param_Num++;
                strSql.Append(",SPPASSWORD");
            }
            //if (model.STATUS != 0 )
            {
                Param_Num++;
                strSql.Append(",STATUS");
            }
            if (model.RECIEVETIME != "")
            {
                Param_Num++;
                strSql.Append(",RECIEVETIME");
            }
            if (model.HANDLETIME != "")
            {
                Param_Num++;
                strSql.Append(",HANDLETIME");
            }
            strSql.Append(" ) ");
            strSql.Append(" values (");
            strSql.Append("?");
            //列出需哟插入的表字段value对象 
            if (model.NOTIFMESSAGE != "")
            {
                strSql.Append(",?");
            }
            if (model.SENDERADDRESS != "")
            {
                strSql.Append(",?");
            }
            if (model.LINKID != "")
            {
                strSql.Append(",?");
            }
            if (model.PRODUCTID != "")
            {
                strSql.Append(",?");
            }
            if (model.SPID != "")
            {
                strSql.Append(",?");
            }
            if (model.SPPASSWORD != "")
            {
                strSql.Append(",?");
            }
            strSql.Append(",?");
            if (model.RECIEVETIME != "")
            {
                strSql.Append(",?");
            }
            if (model.HANDLETIME != "")
            {
                strSql.Append(",?");
            }
            strSql.Append(" ) ");
            OdbcParameter[] parameters = new OdbcParameter[(Param_Num + 1)];
            parameters[0] = new OdbcParameter("@ID", OdbcType.Int);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            if (model.NOTIFMESSAGE != "")
            {
                parameters[index_num] = new OdbcParameter("@NOTIFMESSAGE", OdbcType.VarChar, 20);//上行消息
                parameters[index_num].Value = model.NOTIFMESSAGE;
                index_num++;
            }
            if (model.SENDERADDRESS != "")
            {
                parameters[index_num] = new OdbcParameter("@SENDERADDRESS", OdbcType.VarChar, 20);//发送者地址
                parameters[index_num].Value = model.SENDERADDRESS;
                index_num++;
            }
            if (model.LINKID != "")
            {
                parameters[index_num] = new OdbcParameter("@LINKID", OdbcType.VarChar, 50);//关联ID
                parameters[index_num].Value = model.LINKID;
                index_num++;
            }
            if (model.PRODUCTID != "")
            {
                parameters[index_num] = new OdbcParameter("@PRODUCTID", OdbcType.VarChar, 50);//产品ID
                parameters[index_num].Value = model.PRODUCTID;
                index_num++;
            }
            if (model.SPID != "")
            {
                parameters[index_num] = new OdbcParameter("@SPID", OdbcType.VarChar, 50);//SP服务ID
                parameters[index_num].Value = model.SPID;
                index_num++;
            }
            if (model.SPPASSWORD != "")
            {
                parameters[index_num] = new OdbcParameter("@SPPASSWORD", OdbcType.VarChar, 50);//SP密码
                parameters[index_num].Value = model.SPPASSWORD;
                index_num++;
            }
            {
                parameters[index_num] = new OdbcParameter("@STATUS", OdbcType.Int);//状态
                parameters[index_num].Value = model.STATUS;
                index_num++;
            }
            if (model.RECIEVETIME != "")
            {
                parameters[index_num] = new OdbcParameter("@RECIEVETIME", OdbcType.VarChar, 50);//接收时间
                parameters[index_num].Value = model.RECIEVETIME;
                index_num++;
            }
            if (model.HANDLETIME != "")
            {
                parameters[index_num] = new OdbcParameter("@HANDLETIME", OdbcType.VarChar, 50);//处理时间
                parameters[index_num].Value = model.HANDLETIME;
                index_num++;
            }
            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters); return model.ID;
        } /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(xxty.Model.Post.ISAG_NOTIFMESSAGE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ISAG_NOTIFMESSAGE");
            strSql.Append(" where  NOTIFMESSAGE=? and SENDERADDRESS=? and LINKID=? and PRODUCTID=? and SPID=? and SPPASSWORD=? and STATUS=? and RECIEVETIME=? and HANDLETIME=?");
            OdbcParameter[] parameters = {  






					new OdbcParameter("@STATUS", OdbcType.Int),					new OdbcParameter("@STATUS", OdbcType.VarChar,2),
};
            parameters[0].Value = model.NOTIFMESSAGE;
            parameters[1].Value = model.SENDERADDRESS;
            parameters[2].Value = model.LINKID;
            parameters[3].Value = model.PRODUCTID;
            parameters[4].Value = model.SPID;
            parameters[5].Value = model.SPPASSWORD;
            parameters[6].Value = model.STATUS;
            parameters[7].Value = model.RECIEVETIME;
            parameters[8].Value = model.HANDLETIME;

            return DbHelperMysqlOdbc.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(xxty.Model.Post.ISAG_NOTIFMESSAGE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ISAG_NOTIFMESSAGE set ");
            strSql.Append("NOTIFMESSAGE= ?,");
            strSql.Append("SENDERADDRESS= ?,");
            strSql.Append("LINKID= ?,");
            strSql.Append("PRODUCTID= ?,");
            strSql.Append("SPID= ?,");
            strSql.Append("SPPASSWORD= ?,");
            strSql.Append("STATUS= ?,");
            strSql.Append("RECIEVETIME= ?,");
            strSql.Append("HANDLETIME= ?");
            strSql.Append(" where ID= ?");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@NOTIFMESSAGE", OdbcType.VarChar,20),
					new OdbcParameter("@SENDERADDRESS", OdbcType.VarChar,20),
					new OdbcParameter("@LINKID", OdbcType.VarChar,50),
					new OdbcParameter("@PRODUCTID", OdbcType.VarChar,50),
					new OdbcParameter("@SPID", OdbcType.VarChar,50),
					new OdbcParameter("@SPPASSWORD", OdbcType.VarChar,50),
					new OdbcParameter("@STATUS", OdbcType.Int),
					new OdbcParameter("@RECIEVETIME", OdbcType.VarChar,50),
					new OdbcParameter("@HANDLETIME", OdbcType.VarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.NOTIFMESSAGE;
            parameters[2].Value = model.SENDERADDRESS;
            parameters[3].Value = model.LINKID;
            parameters[4].Value = model.PRODUCTID;
            parameters[5].Value = model.SPID;
            parameters[6].Value = model.SPPASSWORD;
            parameters[7].Value = model.STATUS;
            parameters[8].Value = model.RECIEVETIME;
            parameters[9].Value = model.HANDLETIME;

            return DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ISAG_NOTIFMESSAGE ");
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
            strSql.Append("delete ISAG_NOTIFMESSAGE ");
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
        public xxty.Model.Post.ISAG_NOTIFMESSAGE GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ISAG_NOTIFMESSAGE ");
            strSql.Append(" where ID=?");
            OdbcParameter[] parameters = {
   				new OdbcParameter("@ID", OdbcType.Int)};
            parameters[0].Value = ID;
            xxty.Model.Post.ISAG_NOTIFMESSAGE model = new xxty.Model.Post.ISAG_NOTIFMESSAGE();
            DataSet ds = DbHelperMysqlOdbc.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.NOTIFMESSAGE = ds.Tables[0].Rows[0]["NOTIFMESSAGE"].ToString();
                model.SENDERADDRESS = ds.Tables[0].Rows[0]["SENDERADDRESS"].ToString();
                model.LINKID = ds.Tables[0].Rows[0]["LINKID"].ToString();
                model.PRODUCTID = ds.Tables[0].Rows[0]["PRODUCTID"].ToString();
                model.SPID = ds.Tables[0].Rows[0]["SPID"].ToString();
                model.SPPASSWORD = ds.Tables[0].Rows[0]["SPPASSWORD"].ToString();
                if (ds.Tables[0].Rows[0]["STATUS"].ToString() != "")
                {
                    model.STATUS = int.Parse(ds.Tables[0].Rows[0]["STATUS"].ToString().Trim());
                }
                model.RECIEVETIME = ds.Tables[0].Rows[0]["RECIEVETIME"].ToString();
                model.HANDLETIME = ds.Tables[0].Rows[0]["HANDLETIME"].ToString();
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
            strSql.Append("select * from ISAG_NOTIFMESSAGE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return DbHelperMysqlOdbc.Query(strSql.ToString());
        }
        #endregion  成员方法

        #region IISAG_NOTIFMESSAGE 成员


        public DictionaryEntry Updatesql(xxty.Model.Post.ISAG_NOTIFMESSAGE model)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UpdateNotall(xxty.Model.Post.ISAG_NOTIFMESSAGE model)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IISAG_NOTIFMESSAGE 成员


        public DictionaryEntry UpdateStatusHdTmsqlByID(xxty.Model.Post.ISAG_NOTIFMESSAGE model)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}


