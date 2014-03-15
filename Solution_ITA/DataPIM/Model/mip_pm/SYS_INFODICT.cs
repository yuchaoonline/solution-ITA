using System;
namespace Djdw.Model.Post
{
	/// <summary>
	/// 实体类SYS_INFODICT 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SYS_INFODICT
	{
		public SYS_INFODICT()
		{}
		#region Model
		private int _id; // 编号
		private string _infono; // 信息编号
		private string _infoname; // 信息名称
		private int _parentid; // 父类编号
		private string _description; // 描述
		private string _actionpeople; // 配置人
		private int _infolevel; // 信息等级
		/// <summary>
		/// 编号
		/// </summary>
		public int ID
{
		    set{ _id=value;}
		    get{return _id;}
		}
		/// <summary>
		/// 信息编号
		/// </summary>
		public string INFONO
		{
 		   set{ _infono=value;}
  		  get{return _infono;}
		}
		/// <summary>
		/// 信息名称
		/// </summary>
		public string INFONAME
		{
 		   set{ _infoname=value;}
  		  get{return _infoname;}
		}
		/// <summary>
		/// 父类编号
		/// </summary>
		public int PARENTID
{
		    set{ _parentid=value;}
		    get{return _parentid;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string DESCRIPTION
		{
 		   set{ _description=value;}
  		  get{return _description;}
		}
		/// <summary>
		/// 配置人
		/// </summary>
		public string ACTIONPEOPLE
		{
 		   set{ _actionpeople=value;}
  		  get{return _actionpeople;}
		}
		/// <summary>
		/// 信息等级
		/// </summary>
		public int INFOLEVEL
{
		    set{ _infolevel=value;}
		    get{return _infolevel;}
		}
            		#endregion Model
	}
}

