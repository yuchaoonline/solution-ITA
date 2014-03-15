using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace PageBaseFun
{
    /// <summary>
    /// CUserHxRight 的摘要说明
    /// </summary>
    public class CUserHxRight
    {
        public CUserHxRight()
        {
            isof_sysadmin = false;
            isof_qzadmin = false;
            isof_xqzadmin = false;
            mng_saliststr = "";
        }

        /// <summary>
        /// 是否为系统管理员
        /// </summary>
        public bool isof_sysadmin;

        /// <summary>
        /// 是否为群组管理员
        /// </summary>
        public bool isof_qzadmin;

        /// <summary>
        /// 是否为小群组管理员
        /// </summary>
        public bool isof_xqzadmin;

        /// <summary>
        /// 管理的示范区列表
        /// </summary>
        public string mng_saliststr;

    }
}
