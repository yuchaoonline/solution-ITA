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
    /// 数据访问类SYS_MOUDLEACTION
    /// </summary>
    public class SYS_MOUDLEACTION : ISYS_MOUDLEACTION
    {
        public SYS_MOUDLEACTION()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMysqlOdbc.GetMaxID("ID", "SYS_MOUDLEACTION");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_MOUDLEACTION");
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
            strSql.Append("select count(1) from SYS_MOUDLEACTION");
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
        public int Add(Mis.Model.ptgl.SYS_MOUDLEACTION model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_MOUDLEACTION(");
            strSql.Append("ID,MOUDLENAME,ACTION,DESCRIPTION)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? )");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@MOUDLENAME", OdbcType.VarChar,30),
					new OdbcParameter("@ACTION", OdbcType.VarChar,30),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,200)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.MOUDLENAME;
            parameters[2].Value = model.ACTION;
            parameters[3].Value = model.DESCRIPTION;

            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }

        /// <summary>
        /// 事务处理增加一个model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public DictionaryEntry AddSql(Mis.Model.ptgl.SYS_MOUDLEACTION model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_MOUDLEACTION(");
            strSql.Append("MOUDLENAME,ACTION,DESCRIPTION)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? )");
            OdbcParameter[] parameters = {					
                    new OdbcParameter("@MOUDLENAME", OdbcType.VarChar,30),
					new OdbcParameter("@ACTION", OdbcType.VarChar,30),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,200)};
            parameters[0].Value = model.MOUDLENAME;
            parameters[1].Value = model.ACTION;
            parameters[2].Value = model.DESCRIPTION;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(Mis.Model.ptgl.SYS_MOUDLEACTION model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_MOUDLEACTION(");
            strSql.Append("ID");
            //列出需哟插入的表字段
            int Param_Num = 0;
            if (model.MOUDLENAME != "")
            {
                Param_Num++;
                strSql.Append(",MOUDLENAME");
            }
            if (model.ACTION != "")
            {
                Param_Num++;
                strSql.Append(",ACTION");
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
            if (model.MOUDLENAME != "")
            {
                strSql.Append(",?");
            }
            if (model.ACTION != "")
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
            if (model.MOUDLENAME != "")
            {
                parameters[index_num] = new OdbcParameter("@MOUDLENAME", OdbcType.VarChar, 30);//模块名称
                parameters[index_num].Value = model.MOUDLENAME;
                index_num++;
            }
            if (model.ACTION != "")
            {
                parameters[index_num] = new OdbcParameter("@ACTION", OdbcType.VarChar, 30);//动作名称
                parameters[index_num].Value = model.ACTION;
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
        public bool Existsmodel(Mis.Model.ptgl.SYS_MOUDLEACTION model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_MOUDLEACTION");
            strSql.Append(" where  MOUDLENAME=? and ACTION=? and DESCRIPTION=?");
            OdbcParameter[] parameters = {  

                	new OdbcParameter("@MOUDLENAME", OdbcType.VarChar,30),
					new OdbcParameter("@ACTION", OdbcType.VarChar,30),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,200)
};
            parameters[0].Value = model.MOUDLENAME;
            parameters[1].Value = model.ACTION;
            parameters[2].Value = model.DESCRIPTION;

            return DbHelperMysqlOdbc.Exists(strSql.ToString(), parameters);
        }

        public int UpdateNotall(Mis.Model.ptgl.SYS_MOUDLEACTION model)
        {
            return Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Mis.Model.ptgl.SYS_MOUDLEACTION model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_MOUDLEACTION set ");
            strSql.Append("MOUDLENAME= ?,");
            strSql.Append("ACTION= ?,");
            strSql.Append("DESCRIPTION= ?");
            strSql.Append(" where ID= ?");
            OdbcParameter[] parameters = {
					
					new OdbcParameter("@MOUDLENAME", OdbcType.VarChar,30),
					new OdbcParameter("@ACTION", OdbcType.VarChar,30),
					new OdbcParameter("@DESCRIPTION", OdbcType.VarChar,200),
                    new OdbcParameter("@ID", OdbcType.Int)};
           
            parameters[0].Value = model.MOUDLENAME;
            parameters[1].Value = model.ACTION;
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
            strSql.Append("delete from SYS_MOUDLEACTION ");
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
            strSql.Append("delete from SYS_MOUDLEACTION ");
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
        public Mis.Model.ptgl.SYS_MOUDLEACTION GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_MOUDLEACTION ");
            strSql.Append(" where ID=?");
            OdbcParameter[] parameters = {
   				new OdbcParameter("@ID", OdbcType.Int)};
            parameters[0].Value = ID;
            Mis.Model.ptgl.SYS_MOUDLEACTION model = new Mis.Model.ptgl.SYS_MOUDLEACTION();
            DataSet ds = DbHelperMysqlOdbc.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.MOUDLENAME = ds.Tables[0].Rows[0]["MOUDLENAME"].ToString();
                model.ACTION = ds.Tables[0].Rows[0]["ACTION"].ToString();
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
            strSql.Append("select * from SYS_MOUDLEACTION ");
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


