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
    /// 数据访问类SYS_ROLEPLMENUSRIGHTS
    /// </summary>
    public class SYS_ROLEPLMENUSRIGHTS : ISYS_ROLEPLMENUSRIGHTS
    {
        public SYS_ROLEPLMENUSRIGHTS()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMysqlOdbc.GetMaxID("ID", "SYS_ROLEPLMENUSRIGHTS");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_ROLEPLMENUSRIGHTS");
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
            strSql.Append("select count(1) from SYS_ROLEPLMENUSRIGHTS");
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
        public int Add(Mis.Model.ptgl.SYS_ROLEPLMENUSRIGHTS model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_ROLEPLMENUSRIGHTS(");
            strSql.Append("ID,ROLEPLID,MENUID,ROLESNAME,TYPE)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? , ? )");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@ROLEPLID", OdbcType.Int),
					new OdbcParameter("@MENUID", OdbcType.Int),
					new OdbcParameter("@ROLESNAME", OdbcType.Int),
					new OdbcParameter("@TYPE", OdbcType.Int)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ROLEPLID;
            parameters[2].Value = model.MENUID;
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
        public DictionaryEntry AddSql(Mis.Model.ptgl.SYS_ROLEPLMENUSRIGHTS model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_ROLEPLMENUSRIGHTS(");
            strSql.Append("ROLEPLID,MENUID,ROLESNAME,TYPE)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? )");
            OdbcParameter[] parameters = {  
					new OdbcParameter("@ROLEPLID", OdbcType.Int),
					new OdbcParameter("@MENUID", OdbcType.Int),
					new OdbcParameter("@ROLESNAME", OdbcType.Int),
					new OdbcParameter("@TYPE", OdbcType.Int)};
            parameters[0].Value = model.ROLEPLID;
            parameters[1].Value = model.MENUID;
            parameters[2].Value = model.ROLESNAME;
            parameters[3].Value = model.TYPE;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(Mis.Model.ptgl.SYS_ROLEPLMENUSRIGHTS model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_ROLEPLMENUSRIGHTS(");
            strSql.Append("ID");
            //列出需哟插入的表字段
            int Param_Num = 0;
            //if (model.ROLEPLID != 0 )
            {
                Param_Num++;
                strSql.Append(",ROLEPLID");
            }
            //if (model.MENUID != 0 )
            {
                Param_Num++;
                strSql.Append(",MENUID");
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
                parameters[index_num] = new OdbcParameter("@ROLEPLID", OdbcType.Int);//角色用户id
                parameters[index_num].Value = model.ROLEPLID;
                index_num++;
            }
            {
                parameters[index_num] = new OdbcParameter("@MENUID", OdbcType.Int);//菜单id
                parameters[index_num].Value = model.MENUID;
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
        }


        /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(Mis.Model.ptgl.SYS_ROLEPLMENUSRIGHTS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_ROLEPLMENUSRIGHTS");
            strSql.Append(" where  ROLEPLID=? and MENUID=? and ROLESNAME=? and TYPE=?");
            OdbcParameter[] parameters = {  
					new OdbcParameter("@ROLEPLID", OdbcType.Int),
					new OdbcParameter("@MENUID", OdbcType.Int),
					new OdbcParameter("@ROLESNAME", OdbcType.Int),
					new OdbcParameter("@TYPE", OdbcType.Int)};
            parameters[0].Value = model.ROLEPLID;
            parameters[1].Value = model.MENUID;
            parameters[2].Value = model.ROLESNAME;
            parameters[3].Value = model.TYPE;

            return DbHelperMysqlOdbc.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Mis.Model.ptgl.SYS_ROLEPLMENUSRIGHTS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_ROLEPLMENUSRIGHTS set ");
            strSql.Append("ROLEPLID= ?,");
            strSql.Append("MENUID= ?,");
            strSql.Append("ROLESNAME= ?,");
            strSql.Append("TYPE= ?");
            strSql.Append(" where ID= ?");
            OdbcParameter[] parameters = {
					
					new OdbcParameter("@ROLEPLID", OdbcType.Int),
					new OdbcParameter("@MENUID", OdbcType.Int),
					new OdbcParameter("@ROLESNAME", OdbcType.Int),
					new OdbcParameter("@TYPE", OdbcType.Int),
                    new OdbcParameter("@ID", OdbcType.Int),};

            parameters[0].Value = model.ROLEPLID;
            parameters[1].Value = model.MENUID;
            parameters[2].Value = model.ROLESNAME;
            parameters[3].Value = model.TYPE;
            parameters[4].Value = model.ID;

            return DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
        }

        public int UpdateNotall(Mis.Model.ptgl.SYS_ROLEPLMENUSRIGHTS model)
        {
            return Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_ROLEPLMENUSRIGHTS ");
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
            strSql.Append("delete from SYS_ROLEPLMENUSRIGHTS ");
            strSql.Append(" where ID=?");
            OdbcParameter[] parameters = {
				new OdbcParameter("@ID", OdbcType.Int)
			};
            parameters[0].Value = ID;
            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public DictionaryEntry DeleteByroleid(int p_roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_ROLEPLMENUSRIGHTS ");
            strSql.Append(" where ROLEPLID=?");
            OdbcParameter[] parameters = {
				new OdbcParameter("@ROLEPLID", OdbcType.Int)
			};
            parameters[0].Value = p_roleid;
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
        public Mis.Model.ptgl.SYS_ROLEPLMENUSRIGHTS GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_ROLEPLMENUSRIGHTS ");
            strSql.Append(" where ID=?");
            OdbcParameter[] parameters = {
   				new OdbcParameter("@ID", OdbcType.Int)};
            parameters[0].Value = ID;
            Mis.Model.ptgl.SYS_ROLEPLMENUSRIGHTS model = new Mis.Model.ptgl.SYS_ROLEPLMENUSRIGHTS();
            DataSet ds = DbHelperMysqlOdbc.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ROLEPLID"].ToString() != "")
                {
                    model.ROLEPLID = int.Parse(ds.Tables[0].Rows[0]["ROLEPLID"].ToString().Trim());
                }
                if (ds.Tables[0].Rows[0]["MENUID"].ToString() != "")
                {
                    model.MENUID = int.Parse(ds.Tables[0].Rows[0]["MENUID"].ToString().Trim());
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
            strSql.Append("select * from SYS_ROLEPLMENUSRIGHTS ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return DbHelperMysqlOdbc.Query(strSql.ToString());
        }
        #endregion  成员方法

        #region ISYS_ROLEPLMENUSRIGHTS 成员

        public void RunTrans(ArrayList SQLStringList)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public DictionaryEntry addrolecation(Mis.Model.ptgl.SYS_ROLEPLMENUSRIGHTS obj)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public DictionaryEntry deleteuseraction(int userid)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public DictionaryEntry deleteroleaction(int roleid)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}


