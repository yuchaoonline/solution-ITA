using System;
namespace Mis.Model.ptgl
{
	/// <summary>
	/// 实体类SYS_MOUDLEACTION 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    public class SYS_MOUDLEACTION
    {
        public SYS_MOUDLEACTION()
        { }
        #region Model
        private int _id; // id
        private string _moudlename; // 模块名称
        private string _action; // 动作名称
        private string _description; // 描述
        private int _isofdatafilter;//是否数据筛选
        /// <summary>
        /// id
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string MOUDLENAME
        {
            set { _moudlename = value; }
            get { return _moudlename; }
        }
        /// <summary>
        /// 动作名称
        /// </summary>
        public string ACTION
        {
            set { _action = value; }
            get { return _action; }
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
        /// 是否筛选数据
        /// </summary>
        public int ISOFDATAFILTER
        {
            set { _isofdatafilter = value; }
            get { return _isofdatafilter; }
        }
        #endregion Model

    }
}

