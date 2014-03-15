using System;
namespace Mis.Model.ptgl
{
    /// <summary>
    /// 实体类SYS_USERS 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class SYS_USERS
    {
        public SYS_USERS()
        { }
        #region Model
        private int _id; // id
        private string _deptid; // 部门id
        private string _userno; // 人员工号
        private string _userrealname; // 人员真实名称
        private string _username; // 用户名
        private string _password; // 人员密码
        private int _sex; // 性别
        private int _age; // 年龄
        private string _phoneno;//联系电话
        private string _mobilephone;//移动电话
        private string _remark1; //备注1
        private string _remark2; //备注2
        private string _remark3; //备注3
        private string _remark4; //备注4
        private string _remark5; //备注5
        private string _remark6; //备注6
        /// <summary>
        /// id
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 部门id
        /// </summary>
        public string DEPTID
        {
            set { _deptid = value; }
            get { return _deptid; }
        }
        /// <summary>
        /// 人员工号
        /// </summary>
        public string USERNO
        {
            set { _userno = value; }
            get { return _userno; }
        }
        /// <summary>
        /// 人员真实名称
        /// </summary>
        public string USERREALNAME
        {
            set { _userrealname = value; }
            get { return _userrealname; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string USERNAME
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 人员密码
        /// </summary>
        public string PASSWORD
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public int SEX
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public int AGE
        {
            set { _age = value; }
            get { return _age; }
        }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string PHONENO
        {
            set { _phoneno = value; }
            get { return _phoneno; }
        }


        /// <summary>
        /// 移动电话
        /// </summary>
        public string MOBILEPHONE
        {
            set { _mobilephone = value; }
            get { return _mobilephone; }
        }

        public string REMARK1
        {
            set { _remark1 = value; }
            get { return _remark1; }
        }

        public string REMARK2
        {
            set { _remark2 = value; }
            get { return _remark2; }
        }

        public string REMARK3
        {
            set { _remark3 = value; }
            get { return _remark3; }
        }
        public string REMARK4
        {
            set { _remark4 = value; }
            get { return _remark4; }
        }
        public string REMARK5
        {
            set { _remark5 = value; }
            get { return _remark5; }
        }

        public string REMARK6
        {
            set { _remark6 = value; }
            get { return _remark6; }
        }

        #endregion Model
    }
}

