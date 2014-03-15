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
    /// 数据访问类ISAG_SENDSMS
    /// </summary>
    public class ISAG_SENDSMS : IISAG_SENDSMS
    {
        public ISAG_SENDSMS()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMysqlOdbc.GetMaxID("ID", "ISAG_SENDSMS");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ISAG_SENDSMS");
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
            strSql.Append("select count(1) from ISAG_SENDSMS");
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
        public int Add(xxty.Model.Post.ISAG_SENDSMS model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ISAG_SENDSMS(");
            strSql.Append("ID,SMSID,RESVERADDRESSES,SENDERADDRESS,LINKID,PRODUCTID,SERVICEID,CONTENT,INSERTTIME,STATUS,SENDTIME,RESULT,SENDNUMBER)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? )");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@SMSID", OdbcType.VarChar,50),
					new OdbcParameter("@RESVERADDRESSES", OdbcType.VarChar,256),
					new OdbcParameter("@SENDERADDRESS", OdbcType.VarChar,50),
					new OdbcParameter("@LINKID", OdbcType.VarChar,50),
					new OdbcParameter("@PRODUCTID", OdbcType.VarChar,50),
					new OdbcParameter("@SERVICEID", OdbcType.VarChar,50),
					new OdbcParameter("@CONTENT", OdbcType.VarChar,512),
					new OdbcParameter("@INSERTTIME", OdbcType.VarChar,20),
					new OdbcParameter("@STATUS", OdbcType.Int),
					new OdbcParameter("@SENDTIME", OdbcType.VarChar,20),
					new OdbcParameter("@RESULT", OdbcType.VarChar,50),
					new OdbcParameter("@SENDNUMBER", OdbcType.Int)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SMSID;
            parameters[2].Value = model.RESVERADDRESSES;
            parameters[3].Value = model.SENDERADDRESS;
            parameters[4].Value = model.LINKID;
            parameters[5].Value = model.PRODUCTID;
            parameters[6].Value = model.SERVICEID;
            parameters[7].Value = model.CONTENT;
            parameters[8].Value = model.INSERTTIME;
            parameters[9].Value = model.STATUS;
            parameters[10].Value = model.SENDTIME;
            parameters[11].Value = model.RESULT;
            parameters[12].Value = model.SENDNUMBER;

            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }

        /// <summary>
        /// 事务处理增加一个model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public DictionaryEntry AddSql(xxty.Model.Post.ISAG_SENDSMS model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ISAG_SENDSMS(");
            strSql.Append("ID,SMSID,addresses,senderAddress,LINKID,PRODUCTID,SERVICEID,message,insertDate,mystatus,fstime,RESULT)");
            strSql.Append(" values (");
            strSql.Append(" ? ,? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ?)");
            OdbcParameter[] parameters = {
                    new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@SMSID", OdbcType.VarChar,128),
					new OdbcParameter("@addresses", OdbcType.VarChar,256),
					new OdbcParameter("@senderAddress", OdbcType.VarChar,50),
					new OdbcParameter("@LINKID", OdbcType.VarChar,50),
					new OdbcParameter("@PRODUCTID", OdbcType.VarChar,50),
					new OdbcParameter("@SERVICEID", OdbcType.VarChar,50),
					new OdbcParameter("@message", OdbcType.VarChar,500),
					new OdbcParameter("@insertDate", OdbcType.DateTime),
					new OdbcParameter("@mystatus", OdbcType.Int),
					new OdbcParameter("@fstime", OdbcType.DateTime),
					new OdbcParameter("@RESULT", OdbcType.VarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SMSID;
            parameters[2].Value = model.RESVERADDRESSES;
            parameters[3].Value = model.SENDERADDRESS;
            parameters[4].Value = model.LINKID;
            parameters[5].Value = model.PRODUCTID;
            parameters[6].Value = model.SERVICEID;
            parameters[7].Value = model.CONTENT;
            parameters[8].Value = model.INSERTTIME;
            parameters[9].Value = model.STATUS;
            parameters[10].Value = model.SENDTIME;
            parameters[11].Value = model.RESULT;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }


        /// <summary>
        /// 事务处理增加一个model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public DictionaryEntry AddSqlForMEM(xxty.Model.Post.ISAG_SENDSMS model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ISAG_SENDSMS(");
            strSql.Append("ID,SMSID,addresses,senderAddress,LINKID,PRODUCTID,SERVICEID,message,insertDate,mystatus,fstime,RESULT,BUSTYPE)");
            strSql.Append(" values (");
            strSql.Append(" ? ,? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ?)");
            OdbcParameter[] parameters = {
                    new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@SMSID", OdbcType.VarChar,128),
					new OdbcParameter("@addresses", OdbcType.VarChar,256),
					new OdbcParameter("@senderAddress", OdbcType.VarChar,50),
					new OdbcParameter("@LINKID", OdbcType.VarChar,50),
					new OdbcParameter("@PRODUCTID", OdbcType.VarChar,50),
					new OdbcParameter("@SERVICEID", OdbcType.VarChar,50),
					new OdbcParameter("@message", OdbcType.VarChar,500),
					new OdbcParameter("@insertDate", OdbcType.DateTime),
					new OdbcParameter("@mystatus", OdbcType.Int),
					new OdbcParameter("@fstime", OdbcType.DateTime),
					new OdbcParameter("@RESULT", OdbcType.VarChar,50),
                    new OdbcParameter("@BUSTYPE", OdbcType.Int)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SMSID;
            parameters[2].Value = model.RESVERADDRESSES;
            parameters[3].Value = model.SENDERADDRESS;
            parameters[4].Value = model.LINKID;
            parameters[5].Value = model.PRODUCTID;
            parameters[6].Value = model.SERVICEID;
            parameters[7].Value = model.CONTENT;
            parameters[8].Value = model.INSERTTIME;
            parameters[9].Value = model.STATUS;
            parameters[10].Value = model.SENDTIME;
            parameters[11].Value = model.RESULT;
            parameters[12].Value = model.TYPE;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(xxty.Model.Post.ISAG_SENDSMS model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ISAG_SENDSMS(");
            strSql.Append("ID");
            //列出需哟插入的表字段
            int Param_Num = 0;
            if (model.SMSID != "")
            {
                Param_Num++;
                strSql.Append(",SMSID");
            }
            if (model.RESVERADDRESSES != "")
            {
                Param_Num++;
                strSql.Append(",RESVERADDRESSES");
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
            if (model.SERVICEID != "")
            {
                Param_Num++;
                strSql.Append(",SERVICEID");
            }
            if (model.CONTENT != "")
            {
                Param_Num++;
                strSql.Append(",CONTENT");
            }
            if (model.INSERTTIME != "")
            {
                Param_Num++;
                strSql.Append(",INSERTTIME");
            }
            //if (model.STATUS != 0 )
            {
                Param_Num++;
                strSql.Append(",STATUS");
            }
            if (model.SENDTIME != "")
            {
                Param_Num++;
                strSql.Append(",SENDTIME");
            }
            if (model.RESULT != "")
            {
                Param_Num++;
                strSql.Append(",RESULT");
            }
            //if (model.SENDNUMBER != 0 )
            {
                Param_Num++;
                strSql.Append(",SENDNUMBER");
            }
            strSql.Append(" ) ");
            strSql.Append(" values (");
            strSql.Append("?");
            //列出需哟插入的表字段value对象 
            if (model.SMSID != "")
            {
                strSql.Append(",?");
            }
            if (model.RESVERADDRESSES != "")
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
            if (model.SERVICEID != "")
            {
                strSql.Append(",?");
            }
            if (model.CONTENT != "")
            {
                strSql.Append(",?");
            }
            if (model.INSERTTIME != "")
            {
                strSql.Append(",?");
            }
            strSql.Append(",?");
            if (model.SENDTIME != "")
            {
                strSql.Append(",?");
            }
            if (model.RESULT != "")
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
            if (model.SMSID != "")
            {
                parameters[index_num] = new OdbcParameter("@SMSID", OdbcType.VarChar, 50);//短信编号
                parameters[index_num].Value = model.SMSID;
                index_num++;
            }
            if (model.RESVERADDRESSES != "")
            {
                parameters[index_num] = new OdbcParameter("@RESVERADDRESSES", OdbcType.VarChar, 256);//接受者地址
                parameters[index_num].Value = model.RESVERADDRESSES;
                index_num++;
            }
            if (model.SENDERADDRESS != "")
            {
                parameters[index_num] = new OdbcParameter("@SENDERADDRESS", OdbcType.VarChar, 50);//发送者地址
                parameters[index_num].Value = model.SENDERADDRESS;
                index_num++;
            }
            if (model.LINKID != "")
            {
                parameters[index_num] = new OdbcParameter("@LINKID", OdbcType.VarChar, 50);//点播关系ID
                parameters[index_num].Value = model.LINKID;
                index_num++;
            }
            if (model.PRODUCTID != "")
            {
                parameters[index_num] = new OdbcParameter("@PRODUCTID", OdbcType.VarChar, 50);//产品ID
                parameters[index_num].Value = model.PRODUCTID;
                index_num++;
            }
            if (model.SERVICEID != "")
            {
                parameters[index_num] = new OdbcParameter("@SERVICEID", OdbcType.VarChar, 50);//服务ID
                parameters[index_num].Value = model.SERVICEID;
                index_num++;
            }
            if (model.CONTENT != "")
            {
                parameters[index_num] = new OdbcParameter("@CONTENT", OdbcType.VarChar, 512);//内容
                parameters[index_num].Value = model.CONTENT;
                index_num++;
            }
            if (model.INSERTTIME != "")
            {
                parameters[index_num] = new OdbcParameter("@INSERTTIME", OdbcType.VarChar, 20);//插入时间
                parameters[index_num].Value = model.INSERTTIME;
                index_num++;
            }
            {
                parameters[index_num] = new OdbcParameter("@STATUS", OdbcType.Int);//状态
                parameters[index_num].Value = model.STATUS;
                index_num++;
            }
            if (model.SENDTIME != "")
            {
                parameters[index_num] = new OdbcParameter("@SENDTIME", OdbcType.VarChar, 20);//发送时间
                parameters[index_num].Value = model.SENDTIME;
                index_num++;
            }
            if (model.RESULT != "")
            {
                parameters[index_num] = new OdbcParameter("@RESULT", OdbcType.VarChar, 50);//结果回执
                parameters[index_num].Value = model.RESULT;
                index_num++;
            }
            {
                parameters[index_num] = new OdbcParameter("@SENDNUMBER", OdbcType.Int);//发送次数
                parameters[index_num].Value = model.SENDNUMBER;
                index_num++;
            }
            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters); return model.ID;
        } /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(xxty.Model.Post.ISAG_SENDSMS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ISAG_SENDSMS");
            strSql.Append(" where  SMSID=? and RESVERADDRESSES=? and SENDERADDRESS=? and LINKID=? and PRODUCTID=? and SERVICEID=? and CONTENT=? and INSERTTIME=? and STATUS=? and SENDTIME=? and RESULT=? and SENDNUMBER=?");
            OdbcParameter[] parameters = {  








					new OdbcParameter("@STATUS", OdbcType.Int),					new OdbcParameter("@STATUS", OdbcType.VarChar,2),


					new OdbcParameter("@SENDNUMBER", OdbcType.Int),					new OdbcParameter("@SENDNUMBER", OdbcType.VarChar,3)};
            parameters[0].Value = model.SMSID;
            parameters[1].Value = model.RESVERADDRESSES;
            parameters[2].Value = model.SENDERADDRESS;
            parameters[3].Value = model.LINKID;
            parameters[4].Value = model.PRODUCTID;
            parameters[5].Value = model.SERVICEID;
            parameters[6].Value = model.CONTENT;
            parameters[7].Value = model.INSERTTIME;
            parameters[8].Value = model.STATUS;
            parameters[9].Value = model.SENDTIME;
            parameters[10].Value = model.RESULT;
            parameters[11].Value = model.SENDNUMBER;

            return DbHelperMysqlOdbc.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(xxty.Model.Post.ISAG_SENDSMS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ISAG_SENDSMS set ");
            strSql.Append("SMSID= ?,");
            strSql.Append("RESVERADDRESSES= ?,");
            strSql.Append("SENDERADDRESS= ?,");
            strSql.Append("LINKID= ?,");
            strSql.Append("PRODUCTID= ?,");
            strSql.Append("SERVICEID= ?,");
            strSql.Append("CONTENT= ?,");
            strSql.Append("INSERTTIME= ?,");
            strSql.Append("STATUS= ?,");
            strSql.Append("SENDTIME= ?,");
            strSql.Append("RESULT= ?,");
            strSql.Append("SENDNUMBER= ?");
            strSql.Append(" where ID= ?");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@SMSID", OdbcType.VarChar,50),
					new OdbcParameter("@RESVERADDRESSES", OdbcType.VarChar,256),
					new OdbcParameter("@SENDERADDRESS", OdbcType.VarChar,50),
					new OdbcParameter("@LINKID", OdbcType.VarChar,50),
					new OdbcParameter("@PRODUCTID", OdbcType.VarChar,50),
					new OdbcParameter("@SERVICEID", OdbcType.VarChar,50),
					new OdbcParameter("@CONTENT", OdbcType.VarChar,512),
					new OdbcParameter("@INSERTTIME", OdbcType.VarChar,20),
					new OdbcParameter("@STATUS", OdbcType.Int),
					new OdbcParameter("@SENDTIME", OdbcType.VarChar,20),
					new OdbcParameter("@RESULT", OdbcType.VarChar,50),
					new OdbcParameter("@SENDNUMBER", OdbcType.Int)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SMSID;
            parameters[2].Value = model.RESVERADDRESSES;
            parameters[3].Value = model.SENDERADDRESS;
            parameters[4].Value = model.LINKID;
            parameters[5].Value = model.PRODUCTID;
            parameters[6].Value = model.SERVICEID;
            parameters[7].Value = model.CONTENT;
            parameters[8].Value = model.INSERTTIME;
            parameters[9].Value = model.STATUS;
            parameters[10].Value = model.SENDTIME;
            parameters[11].Value = model.RESULT;
            parameters[12].Value = model.SENDNUMBER;

            return DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ISAG_SENDSMS ");
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
            strSql.Append("delete ISAG_SENDSMS ");
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
        public xxty.Model.Post.ISAG_SENDSMS GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ISAG_SENDSMS ");
            strSql.Append(" where ID=?");
            OdbcParameter[] parameters = {
   				new OdbcParameter("@ID", OdbcType.Int)};
            parameters[0].Value = ID;
            xxty.Model.Post.ISAG_SENDSMS model = new xxty.Model.Post.ISAG_SENDSMS();
            DataSet ds = DbHelperMysqlOdbc.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.SMSID = ds.Tables[0].Rows[0]["SMSID"].ToString();
                model.RESVERADDRESSES = ds.Tables[0].Rows[0]["RESVERADDRESSES"].ToString();
                model.SENDERADDRESS = ds.Tables[0].Rows[0]["SENDERADDRESS"].ToString();
                model.LINKID = ds.Tables[0].Rows[0]["LINKID"].ToString();
                model.PRODUCTID = ds.Tables[0].Rows[0]["PRODUCTID"].ToString();
                model.SERVICEID = ds.Tables[0].Rows[0]["SERVICEID"].ToString();
                model.CONTENT = ds.Tables[0].Rows[0]["CONTENT"].ToString();
                model.INSERTTIME = ds.Tables[0].Rows[0]["INSERTTIME"].ToString();
                if (ds.Tables[0].Rows[0]["STATUS"].ToString() != "")
                {
                    model.STATUS = int.Parse(ds.Tables[0].Rows[0]["STATUS"].ToString().Trim());
                }
                model.SENDTIME = ds.Tables[0].Rows[0]["SENDTIME"].ToString();
                model.RESULT = ds.Tables[0].Rows[0]["RESULT"].ToString();
                if (ds.Tables[0].Rows[0]["SENDNUMBER"].ToString() != "")
                {
                    model.SENDNUMBER = int.Parse(ds.Tables[0].Rows[0]["SENDNUMBER"].ToString().Trim());
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
            strSql.Append("select * from ISAG_SENDSMS ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return DbHelperMysqlOdbc.Query(strSql.ToString());
        }
        #endregion  成员方法

        #region IISAG_SENDSMS 成员


        public DictionaryEntry Updatesql(xxty.Model.Post.ISAG_SENDSMS model)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UpdateNotall(xxty.Model.Post.ISAG_SENDSMS model)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}


