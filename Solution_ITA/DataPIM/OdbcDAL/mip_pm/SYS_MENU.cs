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
    /// 数据访问类SYS_MENU
    /// </summary>
    public class SYS_MENU : ISYS_MENU
    {
        public SYS_MENU()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMysqlOdbc.GetMaxID("ID", "SYS_MENU");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_MENU");
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
            strSql.Append("select count(1) from SYS_MENU");
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
        public int Add(Djdw.Model.Post.SYS_MENU model)
        {
            model.ID =  GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_MENU(");
            strSql.Append("ID,SYSNAME,MOUDLENAME,SYSLEVEL,PARENT,URL,DESCRIPTION,IMG,VERSION)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? , ? , ? , ? , ? , ? )");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@SYSNAME", OdbcType.VarChar,30),
					new OdbcParameter("@MOUDLENAME", OdbcType.VarChar,30),
					new OdbcParameter("@SYSLEVEL", OdbcType.Int),
					new OdbcParameter("@PARENT", OdbcType.VarChar,30),
					new OdbcParameter("@URL", OdbcType.VarChar,256),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,256),
					new OdbcParameter("@IMG", OdbcType.VarChar,256),
					new OdbcParameter("@VERSION", OdbcType.Int)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SYSNAME;
            parameters[2].Value = model.MOUDLENAME;
            parameters[3].Value = model.SYSLEVEL;
            parameters[4].Value = model.PARENT;
            parameters[5].Value = model.URL;
            parameters[6].Value = model.DESCRIPTION;
            parameters[7].Value = model.IMG;
            parameters[8].Value = model.VERSION;

            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }



        /// <summary>
        /// 事务处理增加一个model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public DictionaryEntry AddSql(Djdw.Model.Post.SYS_MENU model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_MENU(");
            strSql.Append("SYSNAME,MOUDLENAME,SYSLEVEL,PARENT,URL,DESCRIPTION,IMG,VERSION)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? , ? , ? , ? , ? )");
            OdbcParameter[] parameters = {  
					new OdbcParameter("@SYSNAME", OdbcType.VarChar,30),
					new OdbcParameter("@MOUDLENAME", OdbcType.VarChar,30),
					new OdbcParameter("@SYSLEVEL", OdbcType.Int),
					new OdbcParameter("@PARENT", OdbcType.VarChar,30),
					new OdbcParameter("@URL", OdbcType.VarChar,256),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,256),
					new OdbcParameter("@IMG", OdbcType.VarChar,256),
					new OdbcParameter("@VERSION", OdbcType.Int)};
            parameters[0].Value = model.SYSNAME;
            parameters[1].Value = model.MOUDLENAME;
            parameters[2].Value = model.SYSLEVEL;
            parameters[3].Value = model.PARENT;
            parameters[4].Value = model.URL;
            parameters[5].Value = model.DESCRIPTION;
            parameters[6].Value = model.IMG;
            parameters[7].Value = model.VERSION;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(Djdw.Model.Post.SYS_MENU model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_MENU(");
            strSql.Append("ID");
            //列出需哟插入的表字段
            int Param_Num = 0;
            if (model.SYSNAME != "")
            {
                Param_Num++;
                strSql.Append(",SYSNAME");
            }
            if (model.MOUDLENAME != "")
            {
                Param_Num++;
                strSql.Append(",MOUDLENAME");
            }
            //if (model.SYSLEVEL != 0 )
            {
                Param_Num++;
                strSql.Append(",SYSLEVEL");
            }
            if (model.PARENT != "")
            {
                Param_Num++;
                strSql.Append(",PARENT");
            }
            if (model.URL != "")
            {
                Param_Num++;
                strSql.Append(",URL");
            }
            if (model.DESCRIPTION != "")
            {
                Param_Num++;
                strSql.Append(",DESCRIPTION");
            }
            if (model.IMG != "")
            {
                Param_Num++;
                strSql.Append(",IMG");
            }
            //if (model.VERSION != 0 )
            {
                Param_Num++;
                strSql.Append(",VERSION");
            }
            strSql.Append(" ) ");
            strSql.Append(" values (");
            strSql.Append("?");
            //列出需哟插入的表字段value对象 
            if (model.SYSNAME != "")
            {
                strSql.Append(",?");
            }
            if (model.MOUDLENAME != "")
            {
                strSql.Append(",?");
            }
            strSql.Append(",?");
            if (model.PARENT != "")
            {
                strSql.Append(",?");
            }
            if (model.URL != "")
            {
                strSql.Append(",?");
            }
            if (model.DESCRIPTION != "")
            {
                strSql.Append(",?");
            }
            if (model.IMG != "")
            {
                strSql.Append(",?");
            }
            strSql.Append(",?");
            strSql.Append(" ) ");
            OdbcParameter[] parameters = new OdbcParameter[(Param_Num + 1)];
            parameters[0] = new OdbcParameter("@ID", OdbcType.Int);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            if (model.SYSNAME != "")
            {
                parameters[index_num] = new OdbcParameter("@SYSNAME", OdbcType.VarChar, 30);//系统名称
                parameters[index_num].Value = model.SYSNAME;
                index_num++;
            }
            if (model.MOUDLENAME != "")
            {
                parameters[index_num] = new OdbcParameter("@MOUDLENAME", OdbcType.VarChar, 30);//模块名称
                parameters[index_num].Value = model.MOUDLENAME;
                index_num++;
            }
            {
                parameters[index_num] = new OdbcParameter("@SYSLEVEL", OdbcType.Int);//级别
                parameters[index_num].Value = model.SYSLEVEL;
                index_num++;
            }
            if (model.PARENT != "")
            {
                parameters[index_num] = new OdbcParameter("@PARENT", OdbcType.VarChar, 30);//上一级别模块
                parameters[index_num].Value = model.PARENT;
                index_num++;
            }
            if (model.URL != "")
            {
                parameters[index_num] = new OdbcParameter("@URL", OdbcType.VarChar, 256);//url
                parameters[index_num].Value = model.URL;
                index_num++;
            }
            if (model.DESCRIPTION != "")
            {
                parameters[index_num] = new OdbcParameter("@DESCRIPTION", OdbcType.VarChar, 256);//描述
                parameters[index_num].Value = model.DESCRIPTION;
                index_num++;
            }
            if (model.IMG != "")
            {
                parameters[index_num] = new OdbcParameter("@IMG", OdbcType.VarChar, 256);//模块对应的图片url
                parameters[index_num].Value = model.IMG;
                index_num++;
            }
            {
                parameters[index_num] = new OdbcParameter("@VERSION", OdbcType.Int);//颁本
                parameters[index_num].Value = model.VERSION;
                index_num++;
            }
            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters); 
            return model.ID;
        } /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(Djdw.Model.Post.SYS_MENU model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_MENU");
            strSql.Append(" where  SYSNAME=? and MOUDLENAME=? and SYSLEVEL=? and PARENT=? and URL=? and DESCRIPTION=? and IMG=? and VERSION=?");
            OdbcParameter[] parameters = {  
					new OdbcParameter("@SYSNAME", OdbcType.VarChar,30),
					new OdbcParameter("@MOUDLENAME", OdbcType.VarChar,30),
					new OdbcParameter("@SYSLEVEL", OdbcType.Int),
					new OdbcParameter("@PARENT", OdbcType.VarChar,30),
					new OdbcParameter("@URL", OdbcType.VarChar,256),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,256),
					new OdbcParameter("@IMG", OdbcType.VarChar,256),
					new OdbcParameter("@VERSION", OdbcType.Int)};
            parameters[0].Value = model.SYSNAME;
            parameters[1].Value = model.MOUDLENAME;
            parameters[2].Value = model.SYSLEVEL;
            parameters[3].Value = model.PARENT;
            parameters[4].Value = model.URL;
            parameters[5].Value = model.DESCRIPTION;
            parameters[6].Value = model.IMG;
            parameters[7].Value = model.VERSION;

            return DbHelperMysqlOdbc.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Djdw.Model.Post.SYS_MENU model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_MENU set ");
            strSql.Append("SYSNAME= ?,");
            strSql.Append("MOUDLENAME= ?,");
            strSql.Append("SYSLEVEL= ?,");
            strSql.Append("PARENT= ?,");
            strSql.Append("URL= ?,");
            strSql.Append("DESCRIPTION= ?,");
            strSql.Append("IMG= ?,");
            strSql.Append("VERSION= ?");
            strSql.Append(" where ID= ?");
            OdbcParameter[] parameters = {
					
					new OdbcParameter("@SYSNAME", OdbcType.VarChar,30),
					new OdbcParameter("@MOUDLENAME", OdbcType.VarChar,30),
					new OdbcParameter("@SYSLEVEL", OdbcType.Int),
					new OdbcParameter("@PARENT", OdbcType.VarChar,30),
					new OdbcParameter("@URL", OdbcType.VarChar,256),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,256),
					new OdbcParameter("@IMG", OdbcType.VarChar,256),
					new OdbcParameter("@VERSION", OdbcType.Int),
                    new OdbcParameter("@ID", OdbcType.Int)};
            
            parameters[0].Value = model.SYSNAME;
            parameters[1].Value = model.MOUDLENAME;
            parameters[2].Value = model.SYSLEVEL;
            parameters[3].Value = model.PARENT;
            parameters[4].Value = model.URL;
            parameters[5].Value = model.DESCRIPTION;
            parameters[6].Value = model.IMG;
            parameters[7].Value = model.VERSION;
            parameters[8].Value = model.ID;

            return DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
        }

        public int UpdateNotall(Djdw.Model.Post.SYS_MENU model)
        {
            return -1;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_MENU ");
            strSql.Append(" where ID=?");
            OdbcParameter[] parameters = {
				new OdbcParameter("@ID", OdbcType.Int)
			};
            parameters[0].Value = ID;
            return DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
        }

        public DictionaryEntry GetDeltSqls(string ID)
        {
            return DeleteSql(int.Parse(ID));
        }

        /// <summary>
        /// 事务处理删除 (int ID)
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DictionaryEntry DeleteSql(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SYS_MENU ");
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

        public void RunTrans(Hashtable SQLStringList)
        {
            DbHelperMysqlOdbc.ExecuteSqlTran(SQLStringList);
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
        public Djdw.Model.Post.SYS_MENU GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_MENU ");
            strSql.Append(" where ID=?");
            OdbcParameter[] parameters = {
   				new OdbcParameter("@ID", OdbcType.Int)};
            parameters[0].Value = ID;
            Djdw.Model.Post.SYS_MENU model = new Djdw.Model.Post.SYS_MENU();
            DataSet ds = DbHelperMysqlOdbc.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.SYSNAME = ds.Tables[0].Rows[0]["SYSNAME"].ToString();
                model.MOUDLENAME = ds.Tables[0].Rows[0]["MOUDLENAME"].ToString();
                if (ds.Tables[0].Rows[0]["SYSLEVEL"].ToString() != "")
                {
                    model.SYSLEVEL = int.Parse(ds.Tables[0].Rows[0]["SYSLEVEL"].ToString().Trim());
                }
                model.PARENT = ds.Tables[0].Rows[0]["PARENT"].ToString();
                model.URL = ds.Tables[0].Rows[0]["URL"].ToString();
                model.DESCRIPTION = ds.Tables[0].Rows[0]["DESCRIPTION"].ToString();
                model.IMG = ds.Tables[0].Rows[0]["IMG"].ToString();
                if (ds.Tables[0].Rows[0]["VERSION"].ToString() != "")
                {
                    model.VERSION = int.Parse(ds.Tables[0].Rows[0]["VERSION"].ToString().Trim());
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
            strSql.Append("select * from SYS_MENU ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return DbHelperMysqlOdbc.Query(strSql.ToString());
        }
       

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_MENU ");
            strSql.Append(" where ID=?");
            OdbcParameter[] parameters = {
   				new OdbcParameter("@ID", OdbcType.Int)};
            parameters[0].Value = ID;
            return DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
        }

        #endregion  成员方法

    }
}


