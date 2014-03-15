using System;
namespace Mis.Model.ptgl
{
	/// <summary>
	/// 实体类SYS_LOG 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SYS_LOG
	{
		public SYS_LOG()
		{}
		#region Model
		private int _id;
		private int _logtype;
		private int _logsubtype;
		private int _actionid;
		private int _userid;
		private string _actiontime;
		private string _loginfo;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
		set{ _id=value;}
		get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int LOGTYPE
		{
		set{ _logtype=value;}
		get{return _logtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int LOGSUBTYPE
		{
		set{ _logsubtype=value;}
		get{return _logsubtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ACTIONID
		{
		set{ _actionid=value;}
		get{return _actionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int USERID
		{
		set{ _userid=value;}
		get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ACTIONTIME
		{
		set{ _actiontime=value;}
		get{return _actiontime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LOGINFO
		{
		set{ _loginfo=value;}
		get{return _loginfo;}
		}
		#endregion Model

	}
}

