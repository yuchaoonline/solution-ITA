using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UI3_Top : CePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    private void BindData()
    {
        LB_NOWTIMESTR.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        this.LB_IP.Text = this._GetNowRequestIp();
        this.LB_USERNAME.Text = this._GetNowUserName();
        this.LB_ROLE.Text = this._GetNowRoles();
        this.LB_WORKAREA.Text = this._GetNowWorkArea();
        this.LB_DEPART.Text = this._GetNowDepartMent();
    }
}
