 using System;
 using System.Data;
 using System.Text;
using System.Collections;
using System.Collections.Specialized;
 using System.Data.OracleClient;
using DBUtility;
using Mis.IDAL.Post;

namespace Mis.OracleDAL.Post
{
	/// <summary>
	/// ���ݷ�����SYS_MENU��
	/// </summary>
	public class SYS_MENU:ISYS_MENU
	{
		public SYS_MENU()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOra.GetMaxID("ID", "SYS_MENU");
        }
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
        public bool Exists(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_MENU");
            strSql.Append(" where ID= :ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.VarChar,30)
				};
            parameters[0].Value = ID;
            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Djdw.Model.Post.SYS_MENU model)
        {
            model.ID=GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_MENU(");
            strSql.Append("ID,SYSNAME,MOUDLENAME,SYSLEVEL,PARENT,URL,DESCRIPTION,IMG,VERSION)");
            strSql.Append(" values (");
            strSql.Append(":ID,:SYSNAME,:MOUDLENAME,:SYSLEVEL,:PARENT,:URL,:DESCRIPTION,:IMG,:VERSION)");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,5),
					new OracleParameter(":SYSNAME", OracleType.VarChar,30),
					new OracleParameter(":MOUDLENAME", OracleType.VarChar,30),
					new OracleParameter(":SYSLEVEL", OracleType.Number,4),
					new OracleParameter(":PARENT", OracleType.VarChar,30),
					new OracleParameter(":URL", OracleType.VarChar,256),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,256),
					new OracleParameter(":IMG", OracleType.VarChar,256),
                    new OracleParameter(":VERSION", OracleType.Number,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SYSNAME;
            parameters[2].Value = model.MOUDLENAME;
            parameters[3].Value = model.SYSLEVEL;
            parameters[4].Value = model.PARENT;
            parameters[5].Value = model.URL;
            parameters[6].Value = model.DESCRIPTION;
            parameters[7].Value = model.IMG;
            parameters[8].Value = model.VERSION;

            int ret_value = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            return ret_value;
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Djdw.Model.Post.SYS_MENU model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_MENU set ");
            strSql.Append("SYSNAME=:SYSNAME,");
            strSql.Append("MOUDLENAME=:MOUDLENAME,");
            strSql.Append("SYSLEVEL=:SYSLEVEL,");
            strSql.Append("PARENT=:PARENT,");
            strSql.Append("URL=:URL,");
            strSql.Append("DESCRIPTION=:DESCRIPTION,");
            strSql.Append("IMG=:IMG,");
            strSql.Append("VERSION=:VERSION");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,5),
					new OracleParameter(":SYSNAME", OracleType.VarChar,30),
					new OracleParameter(":MOUDLENAME", OracleType.VarChar,30),
					new OracleParameter(":SYSLEVEL", OracleType.Number,4),
					new OracleParameter(":PARENT", OracleType.VarChar,30),
					new OracleParameter(":URL", OracleType.VarChar,256),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,256),
					new OracleParameter(":IMG", OracleType.VarChar,256),
                    new OracleParameter(":VERSION", OracleType.Number,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SYSNAME;
            parameters[2].Value = model.MOUDLENAME;
            parameters[3].Value = model.SYSLEVEL;
            parameters[4].Value = model.PARENT;
            parameters[5].Value = model.URL;
            parameters[6].Value = model.DESCRIPTION;
            parameters[7].Value = model.IMG;
            parameters[8].Value = model.VERSION;
            //new OracleParameter(":VERSION", OracleType.Number,4)

            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_MENU ");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,5)
				};
            parameters[0].Value = int.Parse(ID);
            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        public DictionaryEntry GetDeltSqls(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SYS_MENU ");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,5)
				};
            parameters[0].Value = int.Parse(ID);
            DictionaryEntry dentry = new DictionaryEntry(strSql, parameters);
            return dentry;
        }


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Djdw.Model.Post.SYS_MENU GetModel(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from SYS_MENU ");
			strSql.Append(" where ID=:ID");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number)};
			parameters[0].Value = int.Parse(ID);
			Djdw.Model.Post.SYS_MENU model=new Djdw.Model.Post.SYS_MENU();
			DataSet ds=DbHelperOra.Query(strSql.ToString(),parameters);
            model.ID = int.Parse(ID);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.SYSNAME=ds.Tables[0].Rows[0]["SYSNAME"].ToString();
				model.MOUDLENAME=ds.Tables[0].Rows[0]["MOUDLENAME"].ToString();
				if(ds.Tables[0].Rows[0]["SYSLEVEL"].ToString()!="")
				{
					model.SYSLEVEL=int.Parse(ds.Tables[0].Rows[0]["SYSLEVEL"].ToString());
				}
				model.PARENT=ds.Tables[0].Rows[0]["PARENT"].ToString();
				model.URL=ds.Tables[0].Rows[0]["URL"].ToString();
				model.DESCRIPTION=ds.Tables[0].Rows[0]["DESCRIPTION"].ToString();
				model.IMG=ds.Tables[0].Rows[0]["IMG"].ToString();
                if(ds.Tables[0].Rows[0]["VERSION"].ToString()!="")
				{
					model.VERSION=int.Parse(ds.Tables[0].Rows[0]["VERSION"].ToString());
				}
               
				return model;
			}
			else
			{
			return null;
			}
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from SYS_MENU ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by ID desc ");
			return DbHelperOra.Query(strSql.ToString());
		}

        /// <summary>
        /// ִ��ɾ������
        /// </summary>
        /// 
        public void RunTrans(Hashtable SQLStringList)
        {
            DbHelperOra.ExecuteSqlTran(SQLStringList);
        }
        
		#endregion  ��Ա����

        #region ISYS_MENU ��Ա


        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_MENU");
            strSql.Append(" where ID= :ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.VarChar,30)
				};
            parameters[0].Value = ID;
            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }

        public bool Existsmodel(Djdw.Model.Post.SYS_MENU model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_MENU");
            strSql.Append(" where  SYSNAME=:SYSNAME and MOUDLENAME=:MOUDLENAME and SYSLEVEL=:SYSLEVEL and PARENT=:PARENT and URL=:URL and DESCRIPTION=:DESCRIPTION and IMG=:IMG and VERSION=:VERSION");
            OracleParameter[] parameters = {
					new OracleParameter(":SYSNAME", OracleType.VarChar,30),
					new OracleParameter(":MOUDLENAME", OracleType.VarChar,30),
					new OracleParameter(":SYSLEVEL", OracleType.Number,4),
					new OracleParameter(":PARENT", OracleType.VarChar,30),
					new OracleParameter(":URL", OracleType.VarChar,256),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,256),
					new OracleParameter(":IMG", OracleType.VarChar,256),
                    new OracleParameter(":VERSION", OracleType.Number,4)};

            parameters[0].Value = model.SYSNAME;
            parameters[1].Value = model.MOUDLENAME;
            parameters[2].Value = model.SYSLEVEL;
            parameters[3].Value = model.PARENT;
            parameters[4].Value = model.URL;
            parameters[5].Value = model.DESCRIPTION;
            parameters[6].Value = model.IMG;
            parameters[7].Value = model.VERSION;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }

        public int AddNotall(Djdw.Model.Post.SYS_MENU model)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UpdateNotall(Djdw.Model.Post.SYS_MENU model)
        {
            throw new Exception("The method or operation is not implemented.");
        }


        public Djdw.Model.Post.SYS_MENU GetModel(int ID)
        {
            return GetModel(ID.ToString());
        }

        public DictionaryEntry AddSql(Djdw.Model.Post.SYS_MENU model)
        {
            model.ID=GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_MENU(");
            strSql.Append("ID,SYSNAME,MOUDLENAME,SYSLEVEL,PARENT,URL,DESCRIPTION,IMG,VERSION)");
            strSql.Append(" values (");
            strSql.Append(":ID,:SYSNAME,:MOUDLENAME,:SYSLEVEL,:PARENT,:URL,:DESCRIPTION,:IMG,:VERSION)");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.VarChar,30),
					new OracleParameter(":SYSNAME", OracleType.VarChar,30),
					new OracleParameter(":MOUDLENAME", OracleType.VarChar,30),
					new OracleParameter(":SYSLEVEL", OracleType.Number,4),
					new OracleParameter(":PARENT", OracleType.VarChar,30),
					new OracleParameter(":URL", OracleType.VarChar,256),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,256),
					new OracleParameter(":IMG", OracleType.VarChar,256),
                    new OracleParameter(":VERSION", OracleType.Number,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SYSNAME;
            parameters[2].Value = model.MOUDLENAME;
            parameters[3].Value = model.SYSLEVEL;
            parameters[4].Value = model.PARENT;
            parameters[5].Value = model.URL;
            parameters[6].Value = model.DESCRIPTION;
            parameters[7].Value = model.IMG;
            parameters[8].Value = model.VERSION;

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public DictionaryEntry DeleteSql(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SYS_MENU ");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.VarChar,30)
				};
            parameters[0].Value = ID;
            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int ExecuteTrans(Hashtable tb)
        {
            return DbHelperOra.ExecuteSqlTran(tb);
        }

        public int ExecuteSqlTranByArray(ArrayList SQLStringList)
        {
            return DbHelperOra.ExecuteSqlTranByArray(SQLStringList);
        }

        #endregion

        #region ISYS_MENU ��Ա


        public int Delete(int ID)
        {
            return Delete(ID.ToString());
        }

        #endregion
    }
}

