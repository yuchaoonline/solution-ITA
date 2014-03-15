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
    /// 数据访问类SYS_ROLES
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
            return DbHelperMysqlOdbc.GetMaxID("ID", "SYS_ROLES");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_ROLES");
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
            strSql.Append("select count(1) from SYS_ROLES");
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
        public int Add(Mis.Model.ptgl.SYS_ROLES model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_ROLES(");
            strSql.Append("ID,ROLENO,USERNO,DESCRIPTION)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? )");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@ROLENO", OdbcType.VarChar,30),
					new OdbcParameter("@USERNO", OdbcType.VarChar,30),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,200)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ROLENO;
            parameters[2].Value = model.USERNO;
            parameters[3].Value = model.DESCRIPTION;

            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
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
            strSql.Append("ROLENO,USERNO,DESCRIPTION)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? )");
            OdbcParameter[] parameters = {  

					new OdbcParameter("@ROLENO", OdbcType.VarChar,30),
					new OdbcParameter("@USERNO", OdbcType.VarChar,30),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,200)
};
            parameters[0].Value = model.ROLENO;
            parameters[1].Value = model.USERNO;
            parameters[2].Value = model.DESCRIPTION;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(Mis.Model.ptgl.SYS_ROLES model)
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
            strSql.Append(" ) ");
            strSql.Append(" values (");
            strSql.Append("?");
            //列出需哟插入的表字段value对象 
            if (model.ROLENO != "")
            {
                strSql.Append(",?");
            }
            if (model.USERNO != "")
            {
                strSql.Append(",?");
            }
            if (model.DESCRIPTION != "")
            {
                strSql.Append(",?");
            }
            strSql.Append(" ) ");
            OdbcParameter[] parameters = new OdbcParameter[(Param_Num + 1)];
            parameters[0] = new OdbcParameter("@ID", OdbcType.Int);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            if (model.ROLENO != "")
            {
                parameters[index_num] = new OdbcParameter("@ROLENO", OdbcType.VarChar, 30);//角色编号
                parameters[index_num].Value = model.ROLENO;
                index_num++;
            }
            if (model.USERNO != "")
            {
                parameters[index_num] = new OdbcParameter("@USERNO", OdbcType.VarChar, 30);//角色名称
                parameters[index_num].Value = model.USERNO;
                index_num++;
            }
            if (model.DESCRIPTION != "")
            {
                parameters[index_num] = new OdbcParameter("@DESCRIPTION", OdbcType.VarChar, 200);//描述
                parameters[index_num].Value = model.DESCRIPTION;
                index_num++;
            }
            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters); return model.ID;
        }

        /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(Mis.Model.ptgl.SYS_ROLES model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_ROLES");
            strSql.Append(" where  ROLENO=? and USERNO=? and DESCRIPTION=?");
            OdbcParameter[] parameters = {  
					new OdbcParameter("@ROLENO", OdbcType.VarChar,30),
					new OdbcParameter("@USERNO", OdbcType.VarChar,30),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,200)

};
            parameters[0].Value = model.ROLENO;
            parameters[1].Value = model.USERNO;
            parameters[2].Value = model.DESCRIPTION;

            return DbHelperMysqlOdbc.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Mis.Model.ptgl.SYS_ROLES model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_ROLES set ");
            strSql.Append("ROLENO= ?,");
            strSql.Append("USERNO= ?,");
            strSql.Append("DESCRIPTION= ?");
            strSql.Append(" where ID= ?");
            OdbcParameter[] parameters = {
					
					new OdbcParameter("@ROLENO", OdbcType.VarChar,30),
					new OdbcParameter("@USERNO", OdbcType.VarChar,30),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,200),
new OdbcParameter("@ID", OdbcType.Int),};

            parameters[0].Value = model.ROLENO;
            parameters[1].Value = model.USERNO;
            parameters[2].Value = model.DESCRIPTION;
            parameters[3].Value = model.ID;

            return DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
        }

        public int UpdateNotall(Mis.Model.ptgl.SYS_ROLES model)
        {
            return Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_ROLES ");
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
            strSql.Append("delete from SYS_ROLES ");
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
        public Mis.Model.ptgl.SYS_ROLES GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_ROLES ");
            strSql.Append(" where ID=?");
            OdbcParameter[] parameters = {
   				new OdbcParameter("@ID", OdbcType.Int)};
            parameters[0].Value = ID;
            Mis.Model.ptgl.SYS_ROLES model = new Mis.Model.ptgl.SYS_ROLES();
            DataSet ds = DbHelperMysqlOdbc.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ROLENO = ds.Tables[0].Rows[0]["ROLENO"].ToString();
                model.USERNO = ds.Tables[0].Rows[0]["USERNO"].ToString();
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
            strSql.Append("select * from SYS_ROLES ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return DbHelperMysqlOdbc.Query(strSql.ToString());
        }
        #endregion  成员方法

    }
}


