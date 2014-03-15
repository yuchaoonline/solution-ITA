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
    /// 数据访问类SYS_USERS
    /// </summary>
    public class SYS_USERS : ISYS_USERS
    {
        public SYS_USERS()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMysqlOdbc.GetMaxID("ID", "SYS_USERS");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_USERS");
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
            strSql.Append("select count(1) from SYS_USERS");
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
        public int Add(Mis.Model.ptgl.SYS_USERS model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_USERS(");
            strSql.Append("ID,DEPTID,USERNO,USERREALNAME,USERNAME,PASSWORD,SEX,AGE)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? , ? , ? , ? , ? )");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@DEPTID", OdbcType.VarChar,30),
					new OdbcParameter("@USERNO", OdbcType.VarChar,30),
					new OdbcParameter("@USERREALNAME", OdbcType.VarChar,30),
					new OdbcParameter("@USERNAME", OdbcType.VarChar,30),
					new OdbcParameter("@PASSWORD", OdbcType.VarChar,50),
					new OdbcParameter("@SEX", OdbcType.Int),
					new OdbcParameter("@AGE", OdbcType.Int)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.DEPTID;
            parameters[2].Value = model.USERNO;
            parameters[3].Value = model.USERREALNAME;
            parameters[4].Value = model.USERNAME;
            parameters[5].Value = model.PASSWORD;
            parameters[6].Value = model.SEX;
            parameters[7].Value = model.AGE;

            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }

        /// <summary>
        /// 事务处理增加一个model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public DictionaryEntry AddSql(Mis.Model.ptgl.SYS_USERS model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_USERS(");
            strSql.Append("DEPTID,USERNO,USERREALNAME,USERNAME,PASSWORD,SEX,AGE)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? , ? , ? , ? )");
            OdbcParameter[] parameters = {  

					new OdbcParameter("@DEPTID", OdbcType.VarChar,30),
					new OdbcParameter("@USERNO", OdbcType.VarChar,30),
					new OdbcParameter("@USERREALNAME", OdbcType.VarChar,30),
					new OdbcParameter("@USERNAME", OdbcType.VarChar,30),
					new OdbcParameter("@PASSWORD", OdbcType.VarChar,50),
					new OdbcParameter("@SEX", OdbcType.Int),
					new OdbcParameter("@AGE", OdbcType.Int)};
            parameters[0].Value = model.DEPTID;
            parameters[1].Value = model.USERNO;
            parameters[2].Value = model.USERREALNAME;
            parameters[3].Value = model.USERNAME;
            parameters[4].Value = model.PASSWORD;
            parameters[5].Value = model.SEX;
            parameters[6].Value = model.AGE;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(Mis.Model.ptgl.SYS_USERS model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_USERS(");
            strSql.Append("ID");
            //列出需哟插入的表字段
            int Param_Num = 0;
            if (model.DEPTID != "")
            {
                Param_Num++;
                strSql.Append(",DEPTID");
            }
            if (model.USERNO != "")
            {
                Param_Num++;
                strSql.Append(",USERNO");
            }
            if (model.USERREALNAME != "")
            {
                Param_Num++;
                strSql.Append(",USERREALNAME");
            }
            if (model.USERNAME != "")
            {
                Param_Num++;
                strSql.Append(",USERNAME");
            }
            if (model.PASSWORD != "")
            {
                Param_Num++;
                strSql.Append(",PASSWORD");
            }
            //if (model.SEX != 0 )
            {
                Param_Num++;
                strSql.Append(",SEX");
            }
            //if (model.AGE != 0 )
            {
                Param_Num++;
                strSql.Append(",AGE");
            }
            strSql.Append(" ) ");
            strSql.Append(" values (");
            strSql.Append("?");
            //列出需哟插入的表字段value对象 
            if (model.DEPTID != "")
            {
                strSql.Append(",?");
            }
            if (model.USERNO != "")
            {
                strSql.Append(",?");
            }
            if (model.USERREALNAME != "")
            {
                strSql.Append(",?");
            }
            if (model.USERNAME != "")
            {
                strSql.Append(",?");
            }
            if (model.PASSWORD != "")
            {
                strSql.Append(",?");
            }
            strSql.Append(",?");
            strSql.Append(",?");
            strSql.Append(" ) ");
            OdbcParameter[] parameters = new OdbcParameter[(Param_Num + 1)];
            parameters[0] = new OdbcParameter("@ID", OdbcType.Int);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            if (model.DEPTID != "")
            {
                parameters[index_num] = new OdbcParameter("@DEPTID", OdbcType.VarChar, 30);//部门id
                parameters[index_num].Value = model.DEPTID;
                index_num++;
            }
            if (model.USERNO != "")
            {
                parameters[index_num] = new OdbcParameter("@USERNO", OdbcType.VarChar, 30);//人员工号
                parameters[index_num].Value = model.USERNO;
                index_num++;
            }
            if (model.USERREALNAME != "")
            {
                parameters[index_num] = new OdbcParameter("@USERREALNAME", OdbcType.VarChar, 30);//人员真实名称
                parameters[index_num].Value = model.USERREALNAME;
                index_num++;
            }
            if (model.USERNAME != "")
            {
                parameters[index_num] = new OdbcParameter("@USERNAME", OdbcType.VarChar, 30);//用户名
                parameters[index_num].Value = model.USERNAME;
                index_num++;
            }
            if (model.PASSWORD != "")
            {
                parameters[index_num] = new OdbcParameter("@PASSWORD", OdbcType.VarChar, 50);//人员密码
                parameters[index_num].Value = model.PASSWORD;
                index_num++;
            }
            {
                parameters[index_num] = new OdbcParameter("@SEX", OdbcType.Int);//性别
                parameters[index_num].Value = model.SEX;
                index_num++;
            }
            {
                parameters[index_num] = new OdbcParameter("@AGE", OdbcType.Int);//年龄
                parameters[index_num].Value = model.AGE;
                index_num++;
            }
            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters); return model.ID;
        } /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(Mis.Model.ptgl.SYS_USERS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_USERS");
            strSql.Append(" where  DEPTID=? and USERNO=? and USERREALNAME=? and USERNAME=? and PASSWORD=? and SEX=? and AGE=?");
            OdbcParameter[] parameters = {  
					new OdbcParameter("@DEPTID", OdbcType.VarChar,30),
					new OdbcParameter("@USERNO", OdbcType.VarChar,30),
					new OdbcParameter("@USERREALNAME", OdbcType.VarChar,30),
					new OdbcParameter("@USERNAME", OdbcType.VarChar,30),
					new OdbcParameter("@PASSWORD", OdbcType.VarChar,50),
					new OdbcParameter("@SEX", OdbcType.Int),
					new OdbcParameter("@AGE", OdbcType.Int)};
            parameters[0].Value = model.DEPTID;
            parameters[1].Value = model.USERNO;
            parameters[2].Value = model.USERREALNAME;
            parameters[3].Value = model.USERNAME;
            parameters[4].Value = model.PASSWORD;
            parameters[5].Value = model.SEX;
            parameters[6].Value = model.AGE;

            return DbHelperMysqlOdbc.Exists(strSql.ToString(), parameters);
        }

        
       public int UpdateNotall(Mis.Model.ptgl.SYS_USERS model)
       {
            return Update(model);
       }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Mis.Model.ptgl.SYS_USERS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_USERS set ");
            strSql.Append("DEPTID= ?,");
            strSql.Append("USERNO= ?,");
            strSql.Append("USERREALNAME= ?,");
            strSql.Append("USERNAME= ?,");
            strSql.Append("PASSWORD= ?,");
            strSql.Append("SEX= ?,");
            strSql.Append("AGE= ?");
            strSql.Append(" where ID= ?");
            OdbcParameter[] parameters = {
					
					new OdbcParameter("@DEPTID", OdbcType.VarChar,30),
					new OdbcParameter("@USERNO", OdbcType.VarChar,30),
					new OdbcParameter("@USERREALNAME", OdbcType.VarChar,30),
					new OdbcParameter("@USERNAME", OdbcType.VarChar,30),
					new OdbcParameter("@PASSWORD", OdbcType.VarChar,50),
					new OdbcParameter("@SEX", OdbcType.Int),
					new OdbcParameter("@AGE", OdbcType.Int),
new OdbcParameter("@ID", OdbcType.Int)};

            parameters[0].Value = model.DEPTID;
            parameters[1].Value = model.USERNO;
            parameters[2].Value = model.USERREALNAME;
            parameters[3].Value = model.USERNAME;
            parameters[4].Value = model.PASSWORD;
            parameters[5].Value = model.SEX;
            parameters[6].Value = model.AGE;
            parameters[7].Value = model.ID;

            return DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_USERS ");
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
            strSql.Append("delete from SYS_USERS ");
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
        public Mis.Model.ptgl.SYS_USERS GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_USERS ");
            strSql.Append(" where ID=?");
            OdbcParameter[] parameters = {
   				new OdbcParameter("@ID", OdbcType.Int)};
            parameters[0].Value = ID;
            Mis.Model.ptgl.SYS_USERS model = new Mis.Model.ptgl.SYS_USERS();
            DataSet ds = DbHelperMysqlOdbc.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.DEPTID = ds.Tables[0].Rows[0]["DEPTID"].ToString();
                model.USERNO = ds.Tables[0].Rows[0]["USERNO"].ToString();
                model.USERREALNAME = ds.Tables[0].Rows[0]["USERREALNAME"].ToString();
                model.USERNAME = ds.Tables[0].Rows[0]["USERNAME"].ToString();
                model.PASSWORD = ds.Tables[0].Rows[0]["PASSWORD"].ToString();
                if (ds.Tables[0].Rows[0]["SEX"].ToString() != "")
                {
                    model.SEX = int.Parse(ds.Tables[0].Rows[0]["SEX"].ToString().Trim());
                }
                if (ds.Tables[0].Rows[0]["AGE"].ToString() != "")
                {
                    model.AGE = int.Parse(ds.Tables[0].Rows[0]["AGE"].ToString().Trim());
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
            strSql.Append("select * from SYS_USERS ");
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


