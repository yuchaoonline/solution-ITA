using System;
namespace Mis.Model.ptgl
{
	/// <summary>
	/// 实体类SYS_ROLEUSER 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SYS_ROLEUSER
	{
		public SYS_ROLEUSER()
		{}
		#region Model
		private int _id; // id
		private int _roleid; // 角色id
		private int _userid; // 用户id
		private string _description; // 描述
		/// <summary>
		/// id
		/// </summary>
		public int ID
{
		    set{ _id=value;}
		    get{return _id;}
		}
		/// <summary>
		/// 角色id
		/// </summary>
		public int ROLEID
{
		    set{ _roleid=value;}
		    get{return _roleid;}
		}
		/// <summary>
		/// 用户id
		/// </summary>
		public int USERID
{
		    set{ _userid=value;}
		    get{return _userid;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string DESCRIPTION
		{
 		   set{ _description=value;}
  		  get{return _description;}
		}
            		#endregion Model
	}
}

