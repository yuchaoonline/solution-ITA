
using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Data.OracleClient;
using DBUtility;
using Mis.IDAL.Post;//请先添加引用;

namespace Mis.OracleDAL.Post
{
	/// <summary>
	/// 数据访问类SYS_ROLEUSER。
	/// </summary>
	public class SYS_ROLEUSER:ISYS_ROLEUSER
	{
		public SYS_ROLEUSER()
		{}
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOra.GetMaxID("ID", "SYS_ROLEUSER");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_ROLEUSER");
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
            strSql.Append("select count(1) from SYS_ROLEUSER");
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
        public int Add(Mis.Model.ptgl.SYS_ROLEUSER model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_ROLEUSER(");
            strSql.Append("ID,ROLEID,USERID,DESCRIPTION)");
            strSql.Append(" values (");
            strSql.Append(":ID,:ROLEID,:USERID,:DESCRIPTION)");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,10),
					new OracleParameter(":ROLEID", OracleType.Number,10),
					new OracleParameter(":USERID", OracleType.Number,10),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,200)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ROLEID;
            parameters[2].Value = model.USERID;
            parameters[3].Value = model.DESCRIPTION;

            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }

        /// <summary>
        /// 事务处理增加一个model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public DictionaryEntry AddSql(Mis.Model.ptgl.SYS_ROLEUSER model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_ROLEUSER(");
            strSql.Append("ID,ROLEID,USERID,DESCRIPTION)");
            strSql.Append(" values (");
            strSql.Append("SEQSYS_ROLEUSER.NEXTVAL,:ROLEID,:USERID,:DESCRIPTION)");
            OracleParameter[] parameters = {  
					new OracleParameter(":ROLEID", OracleType.Number,10),
					new OracleParameter(":USERID", OracleType.Number,10),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,200)};
            parameters[0].Value = model.ROLEID;
            parameters[1].Value = model.USERID;
            parameters[2].Value = model.DESCRIPTION;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(Mis.Model.ptgl.SYS_ROLEUSER model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_ROLEUSER(");
            strSql.Append("ID");
            //列出需插入的表字段
            int Param_Num = 0;
            //if (model.ROLEID != 0 )
            {
                Param_Num++;
                strSql.Append(",ROLEID");
            }
            //if (model.USERID != 0 )
            {
                Param_Num++;
                strSql.Append(",USERID");
            }
            if (model.DESCRIPTION != "")
            {
                Param_Num++;
                strSql.Append(",DESCRIPTION");
            }
            strSql.Append(" ) ");
            strSql.Append(" values (");
            strSql.Append(":ID");
            //列出需哟插入的表字段value对象 
            strSql.Append(",:ROLEID");
            strSql.Append(",:USERID");
            if (model.DESCRIPTION != "")
            {
                strSql.Append(",:DESCRIPTION");
            }
            strSql.Append(" ) ");
            OracleParameter[] parameters = new OracleParameter[(Param_Num + 1)];
            parameters[0] = new OracleParameter(":ID", OracleType.Number, 4);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            {
                parameters[index_num] = new OracleParameter(":ROLEID", OracleType.VarChar, 10);//角色id
                parameters[index_num].Value = model.ROLEID;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":USERID", OracleType.VarChar, 10);//用户id
                parameters[index_num].Value = model.USERID;
                index_num++;
            }
            if (model.DESCRIPTION != "")
            {
                parameters[index_num] = new OracleParameter(":DESCRIPTION", OracleType.VarChar, 200);//描述
                parameters[index_num].Value = model.DESCRIPTION;
                index_num++;
            }
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters); return model.ID;
        } /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(Mis.Model.ptgl.SYS_ROLEUSER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_ROLEUSER");
            strSql.Append(" where  ROLEID=:ROLEID and USERID=:USERID and DESCRIPTION=:DESCRIPTION");
            OracleParameter[] parameters = {  
					new OracleParameter(":ROLEID", OracleType.Number,10),
					new OracleParameter(":USERID", OracleType.Number,10),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,200)};
            parameters[0].Value = model.ROLEID;
            parameters[1].Value = model.USERID;
            parameters[2].Value = model.DESCRIPTION;

            return false;
        }

        public int UpdateNotall(Mis.Model.ptgl.SYS_ROLEUSER model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_ROLEUSER(");
            strSql.Append("ID");
            //列出需哟插入的表字段
            int Param_Num = 0;
            //if (model.ROLEID != 0 )
            {
                Param_Num++;
                strSql.Append(",ROLEID");
            }
            //if (model.USERID != 0 )
            {
                Param_Num++;
                strSql.Append(",USERID");
            }
            if (model.DESCRIPTION != "")
            {
                Param_Num++;
                strSql.Append(",DESCRIPTION");
            }
            strSql.Append(" ) ");
            strSql.Append(" values (");
            strSql.Append(":ID");
            //列出需哟插入的表字段value对象 
            strSql.Append(",:ROLEID");
            strSql.Append(",:USERID");
            if (model.DESCRIPTION != "")
            {
                strSql.Append(",:DESCRIPTION");
            }
            strSql.Append(" ) ");
            OracleParameter[] parameters = new OracleParameter[(Param_Num + 1)];
            parameters[0] = new OracleParameter(":ID", OracleType.Number, 4);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            {
                parameters[index_num] = new OracleParameter(":ROLEID", OracleType.VarChar, 10);//角色id
                parameters[index_num].Value = model.ROLEID;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":USERID", OracleType.VarChar, 10);//用户id
                parameters[index_num].Value = model.USERID;
                index_num++;
            }
            if (model.DESCRIPTION != "")
            {
                parameters[index_num] = new OracleParameter(":DESCRIPTION", OracleType.VarChar, 200);//描述
                parameters[index_num].Value = model.DESCRIPTION;
                index_num++;
            }
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Mis.Model.ptgl.SYS_ROLEUSER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_ROLEUSER set ");
            strSql.Append("ROLEID=:ROLEID,");
            strSql.Append("USERID=:USERID,");
            strSql.Append("DESCRIPTION=:DESCRIPTION");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,10),
					new OracleParameter(":ROLEID", OracleType.Number,10),
					new OracleParameter(":USERID", OracleType.Number,10),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,200)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ROLEID;
            parameters[2].Value = model.USERID;
            parameters[3].Value = model.DESCRIPTION;

            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SYS_ROLEUSER ");
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
            strSql.Append("delete from SYS_ROLEUSER ");
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
        public Mis.Model.ptgl.SYS_ROLEUSER GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_ROLEUSER ");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
   				new OracleParameter(":ID", OracleType.Number)};
            parameters[0].Value = ID;
            Mis.Model.ptgl.SYS_ROLEUSER model = new Mis.Model.ptgl.SYS_ROLEUSER();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ROLEID"].ToString() != "")
                {
                    model.ROLEID = int.Parse(ds.Tables[0].Rows[0]["ROLEID"].ToString().Trim());
                }
                if (ds.Tables[0].Rows[0]["USERID"].ToString() != "")
                {
                    model.USERID = int.Parse(ds.Tables[0].Rows[0]["USERID"].ToString().Trim());
                }
                model.DESCRIPTION = ds.Tables[0].Rows[0]["DESCRIPTION"].ToString();
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
            strSql.Append("select * from SYS_ROLEUSER ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion  成员方法

        #region ISYS_ROLEUSER 成员


        public DictionaryEntry DeleteUserRole(int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_ROLEUSER ");
            strSql.Append(" where USERID=:USERID");
            OracleParameter[] parameters = {
				new OracleParameter(":USERID", OracleType.Number,10)
			};
            parameters[0].Value = userid;
            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        #endregion
    }
}

