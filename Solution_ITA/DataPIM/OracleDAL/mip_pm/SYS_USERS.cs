using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using DBUtility;
using System.Collections;
using Mis.IDAL.Post;

namespace Mis.OracleDAL.Post
{
	/// <summary>
	/// 数据访问类SYS_USERS。
	/// </summary>
	public class SYS_USERS:ISYS_USERS
	{
		public SYS_USERS()
		{}
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOra.GetMaxID("ID", "SYS_USERS");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_USERS");
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
            strSql.Append("select count(1) from SYS_USERS");
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
        public int Add(Mis.Model.ptgl.SYS_USERS model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_USERS(");
            strSql.Append("ID,DEPTID,USERNO,USERREALNAME,USERNAME,PASSWORD,SEX,AGE,PHONENO,MOBILEPHONE,REMARK1,REMARK2,REMARK3,REMARK4,REMARK5,REMARK6)");
            strSql.Append(" values (");
            strSql.Append(":ID,:DEPTID,:USERNO,:USERREALNAME,:USERNAME,:PASSWORD,:SEX,:AGE,:PHONENO,:MOBILEPHONE,:REMARK1,:REMARK2,:REMARK3,:REMARK4,:REMARK5,:REMARK6)");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,10),
					new OracleParameter(":DEPTID", OracleType.VarChar,30),
					new OracleParameter(":USERNO", OracleType.VarChar,30),
					new OracleParameter(":USERREALNAME", OracleType.VarChar,30),
					new OracleParameter(":USERNAME", OracleType.VarChar,30),
					new OracleParameter(":PASSWORD", OracleType.VarChar,50),
					new OracleParameter(":SEX", OracleType.Number,3),
					new OracleParameter(":AGE", OracleType.Number,3),
                 new OracleParameter(":PHONENO", OracleType.VarChar,20),
                new OracleParameter(":MOBILEPHONE", OracleType.VarChar,20),
                new OracleParameter(":REMARK1", OracleType.VarChar,30),
                new OracleParameter(":REMARK2", OracleType.VarChar,30),
                new OracleParameter(":REMARK3", OracleType.VarChar,30),
                new OracleParameter(":REMARK4", OracleType.VarChar,512),
                new OracleParameter(":REMARK5", OracleType.VarChar,512),
                new OracleParameter(":REMARK6", OracleType.VarChar,512)
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.DEPTID;
            parameters[2].Value = model.USERNO;
            parameters[3].Value = model.USERREALNAME;
            parameters[4].Value = model.USERNAME;
            parameters[5].Value = model.PASSWORD;
            parameters[6].Value = model.SEX;
            parameters[7].Value = model.AGE;

            parameters[8].Value = model.PHONENO;
            parameters[9].Value = model.MOBILEPHONE;
            parameters[10].Value = model.REMARK1;
            parameters[11].Value = model.REMARK2;
            parameters[12].Value = model.REMARK3;
            parameters[13].Value = model.REMARK4;
            parameters[14].Value = model.REMARK5;
            parameters[15].Value = model.REMARK6;

            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
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
            strSql.Append("ID,DEPTID,USERNO,USERREALNAME,USERNAME,PASSWORD,SEX,AGE,PHONENO,MOBILEPHONE,REMARK1,REMARK2,REMARK3,REMARK4,REMARK5,REMARK6)");
            strSql.Append(" values (");
            strSql.Append("SEQSYS_USERS.NEXTVAL,:DEPTID,:USERNO,:USERREALNAME,:USERNAME,:PASSWORD,:SEX,:AGE,:PHONENO,:MOBILEPHONE,:REMARK1,:REMARK2,:REMARK3,:REMARK4,:REMARK5,:REMARK6)");
            OracleParameter[] parameters = {  
					new OracleParameter(":DEPTID", OracleType.VarChar,30),
					new OracleParameter(":USERNO", OracleType.VarChar,30),
					new OracleParameter(":USERREALNAME", OracleType.VarChar,30),
					new OracleParameter(":USERNAME", OracleType.VarChar,30),
					new OracleParameter(":PASSWORD", OracleType.VarChar,50),
					new OracleParameter(":SEX", OracleType.Number,3),
					new OracleParameter(":AGE", OracleType.Number,3),
                new OracleParameter(":PHONENO", OracleType.VarChar,20),
                new OracleParameter(":MOBILEPHONE", OracleType.VarChar,20),
                new OracleParameter(":REMARK1", OracleType.VarChar,30),
                new OracleParameter(":REMARK2", OracleType.VarChar,30),
                new OracleParameter(":REMARK3", OracleType.VarChar,30),
                new OracleParameter(":REMARK4", OracleType.VarChar,512),
                new OracleParameter(":REMARK5", OracleType.VarChar,512),
                new OracleParameter(":REMARK6", OracleType.VarChar,512)
            };
            parameters[0].Value = model.DEPTID;
            parameters[1].Value = model.USERNO;
            parameters[2].Value = model.USERREALNAME;
            parameters[3].Value = model.USERNAME;
            parameters[4].Value = model.PASSWORD;
            parameters[5].Value = model.SEX;
            parameters[6].Value = model.AGE;

            parameters[7].Value = model.PHONENO;
            parameters[8].Value = model.MOBILEPHONE;
            parameters[9].Value = model.REMARK1;
            parameters[10].Value = model.REMARK2;
            parameters[11].Value = model.REMARK3;
            parameters[12].Value = model.REMARK4;
            parameters[13].Value = model.REMARK5;
            parameters[14].Value = model.REMARK6;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(Mis.Model.ptgl.SYS_USERS model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_USERS(");
            strSql.Append("ID");
            //列出需插入的表字段
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
            strSql.Append(":ID");
            //列出需哟插入的表字段value对象 
            if (model.DEPTID != "")
            {
                strSql.Append(",:DEPTID");
            }
            if (model.USERNO != "")
            {
                strSql.Append(",:USERNO");
            }
            if (model.USERREALNAME != "")
            {
                strSql.Append(",:USERREALNAME");
            }
            if (model.USERNAME != "")
            {
                strSql.Append(",:USERNAME");
            }
            if (model.PASSWORD != "")
            {
                strSql.Append(",:PASSWORD");
            }
            strSql.Append(",:SEX");
            strSql.Append(",:AGE");
            strSql.Append(" ) ");
            OracleParameter[] parameters = new OracleParameter[(Param_Num + 1)];
            parameters[0] = new OracleParameter(":ID", OracleType.Number, 4);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            if (model.DEPTID != "")
            {
                parameters[index_num] = new OracleParameter(":DEPTID", OracleType.VarChar, 30);//部门id
                parameters[index_num].Value = model.DEPTID;
                index_num++;
            }
            if (model.USERNO != "")
            {
                parameters[index_num] = new OracleParameter(":USERNO", OracleType.VarChar, 30);//人员工号
                parameters[index_num].Value = model.USERNO;
                index_num++;
            }
            if (model.USERREALNAME != "")
            {
                parameters[index_num] = new OracleParameter(":USERREALNAME", OracleType.VarChar, 30);//人员真实名称
                parameters[index_num].Value = model.USERREALNAME;
                index_num++;
            }
            if (model.USERNAME != "")
            {
                parameters[index_num] = new OracleParameter(":USERNAME", OracleType.VarChar, 30);//用户名
                parameters[index_num].Value = model.USERNAME;
                index_num++;
            }
            if (model.PASSWORD != "")
            {
                parameters[index_num] = new OracleParameter(":PASSWORD", OracleType.VarChar, 50);//人员密码
                parameters[index_num].Value = model.PASSWORD;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":SEX", OracleType.VarChar, 3);//性别
                parameters[index_num].Value = model.SEX;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":AGE", OracleType.VarChar, 3);//年龄
                parameters[index_num].Value = model.AGE;
                index_num++;
            }
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters); return model.ID;
        } /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(Mis.Model.ptgl.SYS_USERS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_USERS");
            strSql.Append(" where  DEPTID=:DEPTID and USERNO=:USERNO and USERREALNAME=:USERREALNAME and USERNAME=:USERNAME and PASSWORD=:PASSWORD and SEX=:SEX and AGE=:AGE");
            OracleParameter[] parameters = {  
					new OracleParameter(":DEPTID", OracleType.VarChar,30),
					new OracleParameter(":USERNO", OracleType.VarChar,30),
					new OracleParameter(":USERREALNAME", OracleType.VarChar,30),
					new OracleParameter(":USERNAME", OracleType.VarChar,30),
					new OracleParameter(":PASSWORD", OracleType.VarChar,50),
					new OracleParameter(":SEX", OracleType.Number,3),
					new OracleParameter(":AGE", OracleType.Number,3)};
            parameters[0].Value = model.DEPTID;
            parameters[1].Value = model.USERNO;
            parameters[2].Value = model.USERREALNAME;
            parameters[3].Value = model.USERNAME;
            parameters[4].Value = model.PASSWORD;
            parameters[5].Value = model.SEX;
            parameters[6].Value = model.AGE;

            return false;
        }

        public int UpdateNotall(Mis.Model.ptgl.SYS_USERS model)
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
            strSql.Append(":ID");
            //列出需哟插入的表字段value对象 
            if (model.DEPTID != "")
            {
                strSql.Append(",:DEPTID");
            }
            if (model.USERNO != "")
            {
                strSql.Append(",:USERNO");
            }
            if (model.USERREALNAME != "")
            {
                strSql.Append(",:USERREALNAME");
            }
            if (model.USERNAME != "")
            {
                strSql.Append(",:USERNAME");
            }
            if (model.PASSWORD != "")
            {
                strSql.Append(",:PASSWORD");
            }
            strSql.Append(",:SEX");
            strSql.Append(",:AGE");

            strSql.Append(" ) ");
            OracleParameter[] parameters = new OracleParameter[(Param_Num + 1)];
            parameters[0] = new OracleParameter(":ID", OracleType.Number, 4);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            if (model.DEPTID != "")
            {
                parameters[index_num] = new OracleParameter(":DEPTID", OracleType.VarChar, 30);//部门id
                parameters[index_num].Value = model.DEPTID;
                index_num++;
            }
            if (model.USERNO != "")
            {
                parameters[index_num] = new OracleParameter(":USERNO", OracleType.VarChar, 30);//人员工号
                parameters[index_num].Value = model.USERNO;
                index_num++;
            }
            if (model.USERREALNAME != "")
            {
                parameters[index_num] = new OracleParameter(":USERREALNAME", OracleType.VarChar, 30);//人员真实名称
                parameters[index_num].Value = model.USERREALNAME;
                index_num++;
            }
            if (model.USERNAME != "")
            {
                parameters[index_num] = new OracleParameter(":USERNAME", OracleType.VarChar, 30);//用户名
                parameters[index_num].Value = model.USERNAME;
                index_num++;
            }
            if (model.PASSWORD != "")
            {
                parameters[index_num] = new OracleParameter(":PASSWORD", OracleType.VarChar, 50);//人员密码
                parameters[index_num].Value = model.PASSWORD;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":SEX", OracleType.VarChar, 3);//性别
                parameters[index_num].Value = model.SEX;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":AGE", OracleType.VarChar, 3);//年龄
                parameters[index_num].Value = model.AGE;
                index_num++;
            }
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Mis.Model.ptgl.SYS_USERS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_USERS set ");
            strSql.Append("DEPTID=:DEPTID,");
            strSql.Append("USERNO=:USERNO,");
            strSql.Append("USERREALNAME=:USERREALNAME,");
            strSql.Append("USERNAME=:USERNAME,");
            strSql.Append("PASSWORD=:PASSWORD,");
            strSql.Append("SEX=:SEX,");
            strSql.Append("AGE=:AGE,");
            strSql.Append("PHONENO=:PHONENO,");
            strSql.Append("MOBILEPHONE=:MOBILEPHONE,");
            strSql.Append("REMARK1=:REMARK1,");
            strSql.Append("REMARK2=:REMARK2,");
            strSql.Append("REMARK3=:REMARK3,");
            strSql.Append("REMARK4=:REMARK4,");
            strSql.Append("REMARK5=:REMARK5,");
            strSql.Append("REMARK6=:REMARK6");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,10),
					new OracleParameter(":DEPTID", OracleType.VarChar,30),
					new OracleParameter(":USERNO", OracleType.VarChar,30),
					new OracleParameter(":USERREALNAME", OracleType.VarChar,30),
					new OracleParameter(":USERNAME", OracleType.VarChar,30),
					new OracleParameter(":PASSWORD", OracleType.VarChar,50),
					new OracleParameter(":SEX", OracleType.Number,3),
					new OracleParameter(":AGE", OracleType.Number,3),
                    new OracleParameter(":PHONENO", OracleType.VarChar,20),
                    new OracleParameter(":MOBILEPHONE", OracleType.VarChar,20),
                    new OracleParameter(":REMARK1", OracleType.VarChar,30),
                    new OracleParameter(":REMARK2", OracleType.VarChar,30),
                    new OracleParameter(":REMARK3", OracleType.VarChar,30),
                    new OracleParameter(":REMARK4", OracleType.VarChar,512),
                    new OracleParameter(":REMARK5", OracleType.VarChar,512),
                    new OracleParameter(":REMARK6", OracleType.VarChar,512),

                };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.DEPTID;
            parameters[2].Value = model.USERNO;
            parameters[3].Value = model.USERREALNAME;
            parameters[4].Value = model.USERNAME;
            parameters[5].Value = model.PASSWORD;
            parameters[6].Value = model.SEX;
            parameters[7].Value = model.AGE;

            parameters[8].Value = model.PHONENO;
            parameters[9].Value = model.MOBILEPHONE;
            parameters[10].Value = model.REMARK1;
            parameters[11].Value = model.REMARK2;
            parameters[12].Value = model.REMARK3;
            parameters[13].Value = model.REMARK4;
            parameters[14].Value = model.REMARK5;
            parameters[15].Value = model.REMARK6;

            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_USERS ");
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
            strSql.Append("delete SYS_USERS ");
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
        public Mis.Model.ptgl.SYS_USERS GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_USERS ");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
   				new OracleParameter(":ID", OracleType.Number)};
            parameters[0].Value = ID;
            Mis.Model.ptgl.SYS_USERS model = new Mis.Model.ptgl.SYS_USERS();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
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
                model.PHONENO = ds.Tables[0].Rows[0]["PHONENO"].ToString();
                model.MOBILEPHONE = ds.Tables[0].Rows[0]["MOBILEPHONE"].ToString();
                model.REMARK1 = ds.Tables[0].Rows[0]["REMARK1"].ToString();
                model.REMARK2 = ds.Tables[0].Rows[0]["REMARK2"].ToString();
                model.REMARK3 = ds.Tables[0].Rows[0]["REMARK3"].ToString();
                model.REMARK4 = ds.Tables[0].Rows[0]["REMARK4"].ToString();
                model.REMARK5 = ds.Tables[0].Rows[0]["REMARK5"].ToString();
                model.REMARK6 = ds.Tables[0].Rows[0]["REMARK6"].ToString();
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
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion  成员方法
	}
}

