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
    /// CUserInfo 的摘要说明
    /// </summary>
    /// 
    [Serializable]
    public class CUserInfo
    {
        public CUserInfo()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public string ID;
        public string Username;
        public string Realname;
        public string CompanyID;
        public string CompanyFullName;
        public string DepartmentID;
        public string DepartmentFullNameWorkgroupFullName;
        public string WorkgroupID;
        public string WorkgroupFullName;
        public string phone;
    }

}