using System;
namespace Mis.Model.ptgl
{
	/// <summary>
	/// 实体类SYS_DEPARTMENT 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SYS_DEPARTMENT
	{
		public SYS_DEPARTMENT()
		{}


        #region Model
        private int _id; // id
        private string _action;
        private string _deptno; // 部门编号
        private string _deptname; // 部门名称
        private string _syslevel; // 级别
        private int _parentid; // 上一个级别部门id
        private string _description; // 描述
        /// <summary>
        /// id
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 部门编号
        /// </summary>
        public string DEPTNO
        {
            set { _deptno = value; }
            get { return _deptno; }
        }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DEPTNAME
        {
            set { _deptname = value; }
            get { return _deptname; }
        }
        /// <summary>
        /// 级别
        /// </summary>
        public string SYSLEVEL
        {
            set { _syslevel = value; }
            get { return _syslevel; }
        }
        /// <summary>
        /// 上一个级别部门id
        /// </summary>
        public int PARENTID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string DESCRIPTION
        {
            set { _description = value; }
            get { return _description; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ACTION
        {
            set { _action = value; }
            get { return _action; }
        }
        #endregion Model
	}
}

