using System;
using System.Data;
using System.Text;
using System.Data.Odbc;
using  xxty.IDAL.Post;
using DBUtility;
 using System.Collections;

namespace xxty.OdbcDAL.Post
{

    /// <summary>
    /// 数据访问类ISMP_DG
    /// </summary>
    public class ISMP_DG : IISMP_DG
    {
        public ISMP_DG()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMysqlOdbc.GetMaxID("ID", "ISMP_DG");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ISMP_DG");
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
            strSql.Append("select count(1) from ISMP_DG");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID");
            return DbHelperMysqlOdbc.Exists(strSql.ToString(),null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(xxty.Model.Post.ISMP_DG model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ISMP_DG(");
            strSql.Append("ID,PRODUCTID,USERID,MYSTATUS,TD_CAUSE,CONFIRM_TIME,DATE_ADD,ISCONFIRM,SOURCEID)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? , ? , ? , ? , ? , ? )");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@PRODUCTID", OdbcType.VarChar,128),
					new OdbcParameter("@USERID", OdbcType.VarChar,128),
					new OdbcParameter("@MYSTATUS", OdbcType.Int),
					new OdbcParameter("@TD_CAUSE", OdbcType.VarChar,255),
					new OdbcParameter("@CONFIRM_TIME", OdbcType.VarChar,50),
					new OdbcParameter("@DATE_ADD", OdbcType.VarChar,20),
					new OdbcParameter("@ISCONFIRM", OdbcType.VarChar,50),
					new OdbcParameter("@SOURCEID", OdbcType.VarChar,20)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.PRODUCTID;
            parameters[2].Value = model.USERID;
            parameters[3].Value = model.MYSTATUS;
            parameters[4].Value = model.TD_CAUSE;
            parameters[5].Value = model.CONFIRM_TIME;
            parameters[6].Value = model.DATE_ADD;
            parameters[7].Value = model.ISCONFIRM;
            parameters[8].Value = model.SOURCEID;

            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }

        /// <summary>
        /// 事务处理增加一个model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public DictionaryEntry AddSql(xxty.Model.Post.ISMP_DG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ISMP_DG(");
            strSql.Append("ID,PRODUCTID,USERID,MYSTATUS,TD_CAUSE,CONFIRM_TIME,DATE_ADD,ISCONFIRM,SOURCEID)");
            strSql.Append(" values (");
            strSql.Append(" ? , ? , ? , ? , ? , ? , ? , ? , ? )");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@PRODUCTID", OdbcType.VarChar,128),
					new OdbcParameter("@USERID", OdbcType.VarChar,128),
					new OdbcParameter("@MYSTATUS", OdbcType.Int),
					new OdbcParameter("@TD_CAUSE", OdbcType.VarChar,255),
					new OdbcParameter("@CONFIRM_TIME", OdbcType.VarChar,50),
					new OdbcParameter("@DATE_ADD", OdbcType.VarChar,20),
					new OdbcParameter("@ISCONFIRM", OdbcType.VarChar,50),
					new OdbcParameter("@SOURCEID", OdbcType.VarChar,20)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.PRODUCTID;
            parameters[2].Value = model.USERID;
            parameters[3].Value = model.MYSTATUS;
            parameters[4].Value = model.TD_CAUSE;
            parameters[5].Value = model.CONFIRM_TIME;
            parameters[6].Value = model.DATE_ADD;
            parameters[7].Value = model.ISCONFIRM;
            parameters[8].Value = model.SOURCEID;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(xxty.Model.Post.ISMP_DG model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ISMP_DG(");
            strSql.Append("ID");
            //列出需哟插入的表字段
            int Param_Num = 0;
            if (model.PRODUCTID != "")
            {
                Param_Num++;
                strSql.Append(",PRODUCTID");
            }
            if (model.USERID != "")
            {
                Param_Num++;
                strSql.Append(",USERID");
            }
            //if (model.MYSTATUS != 0 )
            {
                Param_Num++;
                strSql.Append(",MYSTATUS");
            }
            if (model.TD_CAUSE != "")
            {
                Param_Num++;
                strSql.Append(",TD_CAUSE");
            }
            if (model.CONFIRM_TIME != "")
            {
                Param_Num++;
                strSql.Append(",CONFIRM_TIME");
            }
            if (model.DATE_ADD != "")
            {
                Param_Num++;
                strSql.Append(",DATE_ADD");
            }
            if (model.ISCONFIRM != "")
            {
                Param_Num++;
                strSql.Append(",ISCONFIRM");
            }
            if (model.SOURCEID != "")
            {
                Param_Num++;
                strSql.Append(",SOURCEID");
            }
            strSql.Append(" ) ");
            strSql.Append(" values (");
            strSql.Append("?");
            //列出需哟插入的表字段value对象 
            if (model.PRODUCTID != "")
            {
                strSql.Append(",?");
            }
            if (model.USERID != "")
            {
                strSql.Append(",?");
            }
            strSql.Append(",?");
            if (model.TD_CAUSE != "")
            {
                strSql.Append(",?");
            }
            if (model.CONFIRM_TIME != "")
            {
                strSql.Append(",?");
            }
            if (model.DATE_ADD != "")
            {
                strSql.Append(",?");
            }
            if (model.ISCONFIRM != "")
            {
                strSql.Append(",?");
            }
            if (model.SOURCEID != "")
            {
                strSql.Append(",?");
            }
            strSql.Append(" ) ");
            OdbcParameter[] parameters = new OdbcParameter[(Param_Num + 1)];
            parameters[0] = new OdbcParameter("@ID", OdbcType.Int);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            if (model.PRODUCTID != "")
            {
                parameters[index_num] = new OdbcParameter("@PRODUCTID", OdbcType.VarChar, 128);//产品编号
                parameters[index_num].Value = model.PRODUCTID;
                index_num++;
            }
            if (model.USERID != "")
            {
                parameters[index_num] = new OdbcParameter("@USERID", OdbcType.VarChar, 128);//用户编号
                parameters[index_num].Value = model.USERID;
                index_num++;
            }
            {
                parameters[index_num] = new OdbcParameter("@MYSTATUS", OdbcType.Int);//状态
                parameters[index_num].Value = model.MYSTATUS;
                index_num++;
            }
            if (model.TD_CAUSE != "")
            {
                parameters[index_num] = new OdbcParameter("@TD_CAUSE", OdbcType.VarChar, 255);//退订原因
                parameters[index_num].Value = model.TD_CAUSE;
                index_num++;
            }
            if (model.CONFIRM_TIME != "")
            {
                parameters[index_num] = new OdbcParameter("@CONFIRM_TIME", OdbcType.VarChar, 50);//确认时间
                parameters[index_num].Value = model.CONFIRM_TIME;
                index_num++;
            }
            if (model.DATE_ADD != "")
            {
                parameters[index_num] = new OdbcParameter("@DATE_ADD", OdbcType.VarChar, 20);//添加日期
                parameters[index_num].Value = model.DATE_ADD;
                index_num++;
            }
            if (model.ISCONFIRM != "")
            {
                parameters[index_num] = new OdbcParameter("@ISCONFIRM", OdbcType.VarChar, 50);//返回
                parameters[index_num].Value = model.ISCONFIRM;
                index_num++;
            }
            if (model.SOURCEID != "")
            {
                parameters[index_num] = new OdbcParameter("@SOURCEID", OdbcType.VarChar, 20);//返回的ID
                parameters[index_num].Value = model.SOURCEID;
                index_num++;
            }
            DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters); return model.ID;
        } /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(xxty.Model.Post.ISMP_DG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ISMP_DG");
            strSql.Append(" where  PRODUCTID=? and USERID=? and MYSTATUS=? and TD_CAUSE=? and CONFIRM_TIME=? and DATE_ADD=? and ISCONFIRM=? and SOURCEID=?");
            OdbcParameter[] parameters = {  


					new OdbcParameter("@MYSTATUS", OdbcType.Int),					new OdbcParameter("@MYSTATUS", OdbcType.VarChar,3),




};
            parameters[0].Value = model.PRODUCTID;
            parameters[1].Value = model.USERID;
            parameters[2].Value = model.MYSTATUS;
            parameters[3].Value = model.TD_CAUSE;
            parameters[4].Value = model.CONFIRM_TIME;
            parameters[5].Value = model.DATE_ADD;
            parameters[6].Value = model.ISCONFIRM;
            parameters[7].Value = model.SOURCEID;

            return DbHelperMysqlOdbc.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(xxty.Model.Post.ISMP_DG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ISMP_DG set ");
            strSql.Append("PRODUCTID= ?,");
            strSql.Append("USERID= ?,");
            strSql.Append("MYSTATUS= ?,");
            strSql.Append("TD_CAUSE= ?,");
            strSql.Append("CONFIRM_TIME= ?,");
            strSql.Append("DATE_ADD= ?,");
            strSql.Append("ISCONFIRM= ?,");
            strSql.Append("SOURCEID= ?");
            strSql.Append(" where ID= ?");
            OdbcParameter[] parameters = {
					new OdbcParameter("@ID", OdbcType.Int),
					new OdbcParameter("@PRODUCTID", OdbcType.VarChar,128),
					new OdbcParameter("@USERID", OdbcType.VarChar,128),
					new OdbcParameter("@MYSTATUS", OdbcType.Int),
					new OdbcParameter("@TD_CAUSE", OdbcType.VarChar,255),
					new OdbcParameter("@CONFIRM_TIME", OdbcType.VarChar,50),
					new OdbcParameter("@DATE_ADD", OdbcType.VarChar,20),
					new OdbcParameter("@ISCONFIRM", OdbcType.VarChar,50),
					new OdbcParameter("@SOURCEID", OdbcType.VarChar,20)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.PRODUCTID;
            parameters[2].Value = model.USERID;
            parameters[3].Value = model.MYSTATUS;
            parameters[4].Value = model.TD_CAUSE;
            parameters[5].Value = model.CONFIRM_TIME;
            parameters[6].Value = model.DATE_ADD;
            parameters[7].Value = model.ISCONFIRM;
            parameters[8].Value = model.SOURCEID;

            return DbHelperMysqlOdbc.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ISMP_DG ");
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
            strSql.Append("delete ISMP_DG ");
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
        public xxty.Model.Post.ISMP_DG GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ISMP_DG ");
            strSql.Append(" where ID=?");
            OdbcParameter[] parameters = {
   				new OdbcParameter("@ID", OdbcType.Int)};
            parameters[0].Value = ID;
            xxty.Model.Post.ISMP_DG model = new xxty.Model.Post.ISMP_DG();
            DataSet ds = DbHelperMysqlOdbc.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.PRODUCTID = ds.Tables[0].Rows[0]["PRODUCTID"].ToString();
                model.USERID = ds.Tables[0].Rows[0]["USERID"].ToString();
                if (ds.Tables[0].Rows[0]["MYSTATUS"].ToString() != "")
                {
                    model.MYSTATUS = int.Parse(ds.Tables[0].Rows[0]["MYSTATUS"].ToString().Trim());
                }
                model.TD_CAUSE = ds.Tables[0].Rows[0]["TD_CAUSE"].ToString();
                model.CONFIRM_TIME = ds.Tables[0].Rows[0]["CONFIRM_TIME"].ToString();
                model.DATE_ADD = ds.Tables[0].Rows[0]["DATE_ADD"].ToString();
                model.ISCONFIRM = ds.Tables[0].Rows[0]["ISCONFIRM"].ToString();
                model.SOURCEID = ds.Tables[0].Rows[0]["SOURCEID"].ToString();
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
            strSql.Append("select * from ISMP_DG ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return DbHelperMysqlOdbc.Query(strSql.ToString());
        }
        #endregion  成员方法

        #region IISMP_DG 成员


        public DictionaryEntry Updatesql(xxty.Model.Post.ISMP_DG model)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UpdateNotall(xxty.Model.Post.ISMP_DG model)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}


