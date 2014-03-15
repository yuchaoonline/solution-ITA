using System;
namespace Mis.Model.ptgl
{
	/// <summary>
	/// 实体类SYS_ACCESS_IP 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SYS_ACCESS_IP
	{
		public SYS_ACCESS_IP()
		{}
		#region Model
		private int _id;
		private string _bgip;
		private string _edip;
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
		public string BGIP
		{
		set{ _bgip=value;}
		get{return _bgip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EDIP
		{
		set{ _edip=value;}
		get{return _edip;}
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

