using System;
namespace Mis.Model.ptgl
{
	/// <summary>
	/// ʵ����SYS_ALGROUPMANS ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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

