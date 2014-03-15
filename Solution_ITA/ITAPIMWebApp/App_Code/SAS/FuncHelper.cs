using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// FuncHelper 的摘要说明
/// </summary>
/// 
namespace PageBaseFun
{
    /// <summary>
    /// Function 的摘要说明。
    /// </summary>
    public class FuncHelper
    {
        public FuncHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// string -> datetime
        /// </summary>
        /// <param name="tmstr"></param>
        /// <returns></returns>
        public DateTime StrtoTime(string tmstr)
        {
            DateTime tm = System.DateTime.Parse(tmstr);
            return tm;
        }

        /// <summary>
        /// datetime时间加减
        /// </summary>
        /// <param name="tm"></param>
        /// <param name="daynum"></param>
        /// <param name="hhnum"></param>
        /// <param name="minum"></param>
        /// <returns></returns>
        public DateTime GetNextTime(DateTime tm, int daynum, int hhnum, int minum)//这是干吗的？
        {
            TimeSpan span = new TimeSpan(daynum, hhnum, minum, 0);
            DateTime nexttm = tm + span;
            return nexttm;
        }

        /// <summary>
        /// datetime->string
        /// </summary>
        /// <param name="tm"></param>
        /// <returns></returns>
        public string Timetostring(DateTime tm)
        {
            return tm.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 获取开始时间和结束时间的天数
        /// </summary>
        /// <param name="bg_time"></param>
        /// <param name="ed_time"></param>
        /// <returns></returns>
        public int GetBtDayNum(string bg_time, string ed_time)
        {
            TimeSpan span = StrtoTime(ed_time) - StrtoTime(bg_time);
            return span.Days;
        }

       
    }
}
