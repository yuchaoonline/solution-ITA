using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using DBUtility;
using System.Collections;
using Mis.IDAL.Post;

namespace Mis.OracleDAL.Post
{

    /// <summary>
    /// 数据访问类SYS_MAILRUN
    /// </summary>
    public class SYS_MAILRUN : ISYS_MAILRUN
    {
        public SYS_MAILRUN()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOra.GetMaxID("ID", "SYS_MAILRUN");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_MAILRUN");
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
            strSql.Append("select count(1) from SYS_MAILRUN");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID  desc ");
            return DbHelperOra.Exists(strSql.ToString());
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(gtled.Model.Post.SYS_MAILRUN model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_MAILRUN(");
            strSql.Append("ID,MAILSUBJECT,MAILCONTENT,SENDTIME,STATUS,RESENDNUM,REMARK,REMARK1)");
            strSql.Append(" values (");
            strSql.Append(":ID,:MAILSUBJECT,:MAILCONTENT,:SENDTIME,:STATUS,:RESENDNUM,:REMARK,:REMARK1)");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,10),
					new OracleParameter(":MAILSUBJECT", OracleType.VarChar,256),
					new OracleParameter(":MAILCONTENT", OracleType.VarChar,2048),
					new OracleParameter(":SENDTIME", OracleType.VarChar,20),
					new OracleParameter(":STATUS", OracleType.Number,7),
					new OracleParameter(":RESENDNUM", OracleType.Number,7),
					new OracleParameter(":REMARK", OracleType.VarChar,128),
					new OracleParameter(":REMARK1", OracleType.VarChar,128)};
            parameters[0].Value = model.ID; //编号
            parameters[1].Value = model.MAILSUBJECT; //邮件的标题
            parameters[2].Value = model.MAILCONTENT; //邮件的内容
            parameters[3].Value = model.SENDTIME; //发送时间
            parameters[4].Value = model.STATUS; //邮件所处的状态
            parameters[5].Value = model.RESENDNUM; //重发次数
            parameters[6].Value = model.REMARK; //备注
            parameters[7].Value = model.REMARK1; //备注1

            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }

        /// <summary>
        /// 事务处理增加一个model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public DictionaryEntry AddSql(gtled.Model.Post.SYS_MAILRUN model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_MAILRUN(");
            strSql.Append("ID,MAILSUBJECT,MAILCONTENT,SENDTIME,STATUS,RESENDNUM,REMARK,REMARK1)");
            strSql.Append(" values (");
            strSql.Append("SEQSYS_MAILRUN.NEXTVAL,:MAILSUBJECT,:MAILCONTENT,:SENDTIME,:STATUS,:RESENDNUM,:REMARK,:REMARK1)");
            OracleParameter[] parameters = {  
					new OracleParameter(":MAILSUBJECT", OracleType.VarChar,256),
					new OracleParameter(":MAILCONTENT", OracleType.VarChar,2048),
					new OracleParameter(":SENDTIME", OracleType.VarChar,20),
					new OracleParameter(":STATUS", OracleType.Number,7),
					new OracleParameter(":RESENDNUM", OracleType.Number,7),
					new OracleParameter(":REMARK", OracleType.VarChar,128),
					new OracleParameter(":REMARK1", OracleType.VarChar,128)};
            parameters[0].Value = model.MAILSUBJECT; //邮件的标题
            parameters[1].Value = model.MAILCONTENT; //邮件的内容
            parameters[2].Value = model.SENDTIME; //发送时间
            parameters[3].Value = model.STATUS; //邮件所处的状态
            parameters[4].Value = model.RESENDNUM; //重发次数
            parameters[5].Value = model.REMARK; //备注
            parameters[6].Value = model.REMARK1; //备注1

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(gtled.Model.Post.SYS_MAILRUN model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_MAILRUN(");
            strSql.Append("ID");
            //列出需插入的表字段
            int Param_Num = 0;
            if (model.MAILSUBJECT != "")
            {
                Param_Num++;
                strSql.Append(",MAILSUBJECT");
            }
            if (model.MAILCONTENT != "")
            {
                Param_Num++;
                strSql.Append(",MAILCONTENT");
            }
            if (model.SENDTIME != "")
            {
                Param_Num++;
                strSql.Append(",SENDTIME");
            }
            //if (model.STATUS != 0 )
            {
                Param_Num++;
                strSql.Append(",STATUS");
            }
            //if (model.RESENDNUM != 0 )
            {
                Param_Num++;
                strSql.Append(",RESENDNUM");
            }
            if (model.REMARK != "")
            {
                Param_Num++;
                strSql.Append(",REMARK");
            }
            if (model.REMARK1 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK1");
            }
            strSql.Append(" ) ");
            strSql.Append(" values (");
            strSql.Append(":ID");
            //列出需哟插入的表字段value对象 
            if (model.MAILSUBJECT != "")
            {
                strSql.Append(",:MAILSUBJECT");
            }
            if (model.MAILCONTENT != "")
            {
                strSql.Append(",:MAILCONTENT");
            }
            if (model.SENDTIME != "")
            {
                strSql.Append(",:SENDTIME");
            }
            strSql.Append(",:STATUS");
            strSql.Append(",:RESENDNUM");
            if (model.REMARK != "")
            {
                strSql.Append(",:REMARK");
            }
            if (model.REMARK1 != "")
            {
                strSql.Append(",:REMARK1");
            }
            strSql.Append(" ) ");
            OracleParameter[] parameters = new OracleParameter[(Param_Num + 1)];
            parameters[0] = new OracleParameter(":ID", OracleType.Number, 4);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            if (model.MAILSUBJECT != "")
            {
                parameters[index_num] = new OracleParameter(":MAILSUBJECT", OracleType.VarChar, 256);//邮件的标题
                parameters[index_num].Value = model.MAILSUBJECT;
                index_num++;
            }
            if (model.MAILCONTENT != "")
            {
                parameters[index_num] = new OracleParameter(":MAILCONTENT", OracleType.VarChar, 2048);//邮件的内容
                parameters[index_num].Value = model.MAILCONTENT;
                index_num++;
            }
            if (model.SENDTIME != "")
            {
                parameters[index_num] = new OracleParameter(":SENDTIME", OracleType.VarChar, 20);//发送时间
                parameters[index_num].Value = model.SENDTIME;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":STATUS", OracleType.VarChar, 7);//邮件所处的状态
                parameters[index_num].Value = model.STATUS;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":RESENDNUM", OracleType.VarChar, 7);//重发次数
                parameters[index_num].Value = model.RESENDNUM;
                index_num++;
            }
            if (model.REMARK != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK", OracleType.VarChar, 128);//备注
                parameters[index_num].Value = model.REMARK;
                index_num++;
            }
            if (model.REMARK1 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK1", OracleType.VarChar, 128);//备注1
                parameters[index_num].Value = model.REMARK1;
                index_num++;
            }
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters); return model.ID;
        } /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(gtled.Model.Post.SYS_MAILRUN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_MAILRUN");
            strSql.Append(" where  MAILSUBJECT=:MAILSUBJECT and MAILCONTENT=:MAILCONTENT and SENDTIME=:SENDTIME and STATUS=:STATUS and RESENDNUM=:RESENDNUM and REMARK=:REMARK and REMARK1=:REMARK1");
            OracleParameter[] parameters = {  
					new OracleParameter(":MAILSUBJECT", OracleType.VarChar,256),
					new OracleParameter(":MAILCONTENT", OracleType.VarChar,2048),
					new OracleParameter(":SENDTIME", OracleType.VarChar,20),
					new OracleParameter(":STATUS", OracleType.Number,7),
					new OracleParameter(":RESENDNUM", OracleType.Number,7),
					new OracleParameter(":REMARK", OracleType.VarChar,128),
					new OracleParameter(":REMARK1", OracleType.VarChar,128)};
            parameters[0].Value = model.MAILSUBJECT; //邮件的标题
            parameters[1].Value = model.MAILCONTENT; //邮件的内容
            parameters[2].Value = model.SENDTIME; //发送时间
            parameters[3].Value = model.STATUS; //邮件所处的状态
            parameters[4].Value = model.RESENDNUM; //重发次数
            parameters[5].Value = model.REMARK; //备注
            parameters[6].Value = model.REMARK1; //备注1

            return false;
        }

        public int UpdateNotall(gtled.Model.Post.SYS_MAILRUN model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_MAILRUN(");
            strSql.Append("ID");
            //列出需哟插入的表字段
            int Param_Num = 0;
            if (model.MAILSUBJECT != "")
            {
                Param_Num++;
                strSql.Append(",MAILSUBJECT");
            }
            if (model.MAILCONTENT != "")
            {
                Param_Num++;
                strSql.Append(",MAILCONTENT");
            }
            if (model.SENDTIME != "")
            {
                Param_Num++;
                strSql.Append(",SENDTIME");
            }
            //if (model.STATUS != 0 )
            {
                Param_Num++;
                strSql.Append(",STATUS");
            }
            //if (model.RESENDNUM != 0 )
            {
                Param_Num++;
                strSql.Append(",RESENDNUM");
            }
            if (model.REMARK != "")
            {
                Param_Num++;
                strSql.Append(",REMARK");
            }
            if (model.REMARK1 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK1");
            }
            strSql.Append(" ) ");
            strSql.Append(" values (");
            strSql.Append(":ID");
            //列出需哟插入的表字段value对象 
            if (model.MAILSUBJECT != "")
            {
                strSql.Append(",:MAILSUBJECT");
            }
            if (model.MAILCONTENT != "")
            {
                strSql.Append(",:MAILCONTENT");
            }
            if (model.SENDTIME != "")
            {
                strSql.Append(",:SENDTIME");
            }
            strSql.Append(",:STATUS");
            strSql.Append(",:RESENDNUM");
            if (model.REMARK != "")
            {
                strSql.Append(",:REMARK");
            }
            if (model.REMARK1 != "")
            {
                strSql.Append(",:REMARK1");
            }
            strSql.Append(" ) ");
            OracleParameter[] parameters = new OracleParameter[(Param_Num + 1)];
            parameters[0] = new OracleParameter(":ID", OracleType.Number, 4);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            if (model.MAILSUBJECT != "")
            {
                parameters[index_num] = new OracleParameter(":MAILSUBJECT", OracleType.VarChar, 256);//邮件的标题
                parameters[index_num].Value = model.MAILSUBJECT;
                index_num++;
            }
            if (model.MAILCONTENT != "")
            {
                parameters[index_num] = new OracleParameter(":MAILCONTENT", OracleType.VarChar, 2048);//邮件的内容
                parameters[index_num].Value = model.MAILCONTENT;
                index_num++;
            }
            if (model.SENDTIME != "")
            {
                parameters[index_num] = new OracleParameter(":SENDTIME", OracleType.VarChar, 20);//发送时间
                parameters[index_num].Value = model.SENDTIME;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":STATUS", OracleType.VarChar, 7);//邮件所处的状态
                parameters[index_num].Value = model.STATUS;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":RESENDNUM", OracleType.VarChar, 7);//重发次数
                parameters[index_num].Value = model.RESENDNUM;
                index_num++;
            }
            if (model.REMARK != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK", OracleType.VarChar, 128);//备注
                parameters[index_num].Value = model.REMARK;
                index_num++;
            }
            if (model.REMARK1 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK1", OracleType.VarChar, 128);//备注1
                parameters[index_num].Value = model.REMARK1;
                index_num++;
            }
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(gtled.Model.Post.SYS_MAILRUN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_MAILRUN set ");
            strSql.Append("MAILSUBJECT=:MAILSUBJECT,");
            strSql.Append("MAILCONTENT=:MAILCONTENT,");
            strSql.Append("SENDTIME=:SENDTIME,");
            strSql.Append("STATUS=:STATUS,");
            strSql.Append("RESENDNUM=:RESENDNUM,");
            strSql.Append("REMARK=:REMARK,");
            strSql.Append("REMARK1=:REMARK1");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,10),
					new OracleParameter(":MAILSUBJECT", OracleType.VarChar,256),
					new OracleParameter(":MAILCONTENT", OracleType.VarChar,2048),
					new OracleParameter(":SENDTIME", OracleType.VarChar,20),
					new OracleParameter(":STATUS", OracleType.Number,7),
					new OracleParameter(":RESENDNUM", OracleType.Number,7),
					new OracleParameter(":REMARK", OracleType.VarChar,128),
					new OracleParameter(":REMARK1", OracleType.VarChar,128)};
            parameters[0].Value = model.ID; //编号
            parameters[1].Value = model.MAILSUBJECT; //邮件的标题
            parameters[2].Value = model.MAILCONTENT; //邮件的内容
            parameters[3].Value = model.SENDTIME; //发送时间
            parameters[4].Value = model.STATUS; //邮件所处的状态
            parameters[5].Value = model.RESENDNUM; //重发次数
            parameters[6].Value = model.REMARK; //备注
            parameters[7].Value = model.REMARK1; //备注1

            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 事务处理更新一条数据
        /// </summary>
        public DictionaryEntry Updatesql(gtled.Model.Post.SYS_MAILRUN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_MAILRUN set ");
            strSql.Append("MAILSUBJECT=:MAILSUBJECT,");
            strSql.Append("MAILCONTENT=:MAILCONTENT,");
            strSql.Append("SENDTIME=:SENDTIME,");
            strSql.Append("STATUS=:STATUS,");
            strSql.Append("RESENDNUM=:RESENDNUM,");
            strSql.Append("REMARK=:REMARK,");
            strSql.Append("REMARK1=:REMARK1");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,10),
					new OracleParameter(":MAILSUBJECT", OracleType.VarChar,256),
					new OracleParameter(":MAILCONTENT", OracleType.VarChar,2048),
					new OracleParameter(":SENDTIME", OracleType.VarChar,20),
					new OracleParameter(":STATUS", OracleType.Number,7),
					new OracleParameter(":RESENDNUM", OracleType.Number,7),
					new OracleParameter(":REMARK", OracleType.VarChar,128),
					new OracleParameter(":REMARK1", OracleType.VarChar,128)};
            parameters[0].Value = model.ID; //编号
            parameters[1].Value = model.MAILSUBJECT; //邮件的标题
            parameters[2].Value = model.MAILCONTENT; //邮件的内容
            parameters[3].Value = model.SENDTIME; //发送时间
            parameters[4].Value = model.STATUS; //邮件所处的状态
            parameters[5].Value = model.RESENDNUM; //重发次数
            parameters[6].Value = model.REMARK; //备注
            parameters[7].Value = model.REMARK1; //备注1

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SYS_MAILRUN ");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
				new OracleParameter(":ID", OracleType.Number)
			};
            parameters[0].Value = ID;
            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 事务处理删除 (int ID)
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DictionaryEntry DeleteSql(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SYS_MAILRUN ");
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
        public gtled.Model.Post.SYS_MAILRUN GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_MAILRUN ");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
   				new OracleParameter(":ID", OracleType.Number)};
            parameters[0].Value = ID;
            gtled.Model.Post.SYS_MAILRUN model = new gtled.Model.Post.SYS_MAILRUN();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.MAILSUBJECT = ds.Tables[0].Rows[0]["MAILSUBJECT"].ToString();
                model.MAILCONTENT = ds.Tables[0].Rows[0]["MAILCONTENT"].ToString();
                model.SENDTIME = ds.Tables[0].Rows[0]["SENDTIME"].ToString();
                if (ds.Tables[0].Rows[0]["STATUS"].ToString() != "")
                {
                    model.STATUS = int.Parse(ds.Tables[0].Rows[0]["STATUS"].ToString().Trim());
                }
                if (ds.Tables[0].Rows[0]["RESENDNUM"].ToString() != "")
                {
                    model.RESENDNUM = int.Parse(ds.Tables[0].Rows[0]["RESENDNUM"].ToString().Trim());
                }
                model.REMARK = ds.Tables[0].Rows[0]["REMARK"].ToString();
                model.REMARK1 = ds.Tables[0].Rows[0]["REMARK1"].ToString();
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
            strSql.Append("select * from SYS_MAILRUN ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID  desc ");
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}


