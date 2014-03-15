using System;

namespace Djdw.Model.Post
{
	/// <summary>
	/// 实体类SYSVISIT_LOG 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SYSVISIT_LOG
	{
		public SYSVISIT_LOG()
		{}
		#region Model
		private int _id; // 编号
		private string _ip; // IP地址
		private string _dattim; // 访问时间
		private string _mac; // MAC地址
		private string _url; // 具体访问页面
		/// <summary>
		/// 编号
		/// </summary>
		public int ID
{
		    set{ _id=value;}
		    get{return _id;}
		}
		/// <summary>
		/// IP地址
		/// </summary>
		public string IP
		{
 		   set{ _ip=value;}
  		  get{return _ip;}
		}
		/// <summary>
		/// 访问时间
		/// </summary>
		public string DATTIM
		{
 		   set{ _dattim=value;}
  		  get{return _dattim;}
		}
		/// <summary>
		/// MAC地址
		/// </summary>
		public string MAC
		{
 		   set{ _mac=value;}
  		  get{return _mac;}
		}
		/// <summary>
		/// 具体访问页面
		/// </summary>
		public string URL
		{
 		   set{ _url=value;}
  		  get{return _url;}
		}
        #endregion Model
	}
}

