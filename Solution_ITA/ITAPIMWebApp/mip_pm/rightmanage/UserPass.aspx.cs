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
using DBUtility;


public partial class rightmanage_UserPass : CePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string userid = this._GetNowUserID();
            Mis.BLL.ptgl.SYS_USERS handle = new Mis.BLL.ptgl.SYS_USERS();
            Mis.Model.ptgl.SYS_USERS obj = handle.GetModel(int.Parse(userid));
            TextBox1.Text = obj.USERNAME;
        }
    }


    protected void BT_Submit_Click(object sender, EventArgs e)
    {
        string userid = this._GetNowUserID();
        Mis.BLL.ptgl.SYS_USERS handle = new Mis.BLL.ptgl.SYS_USERS();
        Mis.Model.ptgl.SYS_USERS obj = handle.GetModel(int.Parse(userid));
        
        if(this.TB_LASTPWD.Text.Trim() =="")
        {
             JS.Alert("请输入过去密码！",this);
            return ;
        }
        if(this.TB_NOWPWD.Text.Trim() =="")
        {
             JS.Alert("请输入现在密码！",this);
            return ;
        }
        if(this.TB_QRNOWPWD.Text.Trim() =="")
        {
             JS.Alert("请确认现在密码！",this);
            return ;
        }

        if(this.TB_NOWPWD.Text.Trim().CompareTo( this.TB_QRNOWPWD.Text.Trim() ) !=0)
        {
             JS.Alert("两次输入的现在密码不一致！",this);
            return ;
        }
       
        if (obj.PASSWORD.CompareTo(FormsAuthentication.HashPasswordForStoringInConfigFile(this.TB_LASTPWD.Text, "MD5")) == 0)
        {
            string nowmd5pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(this.TB_NOWPWD.Text, "MD5");
            string sql_str = "update sys_users  set password='" + nowmd5pwd + "' where id=" + userid;
            if (PageBaseFun.PageDBHelper.ExecuteSql(sql_str) > 0)
            {
                JS.Alert("修改成功！", this);
            }
            else
                JS.Alert("修改失败！", this);

        }
        else
            JS.Alert("过去密码输入不正确！",this);
    }
}
