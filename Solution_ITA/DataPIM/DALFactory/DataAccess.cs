using System;
using System.Reflection;
using System.Configuration;
using hbapp.IDAL.ghdata;
using Mis.IDAL.Post;

namespace Mis.DALFactory.ptgl
{
	/// <summary>
	/// ���󹤳�ģʽ����DAL��
	/// web.config ��Ҫ�������ã�(���ù���ģʽ+�������+�������,ʵ�ֶ�̬������ͬ�����ݲ����ӿ�)  
	/// DataCache���ڵ���������ļ�����
	/// ���԰�����DAL��Ĵ����������DataAccess����
	/// <appSettings>  
	/// <add key="DAL" value="SQLServerDAL" /> (����������ռ����ʵ���������Ϊ�Լ���Ŀ�������ռ�)
	/// </appSettings> 
	/// </summary>
	public sealed class DataAccess
	{
        private static readonly string path = System.Configuration.ConfigurationSettings.AppSettings["CARDAL"];

        private static readonly string pmpath = System.Configuration.ConfigurationSettings.AppSettings["MIPDAL"];

        private static readonly string scsoftpath = System.Configuration.ConfigurationSettings.AppSettings["scsoftDAL"];

        private static readonly string xfsoftpath = System.Configuration.ConfigurationSettings.AppSettings["xfsoftDAL"];
        /// <summary>
		/// ���������ӻ����ȡ
		/// </summary>
		public static object CreateObject(string path,string CacheKey)
		{
			object objType = DataCache.GetCache(CacheKey);//�ӻ����ȡ
			if (objType == null)
			{
				try
				{
                    objType = Assembly.Load(path).CreateInstance(CacheKey);//���䴴��
					DataCache.SetCache(CacheKey, objType);// д�뻺��
				}
				catch
				{}
			}
			return objType;
        }


        #region ҵ���������ݽӿ�

        /// <summary>
        /// ����GH_TASKINFO���ݲ�ӿ�
        /// </summary>
        public static hbapp.IDAL.ghdata.IGH_TASKINFO CreateGH_TASKINFO()
        {
            string CacheKey = scsoftpath + ".ghdata.GH_TASKINFO";
            object objType = CreateObject(path, CacheKey);
            return (IGH_TASKINFO)objType;
        }


    

        #endregion


        #region ƽ̨�������ݽӿڹ���


        /// <summary>
        /// ����SYS_MOUDLEACTION���ݲ�ӿ�
        /// </summary>
        public static Mis.IDAL.Post.ISYS_MOUDLEACTION CreateSYS_MOUDLEACTION()
        {
            string CacheKey = pmpath + ".Post.SYS_MOUDLEACTION";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_MOUDLEACTION)objType;
        }



        /// <summary>
        /// ����SYS_DEPARTMENT���ݲ�ӿ�
        /// </summary>
        public static Mis.IDAL.Post.ISYS_DEPARTMENT CreateSYS_DEPARTMENT()
        {
            string CacheKey = pmpath + ".Post.SYS_DEPARTMENT";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_DEPARTMENT)objType;
        }



        /// <summary>
        /// ����SYS_USERS���ݲ�ӿ�
        /// </summary>
        public static Mis.IDAL.Post.ISYS_USERS CreateSYS_USERS()
        {
            string CacheKey = pmpath + ".Post.SYS_USERS";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_USERS)objType;
        }



        /// <summary>
        /// ����SYS_ROLES���ݲ�ӿ�
        /// </summary>
        public static Mis.IDAL.Post.ISYS_ROLES CreateSYS_ROLES()
        {
            string CacheKey = pmpath + ".Post.SYS_ROLES";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_ROLES)objType;
        }



        /// <summary>
        /// ����SYS_ROLEUSER���ݲ�ӿ�
        /// </summary>
        public static Mis.IDAL.Post.ISYS_ROLEUSER CreateSYS_ROLEUSER()
        {
            string CacheKey = pmpath + ".Post.SYS_ROLEUSER";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_ROLEUSER)objType;
        }



        /// <summary>
        /// ����SYS_ROLEACTRIGHTS���ݲ�ӿ�
        /// </summary>
        public static Mis.IDAL.Post.ISYS_ROLEACTRIGHTS CreateSYS_ROLEACTRIGHTS()
        {
            string CacheKey = pmpath + ".Post.SYS_ROLEACTRIGHTS";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_ROLEACTRIGHTS)objType;
        }



        /// <summary>
        /// ����SYS_ROLEPLMENUSRIGHTS���ݲ�ӿ�
        /// </summary>
        public static Mis.IDAL.Post.ISYS_ROLEPLMENUSRIGHTS CreateSYS_ROLEPLMENUSRIGHTS()
        {
            string CacheKey = pmpath + ".Post.SYS_ROLEPLMENUSRIGHTS";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_ROLEPLMENUSRIGHTS)objType;
        }





        /// <summary>
        /// ����SYS_INFODICT���ݲ�ӿ�
        /// </summary>
        public static Mis.IDAL.Post.ISYS_INFODICT CreateSYS_INFODICT()
        {
            string CacheKey = pmpath + ".Post.SYS_INFODICT";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_INFODICT)objType;
        }



        /// <summary>
        /// ����SYS_MENU���ݲ�ӿ�
        /// </summary>
        public static Mis.IDAL.Post.ISYS_MENU CreateSYS_MENU()
        {
            string CacheKey = pmpath + ".Post.SYS_MENU";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_MENU)objType;
        }


        /// <summary>
        /// ����SYS_OPLOG���ݲ�ӿ�
        /// </summary>
        public static Mis.IDAL.Post.ISYS_OPLOG CreateSYS_OPLOG()
        {
            string CacheKey = pmpath + ".Post.SYS_OPLOG";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_OPLOG)objType;
        }

        /// <summary>
        /// ����SYS_MAILRUN���ݲ�ӿ�
        /// </summary>
        public static Mis.IDAL.Post.ISYS_MAILRUN CreateSYS_MAILRUN()
        {
            string CacheKey = pmpath + ".Post.SYS_MAILRUN";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_MAILRUN)objType;
        }

        /// <summary>
        /// ����SYSVISIT_LOG���ݲ�ӿ�
        /// </summary>
        public static Mis.IDAL.Post.ISYSVISIT_LOG CreateSYSVISIT_LOG()
        {
            string CacheKey = pmpath + ".Post.SYSVISIT_LOG";
            object objType = CreateObject(path, CacheKey);
            return (ISYSVISIT_LOG)objType;
        }

        #endregion 

    }
}

