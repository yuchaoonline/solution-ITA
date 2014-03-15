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
using PageBaseFun;

public partial class Login_Dj : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 在此处放置用户代码以初始化页面
        if (Session["UserName"] != null && Session["WebManagerVisit"] != null)
        {
            Response.Redirect("UI3/main.html", true);
            Response.End();
        }
    }


    private int InitLogin(string userid)
    {
        return 1;
    }

    protected void BT_SUBMIT_Click(object sender, ImageClickEventArgs e)
    {

        string str_Message = "";
        //页面输入有效性检查
        if (UserName.Text == "" || Password.Text == "") { Response.Write("<script language=javascript>alert('请输入用户名和密码!')</script>"); return; }
        //检查用户名和密码的字符串是否大于20


        ////////////////////////////////////////////////////////////////////////////////
        #region 检查验证码
        /*
        if (Session["VerifyCode"] != null)
        {
            if (TB_YZM.Text.ToString().ToUpper() != Session["VerifyCode"].ToString().ToUpper())
            {
                str_Message = "错误:验证码错误!";
                Response.Write("<script language=javascript>alert('错误:验证码错误!')</script>"); return;

            }
        }
        else
        {
            str_Message = "错误:验证码错误!";
            Response.Write("<script language=javascript>alert('错误:验证码错误!')</script>");
            return;
        }*/
        #endregion

        SitePageAccess oda = new SitePageAccess();
        //第一步：检查密码是否正确
        int rt = oda.CheckPassword(UserName.Text, Password.Text);

        string res = "";
        if (rt == 0)
        {
            res = "密码错误";
        }
        else if (rt == 1)
        {
            user userobj = oda.GetUserObjext(UserName.Text, Password.Text);
            Session.Add("userobj", userobj);
            //1：如果登录成功，session 中加入User对象，每个页面需要解析USer对象
            CUserInfo userinfoobj = oda.GetUserInfoObject(UserName.Text, Password.Text);
            Session.Add("userinfoobj", userinfoobj);
            if (InitLogin(userobj.id.ToString()) == 1)
            {
                Session.Add("WebManagerVisit", true);
                Response.Redirect("UI3/main.html", true);
            }
            else
                Response.Redirect(ConfigurationManager.AppSettings["Mainpage"], true);
        }
        else if (rt == 2)
        {
            res = "用户还没有通过验证";
        }
        else if (rt == 3)
        {
            res = "用户名不存在";
        }
        JS.Alert(res, this);

    }
}
