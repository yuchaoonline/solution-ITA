using System;
namespace Djdw.Model.Post
{
	/// <summary>
	/// 实体类SYS_MENU 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SYS_MENU
	{
		public SYS_MENU()
		{}
		#region Model
		private int _id; // 编号
		private string _sysname; // 系统名称
		private string _moudlename; // 模块名称
		private int _syslevel; // 级别
		private string _parent; // 上一级别模块
		private string _url; // url
		private string _description; // 描述
		private string _img; // 模块对应的图片url
		private int _version; // 颁本
		/// <summary>
		/// 编号
		/// </summary>
		public int ID
{
		    set{ _id=value;}
		    get{return _id;}
		}
		/// <summary>
		/// 系统名称
		/// </summary>
		public string SYSNAME
		{
 		   set{ _sysname=value;}
  		  get{return _sysname;}
		}
		/// <summary>
		/// 模块名称
		/// </summary>
		public string MOUDLENAME
		{
 		   set{ _moudlename=value;}
  		  get{return _moudlename;}
		}
		/// <summary>
		/// 级别
		/// </summary>
		public int SYSLEVEL
{
		    set{ _syslevel=value;}
		    get{return _syslevel;}
		}
		/// <summary>
		/// 上一级别模块
		/// </summary>
		public string PARENT
		{
 		   set{ _parent=value;}
  		  get{return _parent;}
		}
		/// <summary>
		/// url
		/// </summary>
		public string URL
		{
 		   set{ _url=value;}
  		  get{return _url;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string DESCRIPTION
		{
 		   set{ _description=value;}
  		  get{return _description;}
		}
		/// <summary>
		/// 模块对应的图片url
		/// </summary>
		public string IMG
		{
 		   set{ _img=value;}
  		  get{return _img;}
		}
		/// <summary>
		/// 颁本
		/// </summary>
		public int VERSION
{
		    set{ _version=value;}
		    get{return _version;}
		}
            		#endregion Model
	}
}

