using System;
namespace Mis.Model.ptgl
{
	/// <summary>
	/// ʵ����SYS_SECLEVELIPCONFIG ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class SYS_SECLEVELIPCONFIG
	{
		public SYS_SECLEVELIPCONFIG()
		{}
		#region Model
		private int _id;
		private int _seclevelid;
		private string _bgip;
		private string _edip;
		private int _isallow;
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
		public int SECLEVELID
		{
		set{ _seclevelid=value;}
		get{return _seclevelid;}
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
		public int ISALLOW
		{
		set{ _isallow=value;}
		get{return _isallow;}
		}
		#endregion Model

	}
}

