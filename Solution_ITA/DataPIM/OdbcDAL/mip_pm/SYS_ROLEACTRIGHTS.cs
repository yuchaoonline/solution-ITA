using System;
using System.Data;
using System.Text;
using System.Data.Odbc;
using DBUtility;
using System.Collections;
using Mis.IDAL.Post;

namespace Mis.OdbcDAL.Post
{

    /// <summary>
    /// 数据访问类SYS_ROLEACTRIGHTS
    /// </summary>
    public class SYS_ROLEACTRIGHTS : ISYS_ROLEACTRIGHTS
    {
        public SYS_ROLEACTRIGHTS()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMysqlOdbc.GetMaxID("ID", "SYS_ROLEACTRIGHTS");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_ROLEACTRIGHTS");
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
            strSql.Append("select count(1) from SYS_ROLEACTRIGHTS");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID");
            return DbHelperMysqlOdbc.Exists(strSql.ToString());
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
            strSql.Append(" ? , ? , ? , ? , ? )");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@ROLEPLID", OdbcType.Int),
					new OdbcParameter("@ACTIONID", OdbcType.Int),
					new OdbcParameter("@ROLESNAME", OdbcType.Int),
					new OdbcParameter("@TYPE", OdbcType.Int)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ROLEPLID;
            parameters[2].Value = model.ACTIONID;
            parameters[3].Value = model.ROLESNAME;
            parameters[4].Value = model.TYPE;

            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
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
            strSql.Append("ROLEPLID,ACTIONID,ROLESNAME,TYPE)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? )");
            OdbcParameter[] parameters = {  
					new OdbcParameter("@ROLEPLID", OdbcType.Int),
					new OdbcParameter("@ACTIONID", OdbcType.Int),
					new OdbcParameter("@ROLESNAME", OdbcType.Int),
					new OdbcParameter("@TYPE", OdbcType.Int)};
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
            strSql.Append("?");
            //列出需哟插入的表字段value对象 
            strSql.Append(",?");
            strSql.Append(",?");
            strSql.Append(",?");
            strSql.Append(",?");
            strSql.Append(" ) ");
            OdbcParameter[] parameters = new OdbcParameter[(Param_Num + 1)];
            parameters[0] = new OdbcParameter("@ID", OdbcType.Int);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            {
                parameters[index_num] = new OdbcParameter("@ROLEPLID", OdbcType.Int);//角色id
                parameters[index_num].Value = model.ROLEPLID;
                index_num++;
            }
            {
                parameters[index_num] = new OdbcParameter("@ACTIONID", OdbcType.Int);//操作id
                parameters[index_num].Value = model.ACTIONID;
                index_num++;
            }
            {
                parameters[index_num] = new OdbcParameter("@ROLESNAME", OdbcType.Int);//是否允许
                parameters[index_num].Value = model.ROLESNAME;
                index_num++;
            }
            {
                parameters[index_num] = new OdbcParameter("@TYPE", OdbcType.Int);//种类
                parameters[index_num].Value = model.TYPE;
                index_num++;
            }
            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters); return model.ID;
        } /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(Mis.Model.ptgl.SYS_ROLEACTRIGHTS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_ROLEACTRIGHTS");
            strSql.Append(" where  ROLEPLID=? and ACTIONID=? and ROLESNAME=? and TYPE=?");
            OdbcParameter[] parameters = {  
					new OdbcParameter("@ROLEPLID", OdbcType.Int),
					new OdbcParameter("@ACTIONID", OdbcType.Int),
					new OdbcParameter("@ROLESNAME", OdbcType.Int),
					new OdbcParameter("@TYPE", OdbcType.Int)};
            parameters[0].Value = model.ROLEPLID;
            parameters[1].Value = model.ACTIONID;
            parameters[2].Value = model.ROLESNAME;
            parameters[3].Value = model.TYPE;

            return DbHelperMysqlOdbc.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Mis.Model.ptgl.SYS_ROLEACTRIGHTS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_ROLEACTRIGHTS set ");
            strSql.Append("ROLEPLID= ?,");
            strSql.Append("ACTIONID= ?,");
            strSql.Append("ROLESNAME= ?,");
            strSql.Append("TYPE= ?");
            strSql.Append(" where ID= ?");
            OdbcParameter[] parameters = {
					
					new OdbcParameter("@ROLEPLID", OdbcType.Int),
					new OdbcParameter("@ACTIONID", OdbcType.Int),
					new OdbcParameter("@ROLESNAME", OdbcType.Int),
					new OdbcParameter("@TYPE", OdbcType.Int),
            new OdbcParameter("@ID", OdbcType.Int)};
            
            parameters[0].Value = model.ROLEPLID;
            parameters[1].Value = model.ACTIONID;
            parameters[2].Value = model.ROLESNAME;
            parameters[3].Value = model.TYPE;
            parameters[4].Value = model.ID;

            return DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
        }

        public int UpdateNotall(Mis.Model.ptgl.SYS_ROLEACTRIGHTS model)
        {
            return Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_ROLEACTRIGHTS ");
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
            strSql.Append("delete from SYS_ROLEACTRIGHTS ");
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
        public Mis.Model.ptgl.SYS_ROLEACTRIGHTS GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_ROLEACTRIGHTS ");
            strSql.Append(" where ID=?");
            OdbcParameter[] parameters = {
   				new OdbcParameter("@ID", OdbcType.Int)};
            parameters[0].Value = ID;
            Mis.Model.ptgl.SYS_ROLEACTRIGHTS model = new Mis.Model.ptgl.SYS_ROLEACTRIGHTS();
            DataSet ds = DbHelperMysqlOdbc.Query(strSql.ToString(), parameters);
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
            return DbHelperMysqlOdbc.Query(strSql.ToString());
        }
        #endregion  成员方法



        #region ISYS_ROLEACTRIGHTS 成员


        public DictionaryEntry DeleteByroleid(int p_roleid)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}

