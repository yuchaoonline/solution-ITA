using System;
namespace Mis.Model.ptgl
{
	/// <summary>
	/// 实体类SYS_SMSALARMINFO 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SYS_SMSALARMINFO
	{
		public SYS_SMSALARMINFO()
		{}
		#region Model
		private int _id;
		private int _alarminfotype;
		private string _alarmtime;
		private string _alarmtele;
		private string _alarmtext;
		private string _retele;
		private string _retext;
		private int _isok;
		private int _procman;
		private int _sms_id;
		private string _sms_time;
		private string _sms_state;
		private string _sms_subseq;
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
		public int ALARMINFOTYPE
		{
		set{ _alarminfotype=value;}
		get{return _alarminfotype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ALARMTIME
		{
		set{ _alarmtime=value;}
		get{return _alarmtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ALARMTELE
		{
		set{ _alarmtele=value;}
		get{return _alarmtele;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ALARMTEXT
		{
		set{ _alarmtext=value;}
		get{return _alarmtext;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RETELE
		{
		set{ _retele=value;}
		get{return _retele;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RETEXT
		{
		set{ _retext=value;}
		get{return _retext;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ISOK
		{
		set{ _isok=value;}
		get{return _isok;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PROCMAN
		{
		set{ _procman=value;}
		get{return _procman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SMS_ID
		{
		set{ _sms_id=value;}
		get{return _sms_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SMS_TIME
		{
		set{ _sms_time=value;}
		get{return _sms_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SMS_STATE
		{
		set{ _sms_state=value;}
		get{return _sms_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SMS_SUBSEQ
		{
		set{ _sms_subseq=value;}
		get{return _sms_subseq;}
		}
		#endregion Model

	}
}

