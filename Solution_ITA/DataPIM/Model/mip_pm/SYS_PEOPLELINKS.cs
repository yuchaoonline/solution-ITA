using System;
namespace Mis.Model.ptgl
{
	/// <summary>
	/// 实体类SYS_PEOPLELINKS 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SYS_PEOPLELINKS
	{
		public SYS_PEOPLELINKS()
		{}
		#region Model
		private int _id;
		private string _mobilephone1;
		private string _mobilephone2;
		private string _email;
		private string _msn;
		private string _qq;
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
		public string MOBILEPHONE1
		{
		set{ _mobilephone1=value;}
		get{return _mobilephone1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MOBILEPHONE2
		{
		set{ _mobilephone2=value;}
		get{return _mobilephone2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EMAIL
		{
		set{ _email=value;}
		get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MSN
		{
		set{ _msn=value;}
		get{return _msn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QQ
		{
		set{ _qq=value;}
		get{return _qq;}
		}
		#endregion Model

	}
}

