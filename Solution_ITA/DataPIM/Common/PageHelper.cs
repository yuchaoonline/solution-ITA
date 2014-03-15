using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;

namespace CommonMethod
{
    public class PageHelper
    {
        public static string RenderControlAsString(Control ctl)
        {
            StringWriter sw = new StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            ctl.RenderControl(writer);
            string str = sw.ToString();
            writer.Close();
            sw.Close();
            return str;
            //<asp:Panel   ID= "Panel1 "   runat= "server "   Height= "100% "   Width= "100% ">
        }
    }
}
