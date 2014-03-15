using System;
using System.Data;

namespace DBUtility
{
	/// <summary>
	/// Configuration ��ժҪ˵����
	/// </summary>
	public class Configuration
	{
		/// <summary>
		/// ��ܵ����ݿ������ַ���
		/// </summary>

        static public string FRAMEWORK_DBServer_DB_STRING = "db";
        static public string FRAMEWORK_DBServer_USER_STRING = "user";
        static public string FRAMEWORK_DBServer_PWD_STRING = "pwd";


		public Configuration()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		/// <summary>
		/// ���ݼ�ֵ�������ļ���ȡ������ֵ
		/// </summary>
		/// <param name="key">��ֵ</param>
		/// <returns>����ֵ</returns>
		static public string GetConfigValue(string key)
		{
            /*	ini�ļ���ȡ	*/
            string strDir = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            iniClass ini = new iniClass(strDir + "\\config.ini");

			string ret = "";
			try
			{
                ret = ini.IniReadValue("DBServer", key);
			}
			catch(Exception e)
			{
				throw e;
			}

			return ret;	
		}

        /// <summary>
        /// ���ݼ�ֵ�������ļ���ȡ������ֵ
        /// </summary>
        /// <param name="key">��ֵ</param>
        /// <returns>����ֵ</returns>
        static public bool SetConfigValue(string key,string value)
        {
            /*	ini�ļ���ȡ	*/
            string strDir = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            iniClass ini = new iniClass(strDir + "\\config.ini");

            try
            {
                ini.IniWriteValue("DBServer", key, value);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {

            }
        }

		/// <summary>
		/// ��ȡ������õ����ݿ����ӣ������ӱ����ʹ��
		/// </summary>
		/// <returns>���ݿ�����</returns>
		static public string GetFrameworkConnection()
		{

            string framework_dbserver_db = GetConfigValue(Configuration.FRAMEWORK_DBServer_DB_STRING);
            string framework_dbserver_user = GetConfigValue(Configuration.FRAMEWORK_DBServer_USER_STRING);
            string framework_dbserver_pwd = GetConfigValue(Configuration.FRAMEWORK_DBServer_PWD_STRING);
            return "Data Source = " + framework_dbserver_db + "; User ID = " + framework_dbserver_user + "; Password = " + framework_dbserver_pwd + ";";
		}

        static public string GetParamConfigValue(string key)
        {
            /*	ini�ļ���ȡ	*/
            string strDir = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            iniClass ini = new iniClass(strDir + "\\config.ini");

            string ret = "";
            try
            {
                ret = ini.IniReadValue("SYSRunParam", key);
            }
            catch (Exception e)
            {
                throw e;
            }

            return ret;
        }

        static public int _GetSsdataSpanConfig()
        {
            try
            {
                string m_ssdataspan = GetParamConfigValue("ssdataspan");
                return int.Parse(m_ssdataspan);
            }
            catch (Exception e1)
            {
                return 10;
            }
            finally
            { 
            }
        }

        static public int _GetSsdbtmspanConfig()
        {
            try
            {
                string m_ssdbtmspan = GetParamConfigValue("dbtmspan");
                return int.Parse(m_ssdbtmspan);
            }
            catch (Exception e1)
            {
                return 20;
            }
            finally
            {
            }
        }

        static public int _GetAlarmspanConfig()
        {
            try
            {
                string m_alarmspan = GetParamConfigValue("alarmspan");
                return int.Parse(m_alarmspan);
            }
            catch (Exception e1)
            {
                return 180;
            }
            finally
            {
            }
        }
	}
}
