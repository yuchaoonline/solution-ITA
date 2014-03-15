using System;
namespace Mis.Model.ptgl
{
	/// <summary>
	/// 实体类SYS_ROLES 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SYS_ROLES
	{
		public SYS_ROLES()
		{}
		#region Model
		private int _id; // id
		private string _roleno; // 角色编号
		private string _userno; // 角色名称
		private string _description; // 描述
        private string _sysdatatype; // 系统数据类型
		/// <summary>
		/// id
		/// </summary>
		public int ID
{
		    set{ _id=value;}
		    get{return _id;}
		}
		/// <summary>
		/// 角色编号
		/// </summary>
		public string ROLENO
		{
 		   set{ _roleno=value;}
  		  get{return _roleno;}
		}
		/// <summary>
		/// 角色名称
		/// </summary>
		public string USERNO
		{
 		   set{ _userno=value;}
  		  get{return _userno;}
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
        /// 系统数据类型
        /// </summary>
        public string SYSDATATYPE
        {
            set { _sysdatatype = value; }
            get { return _sysdatatype; }
        }
            		#endregion Model
	}
}

