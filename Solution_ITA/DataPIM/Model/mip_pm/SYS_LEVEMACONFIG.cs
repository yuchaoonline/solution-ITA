using System;

namespace Mis.Model.ptgl
{
	/// <summary>
	/// ʵ����SYS_LEVEMACONFIG ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class SYS_LEVEMACONFIG
	{
		public SYS_LEVEMACONFIG()
		{}
		#region Model
		private int _id;
		private int _seclevelid;
		private int _moudleactionid;
		private int _style;
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
		public int MOUDLEACTIONID
		{
		set{ _moudleactionid=value;}
		get{return _moudleactionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int STYLE
		{
		set{ _style=value;}
		get{return _style;}
		}
		#endregion Model

	}
}

