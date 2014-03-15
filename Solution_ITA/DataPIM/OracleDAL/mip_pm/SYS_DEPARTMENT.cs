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
	/// ���ݷ�����SYS_DEPARTMENT��
	/// </summary>
	public class SYS_DEPARTMENT:ISYS_DEPARTMENT
	{
		public SYS_DEPARTMENT()
		{}
        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOra.GetMaxID("ID", "SYS_DEPARTMENT");
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_DEPARTMENT");
            strSql.Append(" where ID= :ID");
            OracleParameter[] parameters = {
				new OracleParameter(":ID", OracleType.Number)
			};
            parameters[0].Value = ID;
            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
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
            return DbHelperOra.Exists(strSql.ToString());
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Mis.Model.ptgl.SYS_DEPARTMENT model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_DEPARTMENT(");
            strSql.Append("ID,DEPTNO,DEPTNAME,SYSLEVEL,PARENTID,DESCRIPTION)");
            strSql.Append(" values (");
            strSql.Append(":ID,:DEPTNO,:DEPTNAME,:SYSLEVEL,:PARENTID,:DESCRIPTION)");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,10),
					new OracleParameter(":DEPTNO", OracleType.VarChar,30),
					new OracleParameter(":DEPTNAME", OracleType.VarChar,30),
					new OracleParameter(":SYSLEVEL", OracleType.VarChar,30),
					new OracleParameter(":PARENTID", OracleType.Number,10),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,200)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.DEPTNO;
            parameters[2].Value = model.DEPTNAME;
            parameters[3].Value = model.SYSLEVEL;
            parameters[4].Value = model.PARENTID;
            parameters[5].Value = model.DESCRIPTION;

            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }

        /// <summary>
        /// ����������һ��model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public DictionaryEntry AddSql(Mis.Model.ptgl.SYS_DEPARTMENT model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_DEPARTMENT(");
            strSql.Append("ID,DEPTNO,DEPTNAME,SYSLEVEL,PARENTID,DESCRIPTION)");
            strSql.Append(" values (");
            strSql.Append("SEQSYS_DEPARTMENT.NEXTVAL,:DEPTNO,:DEPTNAME,:SYSLEVEL,:PARENTID,:DESCRIPTION)");
            OracleParameter[] parameters = {  
					new OracleParameter(":DEPTNO", OracleType.VarChar,30),
					new OracleParameter(":DEPTNAME", OracleType.VarChar,30),
					new OracleParameter(":SYSLEVEL", OracleType.VarChar,30),
					new OracleParameter(":PARENTID", OracleType.Number,10),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,200)};
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
            //�г������ı��ֶ�
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
            strSql.Append(":ID");
            //�г���Ӵ����ı��ֶ�value���� 
            if (model.DEPTNO != "")
            {
                strSql.Append(",:DEPTNO");
            }
            if (model.DEPTNAME != "")
            {
                strSql.Append(",:DEPTNAME");
            }
            if (model.SYSLEVEL != "")
            {
                strSql.Append(",:SYSLEVEL");
            }
            strSql.Append(",:PARENTID");
            if (model.DESCRIPTION != "")
            {
                strSql.Append(",:DESCRIPTION");
            }
            strSql.Append(" ) ");
            OracleParameter[] parameters = new OracleParameter[(Param_Num + 1)];
            parameters[0] = new OracleParameter(":ID", OracleType.Number, 4);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //�г���Ӵ����ı��ֶ�value����ľ���ֵ
            if (model.DEPTNO != "")
            {
                parameters[index_num] = new OracleParameter(":DEPTNO", OracleType.VarChar, 30);//���ű��
                parameters[index_num].Value = model.DEPTNO;
                index_num++;
            }
            if (model.DEPTNAME != "")
            {
                parameters[index_num] = new OracleParameter(":DEPTNAME", OracleType.VarChar, 30);//��������
                parameters[index_num].Value = model.DEPTNAME;
                index_num++;
            }
            if (model.SYSLEVEL != "")
            {
                parameters[index_num] = new OracleParameter(":SYSLEVEL", OracleType.VarChar, 30);//����
                parameters[index_num].Value = model.SYSLEVEL;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":PARENTID", OracleType.VarChar, 10);//��һ��������id
                parameters[index_num].Value = model.PARENTID;
                index_num++;
            }
            if (model.DESCRIPTION != "")
            {
                parameters[index_num] = new OracleParameter(":DESCRIPTION", OracleType.VarChar, 200);//����
                parameters[index_num].Value = model.DESCRIPTION;
                index_num++;
            }
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters); return model.ID;
        } /// <summary>
        /// �Ƿ���ڸü�¼(model)
        /// </summary>
        public bool Existsmodel(Mis.Model.ptgl.SYS_DEPARTMENT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_DEPARTMENT");
            strSql.Append(" where  DEPTNO=:DEPTNO and DEPTNAME=:DEPTNAME and SYSLEVEL=:SYSLEVEL and PARENTID=:PARENTID and DESCRIPTION=:DESCRIPTION");
            OracleParameter[] parameters = {  
					new OracleParameter(":DEPTNO", OracleType.VarChar,30),
					new OracleParameter(":DEPTNAME", OracleType.VarChar,30),
					new OracleParameter(":SYSLEVEL", OracleType.VarChar,30),
					new OracleParameter(":PARENTID", OracleType.Number,10),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,200)};
            parameters[0].Value = model.DEPTNO;
            parameters[1].Value = model.DEPTNAME;
            parameters[2].Value = model.SYSLEVEL;
            parameters[3].Value = model.PARENTID;
            parameters[4].Value = model.DESCRIPTION;

            return false;
        }

        public int UpdateNotall(Mis.Model.ptgl.SYS_DEPARTMENT model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_DEPARTMENT(");
            strSql.Append("ID");
            //�г���Ӵ����ı��ֶ�
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
            strSql.Append(":ID");
            //�г���Ӵ����ı��ֶ�value���� 
            if (model.DEPTNO != "")
            {
                strSql.Append(",:DEPTNO");
            }
            if (model.DEPTNAME != "")
            {
                strSql.Append(",:DEPTNAME");
            }
            if (model.SYSLEVEL != "")
            {
                strSql.Append(",:SYSLEVEL");
            }
            strSql.Append(",:PARENTID");
            if (model.DESCRIPTION != "")
            {
                strSql.Append(",:DESCRIPTION");
            }
            strSql.Append(" ) ");
            OracleParameter[] parameters = new OracleParameter[(Param_Num + 1)];
            parameters[0] = new OracleParameter(":ID", OracleType.Number, 4);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //�г���Ӵ����ı��ֶ�value����ľ���ֵ
            if (model.DEPTNO != "")
            {
                parameters[index_num] = new OracleParameter(":DEPTNO", OracleType.VarChar, 30);//���ű��
                parameters[index_num].Value = model.DEPTNO;
                index_num++;
            }
            if (model.DEPTNAME != "")
            {
                parameters[index_num] = new OracleParameter(":DEPTNAME", OracleType.VarChar, 30);//��������
                parameters[index_num].Value = model.DEPTNAME;
                index_num++;
            }
            if (model.SYSLEVEL != "")
            {
                parameters[index_num] = new OracleParameter(":SYSLEVEL", OracleType.VarChar, 30);//����
                parameters[index_num].Value = model.SYSLEVEL;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":PARENTID", OracleType.VarChar, 10);//��һ��������id
                parameters[index_num].Value = model.PARENTID;
                index_num++;
            }
            if (model.DESCRIPTION != "")
            {
                parameters[index_num] = new OracleParameter(":DESCRIPTION", OracleType.VarChar, 200);//����
                parameters[index_num].Value = model.DESCRIPTION;
                index_num++;
            }
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Mis.Model.ptgl.SYS_DEPARTMENT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_DEPARTMENT set ");
            strSql.Append("DEPTNO=:DEPTNO,");
            strSql.Append("DEPTNAME=:DEPTNAME,");
            strSql.Append("SYSLEVEL=:SYSLEVEL,");
            strSql.Append("PARENTID=:PARENTID,");
            strSql.Append("DESCRIPTION=:DESCRIPTION");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,10),
					new OracleParameter(":DEPTNO", OracleType.VarChar,30),
					new OracleParameter(":DEPTNAME", OracleType.VarChar,30),
					new OracleParameter(":SYSLEVEL", OracleType.VarChar,30),
					new OracleParameter(":PARENTID", OracleType.Number,10),
					new OracleParameter(":DESCRIPTION", OracleType.VarChar,200)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.DEPTNO;
            parameters[2].Value = model.DEPTNAME;
            parameters[3].Value = model.SYSLEVEL;
            parameters[4].Value = model.PARENTID;
            parameters[5].Value = model.DESCRIPTION;

            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SYS_DEPARTMENT ");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
				new OracleParameter(":ID", OracleType.Number)
			};
            parameters[0].Value = ID;
            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ������ɾ�� (int ID)
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DictionaryEntry DeleteSql(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_DEPARTMENT ");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
				new OracleParameter(":ID", OracleType.Number)
			};
            parameters[0].Value = ID;
            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        /// <summary>
        /// ������Hashtable
        /// </summary>
        /// <param name="tb">Hashtable</param>
        /// <returns>int</returns>
        public int ExecuteTrans(Hashtable tb)
        {
            return DbHelperOra.ExecuteSqlTran(tb);
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="SQLStringList">ArrayList</param>
        /// <returns>int</returns>
        public int ExecuteSqlTranByArray(ArrayList SQLStringList)
        {
            return DbHelperOra.ExecuteSqlTranByArray(SQLStringList);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Mis.Model.ptgl.SYS_DEPARTMENT GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_DEPARTMENT ");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
   				new OracleParameter(":ID", OracleType.Number)};
            parameters[0].Value = ID;
            Mis.Model.ptgl.SYS_DEPARTMENT model = new Mis.Model.ptgl.SYS_DEPARTMENT();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
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
        /// ��������б�
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
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion  ��Ա����

	}
}

