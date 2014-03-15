using System;
namespace Mis.Model.ptgl
{
	/// <summary>
	/// 实体类SYS_ALARMGROUP 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SYS_ALARMGROUP
	{
		public SYS_ALARMGROUP()
		{}
		#region Model
		private int _id;
		private string _groupno;
		private string _groupname;
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
		public string GROUPNO
		{
		set{ _groupno=value;}
		get{return _groupno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GROUPNAME
		{
		set{ _groupname=value;}
		get{return _groupname;}
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

