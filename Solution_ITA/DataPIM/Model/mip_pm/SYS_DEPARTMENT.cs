using System;
namespace Mis.Model.ptgl
{
	/// <summary>
	/// ʵ����SYS_DEPARTMENT ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class SYS_DEPARTMENT
	{
		public SYS_DEPARTMENT()
		{}


        #region Model
        private int _id; // id
        private string _action;
        private string _deptno; // ���ű��
        private string _deptname; // ��������
        private string _syslevel; // ����
        private int _parentid; // ��һ��������id
        private string _description; // ����
        /// <summary>
        /// id
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ���ű��
        /// </summary>
        public string DEPTNO
        {
            set { _deptno = value; }
            get { return _deptno; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string DEPTNAME
        {
            set { _deptname = value; }
            get { return _deptname; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string SYSLEVEL
        {
            set { _syslevel = value; }
            get { return _syslevel; }
        }
        /// <summary>
        /// ��һ��������id
        /// </summary>
        public int PARENTID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// ����
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

