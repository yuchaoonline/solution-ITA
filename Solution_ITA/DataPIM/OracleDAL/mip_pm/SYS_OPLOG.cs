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
    /// 数据访问类SYS_OPLOG
    /// </summary>
    public class SYS_OPLOG : ISYS_OPLOG
    {
        public SYS_OPLOG()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOra.GetMaxID("ID", "SYS_OPLOG");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_OPLOG");
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
            strSql.Append("select count(1) from SYS_OPLOG");
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
        public int Add(gtled.Model.Post.SYS_OPLOG model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_OPLOG(");
            strSql.Append("ID,USERID,USERNAME,OPTYPE,OPTIME,REMARK,REMARK1)");
            strSql.Append(" values (");
            strSql.Append(":ID,:USERID,:USERNAME,:OPTYPE,:OPTIME,:REMARK,:REMARK1)");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,14),
					new OracleParameter(":USERID", OracleType.VarChar,30),
					new OracleParameter(":USERNAME", OracleType.VarChar,30),
					new OracleParameter(":OPTYPE", OracleType.VarChar,150),
					new OracleParameter(":OPTIME", OracleType.DateTime),
					new OracleParameter(":REMARK", OracleType.VarChar,220),
					new OracleParameter(":REMARK1", OracleType.VarChar,220)};
            parameters[0].Value = model.ID; //编号
            parameters[1].Value = model.USERID; //用户编号
            parameters[2].Value = model.USERNAME; //用户真实姓名
            parameters[3].Value = model.OPTYPE; //操作种类
            parameters[4].Value = model.OPTIME; //操作时间
            parameters[5].Value = model.REMARK; //备注
            parameters[6].Value = model.REMARK1; //备注1

            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }

        /// <summary>
        /// 事务处理增加一个model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public DictionaryEntry AddSql(gtled.Model.Post.SYS_OPLOG model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_OPLOG(");
            strSql.Append("ID,USERID,USERNAME,OPTYPE,OPTIME,REMARK,REMARK1)");
            strSql.Append(" values (");
            strSql.Append("SEQSYS_OPLOG.NEXTVAL,:USERID,:USERNAME,:OPTYPE,:OPTIME,:REMARK,:REMARK1)");
            OracleParameter[] parameters = {  
					new OracleParameter(":USERID", OracleType.VarChar,30),
					new OracleParameter(":USERNAME", OracleType.VarChar,30),
					new OracleParameter(":OPTYPE", OracleType.VarChar,150),
					new OracleParameter(":OPTIME", OracleType.DateTime),
					new OracleParameter(":REMARK", OracleType.VarChar,220),
					new OracleParameter(":REMARK1", OracleType.VarChar,220)};
            parameters[0].Value = model.USERID; //用户编号
            parameters[1].Value = model.USERNAME; //用户真实姓名
            parameters[2].Value = model.OPTYPE; //操作种类
            parameters[3].Value = model.OPTIME; //操作时间
            parameters[4].Value = model.REMARK; //备注
            parameters[5].Value = model.REMARK1; //备注1

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(gtled.Model.Post.SYS_OPLOG model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_OPLOG(");
            strSql.Append("ID");
            //列出需插入的表字段
            int Param_Num = 0;
            if (model.USERID != "")
            {
                Param_Num++;
                strSql.Append(",USERID");
            }
            if (model.USERNAME != "")
            {
                Param_Num++;
                strSql.Append(",USERNAME");
            }
            if (model.OPTYPE != "")
            {
                Param_Num++;
                strSql.Append(",OPTYPE");
            }
            if (model.OPTIME != "")
            {
                Param_Num++;
                strSql.Append(",OPTIME");
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
            if (model.USERID != "")
            {
                strSql.Append(",:USERID");
            }
            if (model.USERNAME != "")
            {
                strSql.Append(",:USERNAME");
            }
            if (model.OPTYPE != "")
            {
                strSql.Append(",:OPTYPE");
            }
            if (model.OPTIME != "")
            {
                strSql.Append(",:OPTIME");
            }
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
            if (model.USERID != "")
            {
                parameters[index_num] = new OracleParameter(":USERID", OracleType.VarChar, 30);//用户编号
                parameters[index_num].Value = model.USERID;
                index_num++;
            }
            if (model.USERNAME != "")
            {
                parameters[index_num] = new OracleParameter(":USERNAME", OracleType.VarChar, 30);//用户真实姓名
                parameters[index_num].Value = model.USERNAME;
                index_num++;
            }
            if (model.OPTYPE != "")
            {
                parameters[index_num] = new OracleParameter(":OPTYPE", OracleType.VarChar, 150);//操作种类
                parameters[index_num].Value = model.OPTYPE;
                index_num++;
            }
            if (model.OPTIME != "")
            {
                parameters[index_num] = new OracleParameter(":OPTIME", OracleType.DateTime);//操作时间
                parameters[index_num].Value = model.OPTIME;
                index_num++;
            }
            if (model.REMARK != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK", OracleType.VarChar, 220);//备注
                parameters[index_num].Value = model.REMARK;
                index_num++;
            }
            if (model.REMARK1 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK1", OracleType.VarChar, 220);//备注1
                parameters[index_num].Value = model.REMARK1;
                index_num++;
            }
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters); return model.ID;
        } /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(gtled.Model.Post.SYS_OPLOG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_OPLOG");
            strSql.Append(" where  USERID=:USERID and USERNAME=:USERNAME and OPTYPE=:OPTYPE and to_char(OPTIME,'yyyy-mm-dd') =:OPTIME and REMARK=:REMARK and REMARK1=:REMARK1");
            OracleParameter[] parameters = {  
					new OracleParameter(":USERID", OracleType.VarChar,30),
					new OracleParameter(":USERNAME", OracleType.VarChar,30),
					new OracleParameter(":OPTYPE", OracleType.VarChar,150),
					new OracleParameter(":OPTIME", OracleType.DateTime),
					new OracleParameter(":REMARK", OracleType.VarChar,220),
					new OracleParameter(":REMARK1", OracleType.VarChar,220)};
            parameters[0].Value = model.USERID; //用户编号
            parameters[1].Value = model.USERNAME; //用户真实姓名
            parameters[2].Value = model.OPTYPE; //操作种类
            parameters[3].Value = model.OPTIME; //操作时间
            parameters[4].Value = model.REMARK; //备注
            parameters[5].Value = model.REMARK1; //备注1

            return false;
        }

        public int UpdateNotall(gtled.Model.Post.SYS_OPLOG model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_OPLOG(");
            strSql.Append("ID");
            //列出需哟插入的表字段
            int Param_Num = 0;
            if (model.USERID != "")
            {
                Param_Num++;
                strSql.Append(",USERID");
            }
            if (model.USERNAME != "")
            {
                Param_Num++;
                strSql.Append(",USERNAME");
            }
            if (model.OPTYPE != "")
            {
                Param_Num++;
                strSql.Append(",OPTYPE");
            }
            if (model.OPTIME != "")
            {
                Param_Num++;
                strSql.Append(",OPTIME");
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
            if (model.USERID != "")
            {
                strSql.Append(",:USERID");
            }
            if (model.USERNAME != "")
            {
                strSql.Append(",:USERNAME");
            }
            if (model.OPTYPE != "")
            {
                strSql.Append(",:OPTYPE");
            }
            if (model.OPTIME != "")
            {
                strSql.Append(",:OPTIME");
            }
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
            if (model.USERID != "")
            {
                parameters[index_num] = new OracleParameter(":USERID", OracleType.VarChar, 30);//用户编号
                parameters[index_num].Value = model.USERID;
                index_num++;
            }
            if (model.USERNAME != "")
            {
                parameters[index_num] = new OracleParameter(":USERNAME", OracleType.VarChar, 30);//用户真实姓名
                parameters[index_num].Value = model.USERNAME;
                index_num++;
            }
            if (model.OPTYPE != "")
            {
                parameters[index_num] = new OracleParameter(":OPTYPE", OracleType.VarChar, 150);//操作种类
                parameters[index_num].Value = model.OPTYPE;
                index_num++;
            }
            if (model.OPTIME != "")
            {
                parameters[index_num] = new OracleParameter(":OPTIME", OracleType.DateTime);//操作时间
                parameters[index_num].Value = model.OPTIME;
                index_num++;
            }
            if (model.REMARK != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK", OracleType.VarChar, 220);//备注
                parameters[index_num].Value = model.REMARK;
                index_num++;
            }
            if (model.REMARK1 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK1", OracleType.VarChar, 220);//备注1
                parameters[index_num].Value = model.REMARK1;
                index_num++;
            }
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(gtled.Model.Post.SYS_OPLOG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_OPLOG set ");
            strSql.Append("USERID=:USERID,");
            strSql.Append("USERNAME=:USERNAME,");
            strSql.Append("OPTYPE=:OPTYPE,");
            strSql.Append("OPTIME=:OPTIME,");
            strSql.Append("REMARK=:REMARK,");
            strSql.Append("REMARK1=:REMARK1");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,14),
					new OracleParameter(":USERID", OracleType.VarChar,30),
					new OracleParameter(":USERNAME", OracleType.VarChar,30),
					new OracleParameter(":OPTYPE", OracleType.VarChar,150),
					new OracleParameter(":OPTIME", OracleType.DateTime),
					new OracleParameter(":REMARK", OracleType.VarChar,220),
					new OracleParameter(":REMARK1", OracleType.VarChar,220)};
            parameters[0].Value = model.ID; //编号
            parameters[1].Value = model.USERID; //用户编号
            parameters[2].Value = model.USERNAME; //用户真实姓名
            parameters[3].Value = model.OPTYPE; //操作种类
            parameters[4].Value = model.OPTIME; //操作时间
            parameters[5].Value = model.REMARK; //备注
            parameters[6].Value = model.REMARK1; //备注1

            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 事务处理更新一条数据
        /// </summary>
        public DictionaryEntry Updatesql(gtled.Model.Post.SYS_OPLOG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_OPLOG set ");
            strSql.Append("USERID=:USERID,");
            strSql.Append("USERNAME=:USERNAME,");
            strSql.Append("OPTYPE=:OPTYPE,");
            strSql.Append("OPTIME=:OPTIME,");
            strSql.Append("REMARK=:REMARK,");
            strSql.Append("REMARK1=:REMARK1");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,14),
					new OracleParameter(":USERID", OracleType.VarChar,30),
					new OracleParameter(":USERNAME", OracleType.VarChar,30),
					new OracleParameter(":OPTYPE", OracleType.VarChar,150),
					new OracleParameter(":OPTIME", OracleType.DateTime),
					new OracleParameter(":REMARK", OracleType.VarChar,220),
					new OracleParameter(":REMARK1", OracleType.VarChar,220)};
            parameters[0].Value = model.ID; //编号
            parameters[1].Value = model.USERID; //用户编号
            parameters[2].Value = model.USERNAME; //用户真实姓名
            parameters[3].Value = model.OPTYPE; //操作种类
            parameters[4].Value = model.OPTIME; //操作时间
            parameters[5].Value = model.REMARK; //备注
            parameters[6].Value = model.REMARK1; //备注1

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SYS_OPLOG ");
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
            strSql.Append("delete SYS_OPLOG ");
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
        public gtled.Model.Post.SYS_OPLOG GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_OPLOG ");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
   				new OracleParameter(":ID", OracleType.Number)};
            parameters[0].Value = ID;
            gtled.Model.Post.SYS_OPLOG model = new gtled.Model.Post.SYS_OPLOG();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.USERID = ds.Tables[0].Rows[0]["USERID"].ToString();
                model.USERNAME = ds.Tables[0].Rows[0]["USERNAME"].ToString();
                model.OPTYPE = ds.Tables[0].Rows[0]["OPTYPE"].ToString();
                model.OPTIME = ds.Tables[0].Rows[0]["OPTIME"].ToString();
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
            strSql.Append("select * from SYS_OPLOG ");
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


