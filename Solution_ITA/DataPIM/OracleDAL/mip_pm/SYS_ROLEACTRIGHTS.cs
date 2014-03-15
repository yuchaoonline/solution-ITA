using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using Mis.IDAL.Post;
using DBUtility;//请先添加引用;
using System.Collections;
namespace Mis.OracleDAL.Post
{
	/// <summary>
	/// 数据访问类SYS_ROLEACTRIGHTS。
	/// </summary>
	public class SYS_ROLEACTRIGHTS:ISYS_ROLEACTRIGHTS
	{
		public SYS_ROLEACTRIGHTS()
		{}
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOra.GetMaxID("ID", "SYS_ROLEACTRIGHTS");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_ROLEACTRIGHTS");
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
            strSql.Append("select count(1) from SYS_ROLEACTRIGHTS");
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
        public int Add(Mis.Model.ptgl.SYS_ROLEACTRIGHTS model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_ROLEACTRIGHTS(");
            strSql.Append("ID,ROLEPLID,ACTIONID,ROLESNAME,TYPE)");
            strSql.Append(" values (");
            strSql.Append(":ID,:ROLEPLID,:ACTIONID,:ROLESNAME,:TYPE)");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,10),
					new OracleParameter(":ROLEPLID", OracleType.Number,10),
					new OracleParameter(":ACTIONID", OracleType.Number,10),
					new OracleParameter(":ROLESNAME", OracleType.Number,1),
					new OracleParameter(":TYPE", OracleType.Number,1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ROLEPLID;
            parameters[2].Value = model.ACTIONID;
            parameters[3].Value = model.ROLESNAME;
            parameters[4].Value = model.TYPE;

            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }

        /// <summary>
        /// 事务处理增加一个model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public DictionaryEntry AddSql(Mis.Model.ptgl.SYS_ROLEACTRIGHTS model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_ROLEACTRIGHTS(");
            strSql.Append("ID,ROLEPLID,ACTIONID,ROLESNAME,TYPE)");
            strSql.Append(" values (");
            strSql.Append("SEQSYS_ROLEACTRIGHTS.NEXTVAL,:ROLEPLID,:ACTIONID,:ROLESNAME,:TYPE)");
            OracleParameter[] parameters = {  
					new OracleParameter(":ROLEPLID", OracleType.Number,10),
					new OracleParameter(":ACTIONID", OracleType.Number,10),
					new OracleParameter(":ROLESNAME", OracleType.Number,1),
					new OracleParameter(":TYPE", OracleType.Number,1)};
            parameters[0].Value = model.ROLEPLID;
            parameters[1].Value = model.ACTIONID;
            parameters[2].Value = model.ROLESNAME;
            parameters[3].Value = model.TYPE;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(Mis.Model.ptgl.SYS_ROLEACTRIGHTS model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_ROLEACTRIGHTS(");
            strSql.Append("ID");
            //列出需插入的表字段
            int Param_Num = 0;
            //if (model.ROLEPLID != 0 )
            {
                Param_Num++;
                strSql.Append(",ROLEPLID");
            }
            //if (model.ACTIONID != 0 )
            {
                Param_Num++;
                strSql.Append(",ACTIONID");
            }
            //if (model.ROLESNAME != 0 )
            {
                Param_Num++;
                strSql.Append(",ROLESNAME");
            }
            //if (model.TYPE != 0 )
            {
                Param_Num++;
                strSql.Append(",TYPE");
            }
            strSql.Append(" ) ");
            strSql.Append(" values (");
            strSql.Append(":ID");
            //列出需哟插入的表字段value对象 
            strSql.Append(",:ROLEPLID");
            strSql.Append(",:ACTIONID");
            strSql.Append(",:ROLESNAME");
            strSql.Append(",:TYPE");
            strSql.Append(" ) ");
            OracleParameter[] parameters = new OracleParameter[(Param_Num + 1)];
            parameters[0] = new OracleParameter(":ID", OracleType.Number, 4);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            {
                parameters[index_num] = new OracleParameter(":ROLEPLID", OracleType.VarChar, 10);//角色id
                parameters[index_num].Value = model.ROLEPLID;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":ACTIONID", OracleType.VarChar, 10);//操作id
                parameters[index_num].Value = model.ACTIONID;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":ROLESNAME", OracleType.VarChar, 1);//是否允许
                parameters[index_num].Value = model.ROLESNAME;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":TYPE", OracleType.VarChar, 1);//种类
                parameters[index_num].Value = model.TYPE;
                index_num++;
            }
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters); return model.ID;
        } /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(Mis.Model.ptgl.SYS_ROLEACTRIGHTS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_ROLEACTRIGHTS");
            strSql.Append(" where  ROLEPLID=:ROLEPLID and ACTIONID=:ACTIONID and ROLESNAME=:ROLESNAME and TYPE=:TYPE");
            OracleParameter[] parameters = {  
					new OracleParameter(":ROLEPLID", OracleType.Number,10),
					new OracleParameter(":ACTIONID", OracleType.Number,10),
					new OracleParameter(":ROLESNAME", OracleType.Number,1),
					new OracleParameter(":TYPE", OracleType.Number,1)};
            parameters[0].Value = model.ROLEPLID;
            parameters[1].Value = model.ACTIONID;
            parameters[2].Value = model.ROLESNAME;
            parameters[3].Value = model.TYPE;

            return false;
        }

        public int UpdateNotall(Mis.Model.ptgl.SYS_ROLEACTRIGHTS model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_ROLEACTRIGHTS(");
            strSql.Append("ID");
            //列出需哟插入的表字段
            int Param_Num = 0;
            //if (model.ROLEPLID != 0 )
            {
                Param_Num++;
                strSql.Append(",ROLEPLID");
            }
            //if (model.ACTIONID != 0 )
            {
                Param_Num++;
                strSql.Append(",ACTIONID");
            }
            //if (model.ROLESNAME != 0 )
            {
                Param_Num++;
                strSql.Append(",ROLESNAME");
            }
            //if (model.TYPE != 0 )
            {
                Param_Num++;
                strSql.Append(",TYPE");
            }
            strSql.Append(" ) ");
            strSql.Append(" values (");
            strSql.Append(":ID");
            //列出需哟插入的表字段value对象 
            strSql.Append(",:ROLEPLID");
            strSql.Append(",:ACTIONID");
            strSql.Append(",:ROLESNAME");
            strSql.Append(",:TYPE");
            strSql.Append(" ) ");
            OracleParameter[] parameters = new OracleParameter[(Param_Num + 1)];
            parameters[0] = new OracleParameter(":ID", OracleType.Number, 4);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            {
                parameters[index_num] = new OracleParameter(":ROLEPLID", OracleType.VarChar, 10);//角色id
                parameters[index_num].Value = model.ROLEPLID;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":ACTIONID", OracleType.VarChar, 10);//操作id
                parameters[index_num].Value = model.ACTIONID;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":ROLESNAME", OracleType.VarChar, 1);//是否允许
                parameters[index_num].Value = model.ROLESNAME;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":TYPE", OracleType.VarChar, 1);//种类
                parameters[index_num].Value = model.TYPE;
                index_num++;
            }
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Mis.Model.ptgl.SYS_ROLEACTRIGHTS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_ROLEACTRIGHTS set ");
            strSql.Append("ROLEPLID=:ROLEPLID,");
            strSql.Append("ACTIONID=:ACTIONID,");
            strSql.Append("ROLESNAME=:ROLESNAME,");
            strSql.Append("TYPE=:TYPE");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,10),
					new OracleParameter(":ROLEPLID", OracleType.Number,10),
					new OracleParameter(":ACTIONID", OracleType.Number,10),
					new OracleParameter(":ROLESNAME", OracleType.Number,1),
					new OracleParameter(":TYPE", OracleType.Number,1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ROLEPLID;
            parameters[2].Value = model.ACTIONID;
            parameters[3].Value = model.ROLESNAME;
            parameters[4].Value = model.TYPE;

            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SYS_ROLEACTRIGHTS ");
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
            strSql.Append("delete from SYS_ROLEACTRIGHTS ");
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
        public Mis.Model.ptgl.SYS_ROLEACTRIGHTS GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_ROLEACTRIGHTS ");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
   				new OracleParameter(":ID", OracleType.Number)};
            parameters[0].Value = ID;
            Mis.Model.ptgl.SYS_ROLEACTRIGHTS model = new Mis.Model.ptgl.SYS_ROLEACTRIGHTS();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ROLEPLID"].ToString() != "")
                {
                    model.ROLEPLID = int.Parse(ds.Tables[0].Rows[0]["ROLEPLID"].ToString().Trim());
                }
                if (ds.Tables[0].Rows[0]["ACTIONID"].ToString() != "")
                {
                    model.ACTIONID = int.Parse(ds.Tables[0].Rows[0]["ACTIONID"].ToString().Trim());
                }
                if (ds.Tables[0].Rows[0]["ROLESNAME"].ToString() != "")
                {
                    model.ROLESNAME = int.Parse(ds.Tables[0].Rows[0]["ROLESNAME"].ToString().Trim());
                }
                if (ds.Tables[0].Rows[0]["TYPE"].ToString() != "")
                {
                    model.TYPE = int.Parse(ds.Tables[0].Rows[0]["TYPE"].ToString().Trim());
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
            strSql.Append("select * from SYS_ROLEACTRIGHTS ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return DbHelperOra.Query(strSql.ToString());
        }

        public DictionaryEntry DeleteByroleid(int p_roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_ROLEACTRIGHTS ");
            strSql.Append(" where ROLEPLID=:ROLEPLID");
            OracleParameter[] parameters = {
				new OracleParameter(":ROLEPLID", OracleType.Number,10)
			};
            parameters[0].Value = p_roleid;
            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }
        #endregion  成员方法
	}
}

