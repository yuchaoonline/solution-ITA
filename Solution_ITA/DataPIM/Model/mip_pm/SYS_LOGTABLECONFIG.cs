using System;
namespace Mis.Model.ptgl
{
	/// <summary>
	/// ʵ����SYS_LOGTABLECONFIG ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class SYS_LOGTABLECONFIG
	{
		public SYS_LOGTABLECONFIG()
		{}
		#region Model
		private int _id;
		private int _logtype;
		private int _logsubtype;
		private string _tablename;
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
		public string TABLENAME
		{
		set{ _tablename=value;}
		get{return _tablename;}
		}
		#endregion Model

	}
}

