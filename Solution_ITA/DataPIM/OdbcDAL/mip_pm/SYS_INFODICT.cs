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
    /// 数据访问类SYS_INFODICT
    /// </summary>
    public class SYS_INFODICT : ISYS_INFODICT
    {
        public SYS_INFODICT()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMysqlOdbc.GetMaxID("ID", "SYS_INFODICT");
        }

        public int GetMaxInfono()
        {
            return GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_INFODICT");
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
            strSql.Append("select count(1) from SYS_INFODICT");
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
        public int Add(Djdw.Model.Post.SYS_INFODICT model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_INFODICT(");
            strSql.Append("ID,INFONO,INFONAME,PARENTID,DESCRIPTION,ACTIONPEOPLE,INFOLEVEL)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? , ? , ? , ? )");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@INFONO", OdbcType.VarChar,10),
					new OdbcParameter("@INFONAME", OdbcType.VarChar,50),
					new OdbcParameter("@PARENTID", OdbcType.Int),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,256),
					new OdbcParameter("@ACTIONPEOPLE", OdbcType.VarChar,50),
					new OdbcParameter("@INFOLEVEL", OdbcType.Int)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.INFONO;
            parameters[2].Value = model.INFONAME;
            parameters[3].Value = model.PARENTID;
            parameters[4].Value = model.DESCRIPTION;
            parameters[5].Value = model.ACTIONPEOPLE;
            parameters[6].Value = model.INFOLEVEL;

            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }

        public int UpdateNotall(Djdw.Model.Post.SYS_INFODICT model)
        {
            return -1;
        }

        

        /// <summary>
        /// 事务处理增加一个model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public DictionaryEntry AddSql(Djdw.Model.Post.SYS_INFODICT model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_INFODICT(");
            strSql.Append("INFONO,INFONAME,PARENTID,DESCRIPTION,ACTIONPEOPLE,INFOLEVEL)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? , ? , ? )");
            OdbcParameter[] parameters = {  
					new OdbcParameter("@INFONO", OdbcType.VarChar,10),
					new OdbcParameter("@INFONAME", OdbcType.VarChar,50),
					new OdbcParameter("@PARENTID", OdbcType.Int),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,256),
					new OdbcParameter("@ACTIONPEOPLE", OdbcType.VarChar,50),
					new OdbcParameter("@INFOLEVEL", OdbcType.Int)};
            parameters[0].Value = model.INFONO;
            parameters[1].Value = model.INFONAME;
            parameters[2].Value = model.PARENTID;
            parameters[3].Value = model.DESCRIPTION;
            parameters[4].Value = model.ACTIONPEOPLE;
            parameters[5].Value = model.INFOLEVEL;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(Djdw.Model.Post.SYS_INFODICT model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_INFODICT(");
            strSql.Append("ID");
            //列出需哟插入的表字段
            int Param_Num = 0;
            if (model.INFONO != "")
            {
                Param_Num++;
                strSql.Append(",INFONO");
            }
            if (model.INFONAME != "")
            {
                Param_Num++;
                strSql.Append(",INFONAME");
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
            if (model.ACTIONPEOPLE != "")
            {
                Param_Num++;
                strSql.Append(",ACTIONPEOPLE");
            }
            //if (model.INFOLEVEL != 0 )
            {
                Param_Num++;
                strSql.Append(",INFOLEVEL");
            }
            strSql.Append(" ) ");
            strSql.Append(" values (");
            strSql.Append("?");
            //列出需哟插入的表字段value对象 
            if (model.INFONO != "")
            {
                strSql.Append(",?");
            }
            if (model.INFONAME != "")
            {
                strSql.Append(",?");
            }
            strSql.Append(",?");
            if (model.DESCRIPTION != "")
            {
                strSql.Append(",?");
            }
            if (model.ACTIONPEOPLE != "")
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
            if (model.INFONO != "")
            {
                parameters[index_num] = new OdbcParameter("@INFONO", OdbcType.VarChar, 10);//信息编号
                parameters[index_num].Value = model.INFONO;
                index_num++;
            }
            if (model.INFONAME != "")
            {
                parameters[index_num] = new OdbcParameter("@INFONAME", OdbcType.VarChar, 50);//信息名称
                parameters[index_num].Value = model.INFONAME;
                index_num++;
            }
            {
                parameters[index_num] = new OdbcParameter("@PARENTID", OdbcType.Int);//父类编号
                parameters[index_num].Value = model.PARENTID;
                index_num++;
            }
            if (model.DESCRIPTION != "")
            {
                parameters[index_num] = new OdbcParameter("@DESCRIPTION", OdbcType.VarChar, 256);//描述
                parameters[index_num].Value = model.DESCRIPTION;
                index_num++;
            }
            if (model.ACTIONPEOPLE != "")
            {
                parameters[index_num] = new OdbcParameter("@ACTIONPEOPLE", OdbcType.VarChar, 50);//配置人
                parameters[index_num].Value = model.ACTIONPEOPLE;
                index_num++;
            }
            {
                parameters[index_num] = new OdbcParameter("@INFOLEVEL", OdbcType.Int);//信息等级
                parameters[index_num].Value = model.INFOLEVEL;
                index_num++;
            }
            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters); return model.ID;
        } /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(Djdw.Model.Post.SYS_INFODICT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_INFODICT");
            strSql.Append(" where  INFONO=? and INFONAME=? and PARENTID=? and DESCRIPTION=? and ACTIONPEOPLE=? and INFOLEVEL=?");
            OdbcParameter[] parameters = {  
					new OdbcParameter("@INFONO", OdbcType.VarChar,10),
					new OdbcParameter("@INFONAME", OdbcType.VarChar,50),
					new OdbcParameter("@PARENTID", OdbcType.Int),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,256),
					new OdbcParameter("@ACTIONPEOPLE", OdbcType.VarChar,50),
					new OdbcParameter("@INFOLEVEL", OdbcType.Int)};
            parameters[0].Value = model.INFONO;
            parameters[1].Value = model.INFONAME;
            parameters[2].Value = model.PARENTID;
            parameters[3].Value = model.DESCRIPTION;
            parameters[4].Value = model.ACTIONPEOPLE;
            parameters[5].Value = model.INFOLEVEL;

            return DbHelperMysqlOdbc.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Djdw.Model.Post.SYS_INFODICT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_INFODICT set ");
            strSql.Append("INFONO= ?,");
            strSql.Append("INFONAME= ?,");
            strSql.Append("PARENTID= ?,");
            strSql.Append("DESCRIPTION= ?,");
            strSql.Append("ACTIONPEOPLE= ?,");
            strSql.Append("INFOLEVEL= ?");
            strSql.Append(" where ID= ?");
            OdbcParameter[] parameters = {
					
					new OdbcParameter("@INFONO", OdbcType.VarChar,10),
					new OdbcParameter("@INFONAME", OdbcType.VarChar,50),
					new OdbcParameter("@PARENTID", OdbcType.Int),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,256),
					new OdbcParameter("@ACTIONPEOPLE", OdbcType.VarChar,50),
					new OdbcParameter("@INFOLEVEL", OdbcType.Int),
                    new OdbcParameter("@ID", OdbcType.Int)};
            
            parameters[0].Value = model.INFONO;
            parameters[1].Value = model.INFONAME;
            parameters[2].Value = model.PARENTID;
            parameters[3].Value = model.DESCRIPTION;
            parameters[4].Value = model.ACTIONPEOPLE;
            parameters[5].Value = model.INFOLEVEL;
            parameters[6].Value = model.ID;

            return DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_INFODICT ");
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
            strSql.Append("delete SYS_INFODICT ");
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
        public Djdw.Model.Post.SYS_INFODICT GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_INFODICT ");
            strSql.Append(" where ID=?");
            OdbcParameter[] parameters = {
   				new OdbcParameter("@ID", OdbcType.Int)};
            parameters[0].Value = ID;
            Djdw.Model.Post.SYS_INFODICT model = new Djdw.Model.Post.SYS_INFODICT();
            DataSet ds = DbHelperMysqlOdbc.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["INFONO"].ToString() != "")
                {
                    model.INFONO = ds.Tables[0].Rows[0]["INFONO"].ToString().Trim();
                }
                //model.INFONO = ds.Tables[0].Rows[0]["INFONO"].ToString();
                model.INFONAME = ds.Tables[0].Rows[0]["INFONAME"].ToString();
                if (ds.Tables[0].Rows[0]["PARENTID"].ToString() != "")
                {
                    model.PARENTID = int.Parse(ds.Tables[0].Rows[0]["PARENTID"].ToString().Trim());
                }
                model.DESCRIPTION = ds.Tables[0].Rows[0]["DESCRIPTION"].ToString();
                model.ACTIONPEOPLE = ds.Tables[0].Rows[0]["ACTIONPEOPLE"].ToString();
                if (ds.Tables[0].Rows[0]["INFOLEVEL"].ToString() != "")
                {
                    model.INFOLEVEL = int.Parse(ds.Tables[0].Rows[0]["INFOLEVEL"].ToString().Trim());
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
            strSql.Append("select * from SYS_INFODICT ");
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


