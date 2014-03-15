using System;
namespace Mis.Model.ptgl
{
	/// <summary>
	/// 实体类SYS_ALGROUPMANS 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SYS_ALGROUPMANS
	{
		public SYS_ALGROUPMANS()
		{}
		#region Model
		private int _id;
		private int _groupid;
		private int _userid;
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
		public int GROUPID
		{
		set{ _groupid=value;}
		get{return _groupid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int USERID
		{
		set{ _userid=value;}
		get{return _userid;}
		}
		#endregion Model

	}
}

