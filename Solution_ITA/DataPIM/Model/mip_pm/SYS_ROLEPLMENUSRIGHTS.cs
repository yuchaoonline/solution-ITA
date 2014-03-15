using System;
namespace Mis.Model.ptgl
{
	/// <summary>
	/// 实体类SYS_ROLEPLMENUSRIGHTS 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SYS_ROLEPLMENUSRIGHTS
	{
		public SYS_ROLEPLMENUSRIGHTS()
		{}
		#region Model
		private int _id; // id
		private int _roleplid; // 角色用户id
		private int _menuid; // 菜单id
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
		/// 角色用户id
		/// </summary>
		public int ROLEPLID
{
		    set{ _roleplid=value;}
		    get{return _roleplid;}
		}
		/// <summary>
		/// 菜单id
		/// </summary>
		public int MENUID
{
		    set{ _menuid=value;}
		    get{return _menuid;}
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

