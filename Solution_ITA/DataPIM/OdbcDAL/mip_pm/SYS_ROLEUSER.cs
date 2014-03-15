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
    /// 数据访问类SYS_ROLEUSER
    /// </summary>
    public class SYS_ROLEUSER : ISYS_ROLEUSER
    {
        public SYS_ROLEUSER()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMysqlOdbc.GetMaxID("ID", "SYS_ROLEUSER");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_ROLEUSER");
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
            strSql.Append("select count(1) from SYS_ROLEUSER");
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
        public int Add(Mis.Model.ptgl.SYS_ROLEUSER model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_ROLEUSER(");
            strSql.Append("ID,ROLEID,USERID,DESCRIPTION)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? )");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@ROLEID", OdbcType.Int),
					new OdbcParameter("@USERID", OdbcType.Int),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,200)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ROLEID;
            parameters[2].Value = model.USERID;
            parameters[3].Value = model.DESCRIPTION;

            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
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
            strSql.Append("ROLEID,USERID,DESCRIPTION)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? )");
            OdbcParameter[] parameters = {  
					new OdbcParameter("@ROLEID", OdbcType.Int),
					new OdbcParameter("@USERID", OdbcType.Int),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,200)
};
            parameters[0].Value = model.ROLEID;
            parameters[1].Value = model.USERID;
            parameters[2].Value = model.DESCRIPTION;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int UpdateNotall(Mis.Model.ptgl.SYS_ROLEUSER model)
        {
            return Update(model);
        }

        public int AddNotall(Mis.Model.ptgl.SYS_ROLEUSER model)
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
            strSql.Append("?");
            //列出需哟插入的表字段value对象 
            strSql.Append(",?");
            strSql.Append(",?");
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
            {
                parameters[index_num] = new OdbcParameter("@ROLEID", OdbcType.Int);//角色id
                parameters[index_num].Value = model.ROLEID;
                index_num++;
            }
            {
                parameters[index_num] = new OdbcParameter("@USERID", OdbcType.Int);//用户id
                parameters[index_num].Value = model.USERID;
                index_num++;
            }
            if (model.DESCRIPTION != "")
            {
                parameters[index_num] = new OdbcParameter("@DESCRIPTION", OdbcType.VarChar, 200);//描述
                parameters[index_num].Value = model.DESCRIPTION;
                index_num++;
            }
            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters); return model.ID;
        } /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(Mis.Model.ptgl.SYS_ROLEUSER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_ROLEUSER");
            strSql.Append(" where  ROLEID=? and USERID=? and DESCRIPTION=?");
            OdbcParameter[] parameters = {  
					new OdbcParameter("@ROLEID", OdbcType.Int),
					new OdbcParameter("@USERID", OdbcType.Int),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,200)
};
            parameters[0].Value = model.ROLEID;
            parameters[1].Value = model.USERID;
            parameters[2].Value = model.DESCRIPTION;

            return DbHelperMysqlOdbc.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Mis.Model.ptgl.SYS_ROLEUSER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_ROLEUSER set ");
            strSql.Append("ROLEID= ?,");
            strSql.Append("USERID= ?,");
            strSql.Append("DESCRIPTION= ?");
            strSql.Append(" where ID= ?");
            OdbcParameter[] parameters = {
					
					new OdbcParameter("@ROLEID", OdbcType.Int),
					new OdbcParameter("@USERID", OdbcType.Int),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,200),
            new OdbcParameter("@ID", OdbcType.Int)};
            
            parameters[0].Value = model.ROLEID;
            parameters[1].Value = model.USERID;
            parameters[2].Value = model.DESCRIPTION;
            parameters[3].Value = model.ID;

            return DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_ROLEUSER ");
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
            strSql.Append("delete from SYS_ROLEUSER ");
            strSql.Append(" where ID=?");
            OdbcParameter[] parameters = {
				new OdbcParameter("@ID", OdbcType.Int)
			};
            parameters[0].Value = ID;
            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public DictionaryEntry DeleteUserRole(int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_ROLEUSER ");
            strSql.Append(" where USERID=?");
            OdbcParameter[] parameters = {
				new OdbcParameter("@USERID", OdbcType.Int)
			};
            parameters[0].Value = userid;
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
            return DbHelperMysqlOdbc.ExecuteSqlTranByArray2(SQLStringList);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mis.Model.ptgl.SYS_ROLEUSER GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_ROLEUSER ");
            strSql.Append(" where ID=?");
            OdbcParameter[] parameters = {
   				new OdbcParameter("@ID", OdbcType.Int)};
            parameters[0].Value = ID;
            Mis.Model.ptgl.SYS_ROLEUSER model = new Mis.Model.ptgl.SYS_ROLEUSER();
            DataSet ds = DbHelperMysqlOdbc.Query(strSql.ToString(), parameters);
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
            return DbHelperMysqlOdbc.Query(strSql.ToString());
        }
        #endregion  成员方法

        #region ISYS_ROLEUSER 成员



        public void RunTrans(ArrayList SQLStringList)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public DictionaryEntry Adduser(Mis.Model.ptgl.SYS_ROLEUSER obj)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public DictionaryEntry deleterole(int roleid)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public DataSet GetRoleList(string strWhere)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}


