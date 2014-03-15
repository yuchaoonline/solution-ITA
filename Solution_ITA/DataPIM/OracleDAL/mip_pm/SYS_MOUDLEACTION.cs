using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using DBUtility;
using System.Collections;
using Mis.IDAL.Post;//请先添加引用;
namespace Mis.OracleDAL.Post
{
	/// <summary>
	/// 数据访问类SYS_MOUDLEACTION。
	/// </summary>
	public class SYS_MOUDLEACTION:ISYS_MOUDLEACTION
	{
		public SYS_MOUDLEACTION()
		{}
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOra.GetMaxID("ID", "SYS_MOUDLEACTION");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_MOUDLEACTION");
            strSql.Append(" where ID= :ID");
            OracleParameter[] parameters = {
				new OracleParameter(":ID", OracleType.Number)
			};
            parameters[0].Value = ID;
            return DbHelperOra.Exists(strSql.ToString(), parameters);
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
            return DbHelperOra.Exists(strSql.ToString());
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Mis.Model.ptgl.SYS_MOUDLEACTION model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_MOUDLEACTION(");
            strSql.Append("ID,MOUDLENAME,ACTION,DESCRIPTION,ISOFDATAFILTER)");
            strSql.Append(" values (");
            strSql.Append(":ID,:MOUDLENAME,:ACTION,:DESCRIPTION,:ISOFDATAFILTER)");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,10),
					new OracleParameter(":MOUDLENAME", OracleType.VarChar,30),
					new OracleParameter(":ACTION", OracleType.VarChar,30),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,200),
                    new OracleParameter(":ISOFDATAFILTER", OracleType.Number,10)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.MOUDLENAME;
            parameters[2].Value = model.ACTION;
            parameters[3].Value = model.DESCRIPTION;
            parameters[4].Value = model.ISOFDATAFILTER;

            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
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
            strSql.Append("ID,MOUDLENAME,ACTION,DESCRIPTION,ISOFDATAFILTER)");
            strSql.Append(" values (");
            strSql.Append("SEQSYS_MOUDLEACTION.NEXTVAL,:MOUDLENAME,:ACTION,:DESCRIPTION,:ISOFDATAFILTER)");
            OracleParameter[] parameters = {  
					new OracleParameter(":MOUDLENAME", OracleType.VarChar,30),
					new OracleParameter(":ACTION", OracleType.VarChar,30),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,200),
                    new OracleParameter(":ISOFDATAFILTER", OracleType.Number,10)};
            parameters[0].Value = model.MOUDLENAME;
            parameters[1].Value = model.ACTION;
            parameters[2].Value = model.DESCRIPTION;
            parameters[3].Value = model.ISOFDATAFILTER;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(Mis.Model.ptgl.SYS_MOUDLEACTION model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_MOUDLEACTION(");
            strSql.Append("ID");
            //列出需插入的表字段
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
            strSql.Append(":ID");
            //列出需哟插入的表字段value对象 
            if (model.MOUDLENAME != "")
            {
                strSql.Append(",:MOUDLENAME");
            }
            if (model.ACTION != "")
            {
                strSql.Append(",:ACTION");
            }
            if (model.DESCRIPTION != "")
            {
                strSql.Append(",:DESCRIPTION");
            }
            strSql.Append(" ) ");
            OracleParameter[] parameters = new OracleParameter[(Param_Num + 1)];
            parameters[0] = new OracleParameter(":ID", OracleType.Number, 4);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            if (model.MOUDLENAME != "")
            {
                parameters[index_num] = new OracleParameter(":MOUDLENAME", OracleType.VarChar, 30);//模块名称
                parameters[index_num].Value = model.MOUDLENAME;
                index_num++;
            }
            if (model.ACTION != "")
            {
                parameters[index_num] = new OracleParameter(":ACTION", OracleType.VarChar, 30);//动作名称
                parameters[index_num].Value = model.ACTION;
                index_num++;
            }
            if (model.DESCRIPTION != "")
            {
                parameters[index_num] = new OracleParameter(":DESCRIPTION", OracleType.VarChar, 200);//描述
                parameters[index_num].Value = model.DESCRIPTION;
                index_num++;
            }
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters); return model.ID;
        } /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(Mis.Model.ptgl.SYS_MOUDLEACTION model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_MOUDLEACTION");
            strSql.Append(" where  MOUDLENAME=:MOUDLENAME and ACTION=:ACTION and DESCRIPTION=:DESCRIPTION");
            OracleParameter[] parameters = {  
					new OracleParameter(":MOUDLENAME", OracleType.VarChar,30),
					new OracleParameter(":ACTION", OracleType.VarChar,30),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,200)};
            parameters[0].Value = model.MOUDLENAME;
            parameters[1].Value = model.ACTION;
            parameters[2].Value = model.DESCRIPTION;

            return false;
        }

        public int UpdateNotall(Mis.Model.ptgl.SYS_MOUDLEACTION model)
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
            strSql.Append(":ID");
            //列出需哟插入的表字段value对象 
            if (model.MOUDLENAME != "")
            {
                strSql.Append(",:MOUDLENAME");
            }
            if (model.ACTION != "")
            {
                strSql.Append(",:ACTION");
            }
            if (model.DESCRIPTION != "")
            {
                strSql.Append(",:DESCRIPTION");
            }
            strSql.Append(" ) ");
            OracleParameter[] parameters = new OracleParameter[(Param_Num + 1)];
            parameters[0] = new OracleParameter(":ID", OracleType.Number, 4);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            if (model.MOUDLENAME != "")
            {
                parameters[index_num] = new OracleParameter(":MOUDLENAME", OracleType.VarChar, 30);//模块名称
                parameters[index_num].Value = model.MOUDLENAME;
                index_num++;
            }
            if (model.ACTION != "")
            {
                parameters[index_num] = new OracleParameter(":ACTION", OracleType.VarChar, 30);//动作名称
                parameters[index_num].Value = model.ACTION;
                index_num++;
            }
            if (model.DESCRIPTION != "")
            {
                parameters[index_num] = new OracleParameter(":DESCRIPTION", OracleType.VarChar, 200);//描述
                parameters[index_num].Value = model.DESCRIPTION;
                index_num++;
            }
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Mis.Model.ptgl.SYS_MOUDLEACTION model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_MOUDLEACTION set ");
            strSql.Append("MOUDLENAME=:MOUDLENAME,");
            strSql.Append("ACTION=:ACTION,");
            strSql.Append("DESCRIPTION=:DESCRIPTION,");
            strSql.Append("ISOFDATAFILTER=:ISOFDATAFILTER");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,10),
					new OracleParameter(":MOUDLENAME", OracleType.VarChar,30),
					new OracleParameter(":ACTION", OracleType.VarChar,30),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,200),
                    new OracleParameter(":ISOFDATAFILTER", OracleType.Number,10)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.MOUDLENAME;
            parameters[2].Value = model.ACTION;
            parameters[3].Value = model.DESCRIPTION;
            parameters[4].Value = model.ISOFDATAFILTER;

            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SYS_MOUDLEACTION ");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
				new OracleParameter(":ID", OracleType.Number)
			};
            parameters[0].Value = ID;
            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
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
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
				new OracleParameter(":ID", OracleType.Number)
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
            return DbHelperOra.ExecuteSqlTran(tb);
        }

        /// <summary>
        /// 事务处理
        /// </summary>
        /// <param name="SQLStringList">ArrayList</param>
        /// <returns>int</returns>
        public int ExecuteSqlTranByArray(ArrayList SQLStringList)
        {
            return DbHelperOra.ExecuteSqlTranByArray(SQLStringList);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mis.Model.ptgl.SYS_MOUDLEACTION GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_MOUDLEACTION ");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
   				new OracleParameter(":ID", OracleType.Number)};
            parameters[0].Value = ID;
            Mis.Model.ptgl.SYS_MOUDLEACTION model = new Mis.Model.ptgl.SYS_MOUDLEACTION();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.MOUDLENAME = ds.Tables[0].Rows[0]["MOUDLENAME"].ToString();
                model.ACTION = ds.Tables[0].Rows[0]["ACTION"].ToString();
                model.DESCRIPTION = ds.Tables[0].Rows[0]["DESCRIPTION"].ToString();
                if (ds.Tables[0].Rows[0]["ISOFDATAFILTER"] != null && ds.Tables[0].Rows[0]["ISOFDATAFILTER"].ToString()!="")
                {
                    model.ISOFDATAFILTER = int.Parse(ds.Tables[0].Rows[0]["ISOFDATAFILTER"].ToString());
                }
                else
                    model.ISOFDATAFILTER = 0;
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
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion  成员方法
	}
}

