using System;

namespace Mis.Model.ptgl
{
	/// <summary>
	/// 实体类SYS_ACCESS_ACTIONUKEYS 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SYS_ACCESS_ACTIONUKEYS
	{
		public SYS_ACCESS_ACTIONUKEYS()
		{}
		#region Model
		private int _id;
		private int _userid;
		private int _ukeyid;
		private int _actionid;
		private int _isofallow;
		private string _description;
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
		public int USERID
		{
		set{ _userid=value;}
		get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UKEYID
		{
		set{ _ukeyid=value;}
		get{return _ukeyid;}
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
		public int ISOFALLOW
		{
		set{ _isofallow=value;}
		get{return _isofallow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DESCRIPTION
		{
		set{ _description=value;}
		get{return _description;}
		}
		#endregion Model

	}
}

