using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using Mis.IDAL.Post;
using DBUtility;
using System.Collections;//请先添加引用;

namespace Mis.OracleDAL.Post
{
    /// <summary>
    /// 数据访问类SYS_ROLES。
    /// </summary>
    public class SYS_ROLES : ISYS_ROLES
    {
        public SYS_ROLES()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOra.GetMaxID("ID", "SYS_ROLES");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_ROLES");
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
            strSql.Append("select count(1) from SYS_ROLES");
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
        public int Add(Mis.Model.ptgl.SYS_ROLES model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_ROLES(");
            strSql.Append("ID,ROLENO,USERNO,DESCRIPTION,SYSDATATYPE)");
            strSql.Append(" values (");
            strSql.Append(":ID,:ROLENO,:USERNO,:DESCRIPTION,:SYSDATATYPE)");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,10),
					new OracleParameter(":ROLENO", OracleType.VarChar,30),
					new OracleParameter(":USERNO", OracleType.VarChar,30),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,200),
                    new OracleParameter(":SYSDATATYPE", OracleType.VarChar,2)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ROLENO;
            parameters[2].Value = model.USERNO;
            parameters[3].Value = model.DESCRIPTION;
            parameters[4].Value = model.SYSDATATYPE;

            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }

        /// <summary>
        /// 事务处理增加一个model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public DictionaryEntry AddSql(Mis.Model.ptgl.SYS_ROLES model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_ROLES(");
            strSql.Append("ID,ROLENO,USERNO,DESCRIPTION,SYSDATATYPE)");
            strSql.Append(" values (");
            strSql.Append("SEQSYS_ROLES.NEXTVAL,:ROLENO,:USERNO,:DESCRIPTION,:SYSDATATYPE)");
            OracleParameter[] parameters = {  
					new OracleParameter(":ROLENO", OracleType.VarChar,30),
					new OracleParameter(":USERNO", OracleType.VarChar,30),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,200),
                    new OracleParameter(":SYSDATATYPE", OracleType.VarChar,2)};
            parameters[0].Value = model.ROLENO;
            parameters[1].Value = model.USERNO;
            parameters[2].Value = model.DESCRIPTION;
            parameters[3].Value = model.SYSDATATYPE;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(Mis.Model.ptgl.SYS_ROLES model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_ROLES(");
            strSql.Append("ID");
            //列出需插入的表字段
            int Param_Num = 0;
            if (model.ROLENO != "")
            {
                Param_Num++;
                strSql.Append(",ROLENO");
            }
            if (model.USERNO != "")
            {
                Param_Num++;
                strSql.Append(",USERNO");
            }
            if (model.DESCRIPTION != "")
            {
                Param_Num++;
                strSql.Append(",DESCRIPTION");
            }
            if (model.SYSDATATYPE != "")
            {
                Param_Num++;
                strSql.Append(",SYSDATATYPE");
            }
            strSql.Append(" ) ");
            strSql.Append(" values (");
            strSql.Append(":ID");
            //列出需哟插入的表字段value对象 
            if (model.ROLENO != "")
            {
                strSql.Append(",:ROLENO");
            }
            if (model.USERNO != "")
            {
                strSql.Append(",:USERNO");
            }
            if (model.DESCRIPTION != "")
            {
                strSql.Append(",:DESCRIPTION");
            }
            if (model.SYSDATATYPE != "")
            {
                strSql.Append(",:SYSDATATYPE");
            }
            strSql.Append(" ) ");
            OracleParameter[] parameters = new OracleParameter[(Param_Num + 1)];
            parameters[0] = new OracleParameter(":ID", OracleType.Number, 4);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            if (model.ROLENO != "")
            {
                parameters[index_num] = new OracleParameter(":ROLENO", OracleType.VarChar, 30);//角色编号
                parameters[index_num].Value = model.ROLENO;
                index_num++;
            }
            if (model.USERNO != "")
            {
                parameters[index_num] = new OracleParameter(":USERNO", OracleType.VarChar, 30);//角色名称
                parameters[index_num].Value = model.USERNO;
                index_num++;
            }
            if (model.DESCRIPTION != "")
            {
                parameters[index_num] = new OracleParameter(":DESCRIPTION", OracleType.VarChar, 200);//描述
                parameters[index_num].Value = model.DESCRIPTION;
                index_num++;
            }
            if (model.SYSDATATYPE != "")
            {
                parameters[index_num] = new OracleParameter(":SYSDATATYPE", OracleType.VarChar, 2);//描述
                parameters[index_num].Value = model.SYSDATATYPE;
                index_num++;
            }
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters); return model.ID;
        } /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(Mis.Model.ptgl.SYS_ROLES model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_ROLES");
            strSql.Append(" where  ROLENO=:ROLENO and USERNO=:USERNO and DESCRIPTION=:DESCRIPTION");
            OracleParameter[] parameters = {  
					new OracleParameter(":ROLENO", OracleType.VarChar,30),
					new OracleParameter(":USERNO", OracleType.VarChar,30),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,200)};
            parameters[0].Value = model.ROLENO;
            parameters[1].Value = model.USERNO;
            parameters[2].Value = model.DESCRIPTION;

            return false;
        }

        public int UpdateNotall(Mis.Model.ptgl.SYS_ROLES model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_ROLES(");
            strSql.Append("ID");
            //列出需哟插入的表字段
            int Param_Num = 0;
            if (model.ROLENO != "")
            {
                Param_Num++;
                strSql.Append(",ROLENO");
            }
            if (model.USERNO != "")
            {
                Param_Num++;
                strSql.Append(",USERNO");
            }
            if (model.DESCRIPTION != "")
            {
                Param_Num++;
                strSql.Append(",DESCRIPTION");
            }
            if (model.SYSDATATYPE != "")
            {
                Param_Num++;
                strSql.Append(",SYSDATATYPE");
            }
            strSql.Append(" ) ");
            strSql.Append(" values (");
            strSql.Append(":ID");
            //列出需哟插入的表字段value对象 
            if (model.ROLENO != "")
            {
                strSql.Append(",:ROLENO");
            }
            if (model.USERNO != "")
            {
                strSql.Append(",:USERNO");
            }
            if (model.DESCRIPTION != "")
            {
                strSql.Append(",:DESCRIPTION");
            }
            if (model.SYSDATATYPE != "")
            {
                strSql.Append(",:SYSDATATYPE");
            }
            strSql.Append(" ) ");
            OracleParameter[] parameters = new OracleParameter[(Param_Num + 1)];
            parameters[0] = new OracleParameter(":ID", OracleType.Number, 4);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            if (model.ROLENO != "")
            {
                parameters[index_num] = new OracleParameter(":ROLENO", OracleType.VarChar, 30);//角色编号
                parameters[index_num].Value = model.ROLENO;
                index_num++;
            }
            if (model.USERNO != "")
            {
                parameters[index_num] = new OracleParameter(":USERNO", OracleType.VarChar, 30);//角色名称
                parameters[index_num].Value = model.USERNO;
                index_num++;
            }
            if (model.DESCRIPTION != "")
            {
                parameters[index_num] = new OracleParameter(":DESCRIPTION", OracleType.VarChar, 200);//描述
                parameters[index_num].Value = model.DESCRIPTION;
                index_num++;
            }
            if (model.SYSDATATYPE != "")
            {
                parameters[index_num] = new OracleParameter(":SYSDATATYPE", OracleType.VarChar, 2);//描述
                parameters[index_num].Value = model.SYSDATATYPE;
                index_num++;
            }
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Mis.Model.ptgl.SYS_ROLES model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_ROLES set ");
            strSql.Append("ROLENO=:ROLENO,");
            strSql.Append("USERNO=:USERNO,");
            strSql.Append("DESCRIPTION=:DESCRIPTION,");
            strSql.Append("SYSDATATYPE=:SYSDATATYPE");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,10),
					new OracleParameter(":ROLENO", OracleType.VarChar,30),
					new OracleParameter(":USERNO", OracleType.VarChar,30),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,200),
                    new OracleParameter(":SYSDATATYPE", OracleType.VarChar,2)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ROLENO;
            parameters[2].Value = model.USERNO;
            parameters[3].Value = model.DESCRIPTION;
            parameters[4].Value = model.SYSDATATYPE;

            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SYS_ROLES ");
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
            strSql.Append("delete from SYS_ROLES ");
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
        public Mis.Model.ptgl.SYS_ROLES GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_ROLES ");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
   				new OracleParameter(":ID", OracleType.Number)};
            parameters[0].Value = ID;
            Mis.Model.ptgl.SYS_ROLES model = new Mis.Model.ptgl.SYS_ROLES();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ROLENO = ds.Tables[0].Rows[0]["ROLENO"].ToString();
                model.USERNO = ds.Tables[0].Rows[0]["USERNO"].ToString();
                model.DESCRIPTION = ds.Tables[0].Rows[0]["DESCRIPTION"].ToString();
                model.SYSDATATYPE = ds.Tables[0].Rows[0]["SYSDATATYPE"].ToString();
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
            strSql.Append("select * from SYS_ROLES ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion  成员方法

      
    }
}

