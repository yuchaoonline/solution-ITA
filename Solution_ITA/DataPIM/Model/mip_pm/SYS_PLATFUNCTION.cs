using System;
namespace Mis.Model.ptgl
{
	/// <summary>
	/// ʵ����SYS_PLATFUNCTION ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class SYS_PLATFUNCTION
	{
		public SYS_PLATFUNCTION()
		{}
		#region Model
		private int _id;
		private string _sysname;
		private string _function;
		private int _isofrun;
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
		public string SYSNAME
		{
		set{ _sysname=value;}
		get{return _sysname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FUNCTION
		{
		set{ _function=value;}
		get{return _function;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ISOFRUN
		{
		set{ _isofrun=value;}
		get{return _isofrun;}
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

