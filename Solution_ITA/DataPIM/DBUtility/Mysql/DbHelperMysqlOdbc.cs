using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Data.SqlClient;
using System.Xml;

namespace DBUtility //�޸ĳ�ʵ����Ŀ�������ռ�����
{
    /// <summary>
    /// ���ݷ��ʻ�����(����Odbc)
    /// �����û������޸������Լ���Ŀ����Ҫ��
    /// </summary>
    public abstract class DbHelperMysqlOdbc
    {
        //���ݿ������ַ���(web.config������)
        //<add key="ConnectionString" value="server=127.0.0.1;database=DATABASE;uid=sa;pwd=" />		
        protected static string connectionString = ConfigurationSettings.AppSettings["MysqlOdbcConnection"];

        public DbHelperMysqlOdbc()
        {

        }

        public static string _Getconnectionstring()
        {
            return connectionString;
        }
        #region ���÷���

        public static int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        public static bool Exists(string strSql, params OdbcParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region  ִ�м�SQL���

        /// <summary>
        /// ִ��SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSql(string SQLString)
        {
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                using (OdbcCommand cmd = new OdbcCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.Odbc.OdbcException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="SQLStringList">����SQL���</param>		
        public static int ExecuteSqlTran(ArrayList SQLStringList)
        {
            using (OdbcConnection conn = new OdbcConnection(connectionString))
            {
                conn.Open();
                OdbcCommand cmd = new OdbcCommand();
                cmd.Connection = conn;
                OdbcTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return 1;
                }
                catch (System.Data.Odbc.OdbcException E)
                {
                    tx.Rollback();
                    //throw new Exception(E.Message);
                    return -1;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
            return -1;
        }

        /// <summary>
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="SQLStringList">����SQL���</param>		
        public static int ExecuteSqlTranByArray(ArrayList SQLStringList)
        {
            using (OdbcConnection conn = new OdbcConnection(connectionString))
            {
                conn.Open();
                OdbcCommand cmd = new OdbcCommand();
                cmd.Connection = conn;
                OdbcTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return 1;
                }
                catch (System.Data.Odbc.OdbcException E)
                {
                    tx.Rollback();
                    //throw new Exception(E.Message);
                    return -1;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
            return -1;
        }

        public static int ExecuteSqlTranByArray2(ArrayList SQLStringList)
        {
            try
            {
                using (OdbcConnection conn = new OdbcConnection(connectionString))
                {
                    conn.Open();
                    using (OdbcTransaction trans = conn.BeginTransaction())
                    {
                        OdbcCommand cmd = new OdbcCommand();
                        try
                        {
                            //ѭ��
                            foreach (DictionaryEntry myDE in SQLStringList)
                            {
                                string cmdText = myDE.Key.ToString();
                                OdbcParameter[] cmdParms = (OdbcParameter[])myDE.Value;
                                PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                                int val = cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();

                            }

                            trans.Commit();
                            return 1;
                        }
                        catch (Exception e1)
                        {
                            Console.WriteLine(e1.Message);
                            trans.Rollback();
                            return -1;
                        }
                        finally
                        {
                            cmd.Dispose();
                            conn.Close();

                        }
                    }
                }
                return -1;
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
                return -1;
            }
            finally
            {
 
            }
        }


        public static int ExecuteMemSqlTranByArray(ArrayList SQLStringList,ref string p_retidstr)
        {
            using (OdbcConnection conn = new OdbcConnection(connectionString))
            {
                conn.Open();
                using (OdbcTransaction trans = conn.BeginTransaction())
                {
                    OdbcCommand cmd = new OdbcCommand();
                    string p_idstr = "";
                    try
                    {
                        //ѭ��
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            OdbcParameter[] cmdParms = (OdbcParameter[])myDE.Value;
                            p_idstr = cmdParms[1].Value.ToString();
                            //Console.WriteLine(p_idstr);
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();

                        }

                        trans.Commit();
                        return 1;
                    }
                    catch (Exception e1)
                    {
                        p_retidstr = p_idstr;
                        Console.WriteLine(e1.Message);
                        trans.Rollback();
                        return -1;
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Close();

                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// ִ�д�һ���洢���̲����ĵ�SQL��䡣
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <param name="content">��������,����һ���ֶ��Ǹ�ʽ���ӵ����£���������ţ�����ͨ�������ʽ���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSql(string SQLString, string content)
        {
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                OdbcCommand cmd = new OdbcCommand(SQLString, connection);
                System.Data.Odbc.OdbcParameter myParameter = new System.Data.Odbc.OdbcParameter("@content", OdbcType.VarChar);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.Odbc.OdbcException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// �����ݿ������ͼ���ʽ���ֶ�(������������Ƶ���һ��ʵ��)
        /// </summary>
        /// <param name="strSQL">SQL���</param>
        /// <param name="fs">ͼ���ֽ�,���ݿ���ֶ�����Ϊimage�����</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                OdbcCommand cmd = new OdbcCommand(strSQL, connection);
                System.Data.Odbc.OdbcParameter myParameter = new System.Data.Odbc.OdbcParameter("@fs", OdbcType.Binary);
                myParameter.Value = fs;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.Odbc.OdbcException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
        /// </summary>
        /// <param name="SQLString">�����ѯ������</param>
        /// <returns>��ѯ�����object��</returns>
        public static object GetSingle(string SQLString)
        {
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                using (OdbcCommand cmd = new OdbcCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.Odbc.OdbcException e)
                    {
                        cmd.Dispose();
                        connection.Close();
                        return null;
                        //throw new Exception(e.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }
        /// <summary>
        /// ִ�в�ѯ��䣬����OdbcDataReader
        /// </summary>
        /// <param name="strSQL">��ѯ���</param>
        /// <returns>OdbcDataReader</returns>
        public static OdbcDataReader ExecuteReader(string strSQL)
        {
            OdbcConnection connection = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand(strSQL, connection);
            try
            {
                connection.Open();
                OdbcDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (System.Data.Odbc.OdbcException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }

        }
        /// <summary>
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="SQLString">��ѯ���</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            try
            {
                using (OdbcConnection connection = new OdbcConnection(_Getconnectionstring()))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        connection.Open();
                        OdbcDataAdapter command = new OdbcDataAdapter(SQLString, connection);
                        command.Fill(ds);
                        connection.Close();
                        return ds;
                    }
                    catch (System.Data.Odbc.OdbcException ex)
                    {
                        connection.Close();
                        throw new Exception(ex.Message);
                        return null;
                    }
                    finally
                    {
                        connection.Close();
                    }
                    
                }
            }
            catch (System.Data.Odbc.OdbcException ex)
            {
                return null;
            }
        }


        #endregion

        #region ִ�д�������SQL���

        /// <summary>
        /// ִ��SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSql(string SQLString, params OdbcParameter[] cmdParms)
        {
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                using (OdbcCommand cmd = new OdbcCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.Odbc.OdbcException E)
                    {
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }


        /// <summary>
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="SQLStringList">SQL���Ĺ�ϣ��keyΪsql��䣬value�Ǹ�����OdbcParameter[]��</param>
        public static int ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (OdbcConnection conn = new OdbcConnection(connectionString))
            {
                conn.Open();
                using (OdbcTransaction trans = conn.BeginTransaction())
                {
                    OdbcCommand cmd = new OdbcCommand();
                    try
                    {
                        //ѭ��
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            OdbcParameter[] cmdParms = (OdbcParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            
                        }
                        
                        trans.Commit();
                        return 1;
                    }
                    catch
                    {
                        trans.Rollback();
                        return -1;
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Close();
                        
                    }
                }
            }
            return -1;
        }


        /// <summary>
        /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
        /// </summary>
        /// <param name="SQLString">�����ѯ������</param>
        /// <returns>��ѯ�����object��</returns>
        public static object GetSingle(string SQLString, params OdbcParameter[] cmdParms)
        {
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                using (OdbcCommand cmd = new OdbcCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.Odbc.OdbcException e)
                    {
                        throw new Exception(e.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// ִ�в�ѯ��䣬����OdbcDataReader
        /// </summary>
        /// <param name="strSQL">��ѯ���</param>
        /// <returns>OdbcDataReader</returns>
        public static OdbcDataReader ExecuteReader(string SQLString, params OdbcParameter[] cmdParms)
        {
            OdbcConnection connection = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                OdbcDataReader myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.Odbc.OdbcException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }

        }

        /// <summary>
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="SQLString">��ѯ���</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, params OdbcParameter[] cmdParms)
        {
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                OdbcCommand cmd = new OdbcCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                        return ds;
                    }
                    catch (System.Data.Odbc.OdbcException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                    
                }

            }
        }


        private static void PrepareCommand(OdbcCommand cmd, OdbcConnection conn, OdbcTransaction trans, string cmdText, OdbcParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (OdbcParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        #endregion

        #region �洢���̲���

        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>OdbcDataReader</returns>
        public static OdbcDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            OdbcConnection connection = new OdbcConnection(connectionString);
            OdbcDataReader returnReader;
            connection.Open();
            OdbcCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader();
            return returnReader;
        }


        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <param name="tableName">DataSet����еı���</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                OdbcDataAdapter sqlDA = new OdbcDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }


        /// <summary>
        /// ���� OdbcCommand ����(��������һ���������������һ������ֵ)
        /// </summary>
        /// <param name="connection">���ݿ�����</param>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>OdbcCommand</returns>
        private static OdbcCommand BuildQueryCommand(OdbcConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            OdbcCommand command = new OdbcCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (OdbcParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }

        /// <summary>
        /// ִ�д洢���̣�����Ӱ�������		
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <param name="rowsAffected">Ӱ�������</param>
        /// <returns></returns>
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                int result;
                connection.Open();
                OdbcCommand command = BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;
                //Connection.Close();
                return result;
            }
        }

        /// <summary>
        /// ���� OdbcCommand ����ʵ��(��������һ������ֵ)	
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>OdbcCommand ����ʵ��</returns>
        private static OdbcCommand BuildIntCommand(OdbcConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            OdbcCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new OdbcParameter("ReturnValue",
                OdbcType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        #endregion

    }
}
