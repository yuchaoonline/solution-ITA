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
    /// 数据访问类SYS_DEPARTMENT
    /// </summary>
    public class SYS_DEPARTMENT : ISYS_DEPARTMENT
    {
        public SYS_DEPARTMENT()
        { }

        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMysqlOdbc.GetMaxID("ID", "SYS_DEPARTMENT");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_DEPARTMENT");
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
            strSql.Append("select count(1) from SYS_DEPARTMENT");
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
        public int Add(Mis.Model.ptgl.SYS_DEPARTMENT model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_DEPARTMENT(");
            strSql.Append("ID,DEPTNO,DEPTNAME,SYSLEVEL,PARENTID,DESCRIPTION)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? , ? , ? )");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@DEPTNO", OdbcType.VarChar,30),
					new OdbcParameter("@DEPTNAME", OdbcType.VarChar,30),
					new OdbcParameter("@SYSLEVEL", OdbcType.VarChar,30),
					new OdbcParameter("@PARENTID", OdbcType.Int),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,200)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.DEPTNO;
            parameters[2].Value = model.DEPTNAME;
            parameters[3].Value = model.SYSLEVEL;
            parameters[4].Value = model.PARENTID;
            parameters[5].Value = model.DESCRIPTION;

            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }

        /// <summary>
        /// 事务处理增加一个model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public DictionaryEntry AddSql(Mis.Model.ptgl.SYS_DEPARTMENT model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_DEPARTMENT(");
            strSql.Append("DEPTNO,DEPTNAME,SYSLEVEL,PARENTID,DESCRIPTION)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? , ? )");
            OdbcParameter[] parameters = {  
					new OdbcParameter("@DEPTNO", OdbcType.VarChar,30),
					new OdbcParameter("@DEPTNAME", OdbcType.VarChar,30),
					new OdbcParameter("@SYSLEVEL", OdbcType.VarChar,30),
					new OdbcParameter("@PARENTID", OdbcType.Int),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,200)};
            parameters[0].Value = model.DEPTNO;
            parameters[1].Value = model.DEPTNAME;
            parameters[2].Value = model.SYSLEVEL;
            parameters[3].Value = model.PARENTID;
            parameters[4].Value = model.DESCRIPTION;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(Mis.Model.ptgl.SYS_DEPARTMENT model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_DEPARTMENT(");
            strSql.Append("ID");
            //列出需哟插入的表字段
            int Param_Num = 0;
            if (model.DEPTNO != "")
            {
                Param_Num++;
                strSql.Append(",DEPTNO");
            }
            if (model.DEPTNAME != "")
            {
                Param_Num++;
                strSql.Append(",DEPTNAME");
            }
            if (model.SYSLEVEL != "")
            {
                Param_Num++;
                strSql.Append(",SYSLEVEL");
            }
            //if (model.PARENTID != 0 )
            {
                Param_Num++;
                strSql.Append(",PARENTID");
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
            if (model.DEPTNO != "")
            {
                strSql.Append(",?");
            }
            if (model.DEPTNAME != "")
            {
                strSql.Append(",?");
            }
            if (model.SYSLEVEL != "")
            {
                strSql.Append(",?");
            }
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
            if (model.DEPTNO != "")
            {
                parameters[index_num] = new OdbcParameter("@DEPTNO", OdbcType.VarChar, 30);//部门编号
                parameters[index_num].Value = model.DEPTNO;
                index_num++;
            }
            if (model.DEPTNAME != "")
            {
                parameters[index_num] = new OdbcParameter("@DEPTNAME", OdbcType.VarChar, 30);//部门名称
                parameters[index_num].Value = model.DEPTNAME;
                index_num++;
            }
            if (model.SYSLEVEL != "")
            {
                parameters[index_num] = new OdbcParameter("@SYSLEVEL", OdbcType.VarChar, 30);//级别
                parameters[index_num].Value = model.SYSLEVEL;
                index_num++;
            }
            {
                parameters[index_num] = new OdbcParameter("@PARENTID", OdbcType.Int);//上一个级别部门id
                parameters[index_num].Value = model.PARENTID;
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
        public bool Existsmodel(Mis.Model.ptgl.SYS_DEPARTMENT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_DEPARTMENT");
            strSql.Append(" where  DEPTNO=? and DEPTNAME=? and SYSLEVEL=? and PARENTID=? and DESCRIPTION=?");
            OdbcParameter[] parameters = {  
					new OdbcParameter("@DEPTNO", OdbcType.VarChar,30),
					new OdbcParameter("@DEPTNAME", OdbcType.VarChar,30),
					new OdbcParameter("@SYSLEVEL", OdbcType.VarChar,30),
					new OdbcParameter("@PARENTID", OdbcType.Int),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,200)};
            parameters[0].Value = model.DEPTNO;
            parameters[1].Value = model.DEPTNAME;
            parameters[2].Value = model.SYSLEVEL;
            parameters[3].Value = model.PARENTID;
            parameters[4].Value = model.DESCRIPTION;

            return DbHelperMysqlOdbc.Exists(strSql.ToString(), parameters);
        }

        public int UpdateNotall(Mis.Model.ptgl.SYS_DEPARTMENT model)
        {
            return Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Mis.Model.ptgl.SYS_DEPARTMENT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_DEPARTMENT set ");
            strSql.Append("DEPTNO= ?,");
            strSql.Append("DEPTNAME= ?,");
            strSql.Append("SYSLEVEL= ?,");
            strSql.Append("PARENTID= ?,");
            strSql.Append("DESCRIPTION= ?");
            strSql.Append(" where ID= ?");
            OdbcParameter[] parameters = {
					new OdbcParameter("@DEPTNO", OdbcType.VarChar,30),
					new OdbcParameter("@DEPTNAME", OdbcType.VarChar,30),
					new OdbcParameter("@SYSLEVEL", OdbcType.VarChar,30),
					new OdbcParameter("@PARENTID", OdbcType.Int),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,200),
                    new OdbcParameter("@ID", OdbcType.Int)};

            parameters[0].Value = model.DEPTNO;
            parameters[1].Value = model.DEPTNAME;
            parameters[2].Value = model.SYSLEVEL;
            parameters[3].Value = model.PARENTID;
            parameters[4].Value = model.DESCRIPTION;
            parameters[5].Value = model.ID;

            return DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_DEPARTMENT ");
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
            strSql.Append("delete from SYS_DEPARTMENT ");
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
        public Mis.Model.ptgl.SYS_DEPARTMENT GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_DEPARTMENT ");
            strSql.Append(" where ID=?");
            OdbcParameter[] parameters = {
   				new OdbcParameter("@ID", OdbcType.Int)};
            parameters[0].Value = ID;
            Mis.Model.ptgl.SYS_DEPARTMENT model = new Mis.Model.ptgl.SYS_DEPARTMENT();
            DataSet ds = DbHelperMysqlOdbc.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.DEPTNO = ds.Tables[0].Rows[0]["DEPTNO"].ToString();
                model.DEPTNAME = ds.Tables[0].Rows[0]["DEPTNAME"].ToString();
                model.SYSLEVEL = ds.Tables[0].Rows[0]["SYSLEVEL"].ToString();
                if (ds.Tables[0].Rows[0]["PARENTID"].ToString() != "")
                {
                    model.PARENTID = int.Parse(ds.Tables[0].Rows[0]["PARENTID"].ToString().Trim());
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
            strSql.Append("select * from SYS_DEPARTMENT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return DbHelperMysqlOdbc.Query(strSql.ToString());
        }
        #endregion  成员方法

        #region ISYS_DEPARTMENT 成员


        public bool Isparent(int ID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

 
        public void RunTrans(Hashtable SQLStringList)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public DictionaryEntry GetDeltSqls(string ID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}


