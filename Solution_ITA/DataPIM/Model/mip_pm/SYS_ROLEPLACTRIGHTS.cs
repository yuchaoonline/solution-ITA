using System;
namespace Mis.Model.ptgl
{
	/// <summary>
	/// ʵ����SYS_ROLEPLACTRIGHTS ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class SYS_ROLEPLACTRIGHTS
	{
		public SYS_ROLEPLACTRIGHTS()
		{}
		#region Model
		private int _id;
		private int _roleplid;
		private int _actionid;
		private int _isofallow;
		private int _type;
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
		public int ROLEPLID
		{
		set{ _roleplid=value;}
		get{return _roleplid;}
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
		public int TYPE
		{
		set{ _type=value;}
		get{return _type;}
		}
		#endregion Model

	}
}

