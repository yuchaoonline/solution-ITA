using System;
namespace Mis.Model.ptgl
{
	/// <summary>
	/// 实体类SYS_ROLEACTRIGHTS 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SYS_ROLEACTRIGHTS
	{
		public SYS_ROLEACTRIGHTS()
		{}
		#region Model
		private int _id; // id
		private int _roleplid; // 角色id
		private int _actionid; // 操作id
		private int _rolesname; // 是否允许
		private int _type; // 种类
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
		public int ROLEPLID
{
		    set{ _roleplid=value;}
		    get{return _roleplid;}
		}
		/// <summary>
		/// 操作id
		/// </summary>
		public int ACTIONID
{
		    set{ _actionid=value;}
		    get{return _actionid;}
		}
		/// <summary>
		/// 是否允许
		/// </summary>
		public int ROLESNAME
{
		    set{ _rolesname=value;}
		    get{return _rolesname;}
		}
		/// <summary>
		/// 种类
		/// </summary>
		public int TYPE
{
		    set{ _type=value;}
		    get{return _type;}
		}
            		#endregion Model
	}
}

