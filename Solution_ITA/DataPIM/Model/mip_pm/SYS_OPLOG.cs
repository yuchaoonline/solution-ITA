using System;
namespace gtled.Model.Post
{
	/// <summary>
	/// 实体类SYS_OPLOG 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SYS_OPLOG
	{
		public SYS_OPLOG()
		{}
		#region Model
		private int _id; // 编号
		private string _userid; // 用户编号
		private string _username; // 用户真实姓名
		private string _optype; // 操作种类
		private string _optime; // 操作时间
		private string _remark; // 备注
		private string _remark1; // 备注1
		/// <summary>
		/// 编号
		/// </summary>
		public int ID
{
		    set{ _id=value;}
		    get{return _id;}
		}
		/// <summary>
		/// 用户编号
		/// </summary>
		public string USERID
		{
 		   set{ _userid=value;}
  		  get{return _userid;}
		}
		/// <summary>
		/// 用户真实姓名
		/// </summary>
		public string USERNAME
		{
 		   set{ _username=value;}
  		  get{return _username;}
		}
		/// <summary>
		/// 操作种类
		/// </summary>
		public string OPTYPE
		{
 		   set{ _optype=value;}
  		  get{return _optype;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public string OPTIME
		{
 		   set{ _optime=value;}
  		  get{return _optime;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string REMARK
		{
 		   set{ _remark=value;}
  		  get{return _remark;}
		}
		/// <summary>
		/// 备注1
		/// </summary>
		public string REMARK1
		{
 		   set{ _remark1=value;}
  		  get{return _remark1;}
		}
            		#endregion Model
	}
}

