using System;
namespace gtled.Model.Post
{
    /// <summary>
    /// 实体类SYS_MAILRUN 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class SYS_MAILRUN
    {
        public SYS_MAILRUN()
        { }
        #region Model
        private int _id; // 编号
        private string _mailsubject; // 邮件的标题
        private string _mailcontent; // 邮件的内容
        private string _sendtime; // 发送时间
        private int _status; // 邮件所处的状态
        private int _resendnum; // 重发次数
        private string _remark; // 备注
        private string _remark1; // 备注1
        /// <summary>
        /// 编号
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 邮件的标题
        /// </summary>
        public string MAILSUBJECT
        {
            set { _mailsubject = value; }
            get { return _mailsubject; }
        }
        /// <summary>
        /// 邮件的内容
        /// </summary>
        public string MAILCONTENT
        {
            set { _mailcontent = value; }
            get { return _mailcontent; }
        }
        /// <summary>
        /// 发送时间
        /// </summary>
        public string SENDTIME
        {
            set { _sendtime = value; }
            get { return _sendtime; }
        }
        /// <summary>
        /// 邮件所处的状态
        /// </summary>
        public int STATUS
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 重发次数
        /// </summary>
        public int RESENDNUM
        {
            set { _resendnum = value; }
            get { return _resendnum; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string REMARK
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 备注1
        /// </summary>
        public string REMARK1
        {
            set { _remark1 = value; }
            get { return _remark1; }
        }
        #endregion Model
    }

}

