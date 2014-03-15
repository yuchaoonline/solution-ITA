using System;
using System.Reflection;
using System.Configuration;
using hbapp.IDAL.ghdata;
using Mis.IDAL.Post;

namespace Mis.DALFactory.ptgl
{
	/// <summary>
	/// 抽象工厂模式创建DAL。
	/// web.config 需要加入配置：(利用工厂模式+反射机制+缓存机制,实现动态创建不同的数据层对象接口)  
	/// DataCache类在导出代码的文件夹里
	/// 可以把所有DAL类的创建放在这个DataAccess类里
	/// <appSettings>  
	/// <add key="DAL" value="SQLServerDAL" /> (这里的命名空间根据实际情况更改为自己项目的命名空间)
	/// </appSettings> 
	/// </summary>
	public sealed class DataAccess
	{
        private static readonly string path = System.Configuration.ConfigurationSettings.AppSettings["CARDAL"];

        private static readonly string pmpath = System.Configuration.ConfigurationSettings.AppSettings["MIPDAL"];

        private static readonly string scsoftpath = System.Configuration.ConfigurationSettings.AppSettings["scsoftDAL"];

        private static readonly string xfsoftpath = System.Configuration.ConfigurationSettings.AppSettings["xfsoftDAL"];
        /// <summary>
		/// 创建对象或从缓存获取
		/// </summary>
		public static object CreateObject(string path,string CacheKey)
		{
			object objType = DataCache.GetCache(CacheKey);//从缓存读取
			if (objType == null)
			{
				try
				{
                    objType = Assembly.Load(path).CreateInstance(CacheKey);//反射创建
					DataCache.SetCache(CacheKey, objType);// 写入缓存
				}
				catch
				{}
			}
			return objType;
        }


        #region 业务层软件数据接口

        /// <summary>
        /// 创建GH_TASKINFO数据层接口
        /// </summary>
        public static hbapp.IDAL.ghdata.IGH_TASKINFO CreateGH_TASKINFO()
        {
            string CacheKey = scsoftpath + ".ghdata.GH_TASKINFO";
            object objType = CreateObject(path, CacheKey);
            return (IGH_TASKINFO)objType;
        }


    

        #endregion


        #region 平台管理数据接口工厂


        /// <summary>
        /// 创建SYS_MOUDLEACTION数据层接口
        /// </summary>
        public static Mis.IDAL.Post.ISYS_MOUDLEACTION CreateSYS_MOUDLEACTION()
        {
            string CacheKey = pmpath + ".Post.SYS_MOUDLEACTION";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_MOUDLEACTION)objType;
        }



        /// <summary>
        /// 创建SYS_DEPARTMENT数据层接口
        /// </summary>
        public static Mis.IDAL.Post.ISYS_DEPARTMENT CreateSYS_DEPARTMENT()
        {
            string CacheKey = pmpath + ".Post.SYS_DEPARTMENT";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_DEPARTMENT)objType;
        }



        /// <summary>
        /// 创建SYS_USERS数据层接口
        /// </summary>
        public static Mis.IDAL.Post.ISYS_USERS CreateSYS_USERS()
        {
            string CacheKey = pmpath + ".Post.SYS_USERS";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_USERS)objType;
        }



        /// <summary>
        /// 创建SYS_ROLES数据层接口
        /// </summary>
        public static Mis.IDAL.Post.ISYS_ROLES CreateSYS_ROLES()
        {
            string CacheKey = pmpath + ".Post.SYS_ROLES";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_ROLES)objType;
        }



        /// <summary>
        /// 创建SYS_ROLEUSER数据层接口
        /// </summary>
        public static Mis.IDAL.Post.ISYS_ROLEUSER CreateSYS_ROLEUSER()
        {
            string CacheKey = pmpath + ".Post.SYS_ROLEUSER";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_ROLEUSER)objType;
        }



        /// <summary>
        /// 创建SYS_ROLEACTRIGHTS数据层接口
        /// </summary>
        public static Mis.IDAL.Post.ISYS_ROLEACTRIGHTS CreateSYS_ROLEACTRIGHTS()
        {
            string CacheKey = pmpath + ".Post.SYS_ROLEACTRIGHTS";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_ROLEACTRIGHTS)objType;
        }



        /// <summary>
        /// 创建SYS_ROLEPLMENUSRIGHTS数据层接口
        /// </summary>
        public static Mis.IDAL.Post.ISYS_ROLEPLMENUSRIGHTS CreateSYS_ROLEPLMENUSRIGHTS()
        {
            string CacheKey = pmpath + ".Post.SYS_ROLEPLMENUSRIGHTS";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_ROLEPLMENUSRIGHTS)objType;
        }





        /// <summary>
        /// 创建SYS_INFODICT数据层接口
        /// </summary>
        public static Mis.IDAL.Post.ISYS_INFODICT CreateSYS_INFODICT()
        {
            string CacheKey = pmpath + ".Post.SYS_INFODICT";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_INFODICT)objType;
        }



        /// <summary>
        /// 创建SYS_MENU数据层接口
        /// </summary>
        public static Mis.IDAL.Post.ISYS_MENU CreateSYS_MENU()
        {
            string CacheKey = pmpath + ".Post.SYS_MENU";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_MENU)objType;
        }


        /// <summary>
        /// 创建SYS_OPLOG数据层接口
        /// </summary>
        public static Mis.IDAL.Post.ISYS_OPLOG CreateSYS_OPLOG()
        {
            string CacheKey = pmpath + ".Post.SYS_OPLOG";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_OPLOG)objType;
        }

        /// <summary>
        /// 创建SYS_MAILRUN数据层接口
        /// </summary>
        public static Mis.IDAL.Post.ISYS_MAILRUN CreateSYS_MAILRUN()
        {
            string CacheKey = pmpath + ".Post.SYS_MAILRUN";
            object objType = CreateObject(path, CacheKey);
            return (ISYS_MAILRUN)objType;
        }

        /// <summary>
        /// 创建SYSVISIT_LOG数据层接口
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

