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
public partial class mip_pm_sys_usersadd : System.Web.UI.CePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this._isallowaccess("", "7", "");
        if (!IsPostBack)
        {
            IsofInfoVisible();
            BindDwData();
        }
    }

    private void IsofInfoVisible()
    {
        this.LB_AGE.Visible = true;
        this.TB_AGE.Visible = true;
        this.TB_AGE.Text = "20";

        this.TB_PHONENO.Visible = true;
        this.LB_PHONENOunit.Visible = true;

        this.TB_REMARK1.Visible = false;
        this.LB_REMARK1.Visible = false;
        this.LB_REMARK1unit.Visible = false;

        this.TB_REMARK2.Visible = false;
        this.LB_REMARK2.Visible = false;
        this.LB_REMARK2unit.Visible = false;

        this.TB_REMARK3.Visible = false;
        this.LB_REMARK3.Visible = false;
        this.LB_REMARK3unit.Visible = false;

        this.TB_REMARK4.Visible = false;
        this.LB_REMARK4.Visible = false;
        this.LB_REMARK4unit.Visible = false;

        this.TB_REMARK5.Visible = false;
        this.LB_REMARK5.Visible = false;
        this.LB_REMARK5unit.Visible = false;
    }
    /// <summary>
    /// 做输入有效性判断
    /// </summary>
    /// <returns></returns>
    private bool Isputvalid()
    {
        if (this.TB_USERNO.Text.Trim() == "")
        {
            JS.Alert("用户工号不能为空！", this);
            return false;
        }
        if (this.TB_USERNAME.Text.Trim() == "")
        {
            JS.Alert("用户名不能为空！", this);
            return false;
        }
        if (this.TB_USERREALNAME.Text.Trim() == "")
        {
            JS.Alert("用户姓名不能为空！", this);
            return false;
        }
        if (this.TB_PASSWORD.Text.Trim() == "")
        {
            JS.Alert("密码不能为空！", this);
            return false;
        }
        if (this.TB_DEPTNAME.Text.Trim() == ""  || this.TB_DEPTID.Text.Trim()=="")
        {
            JS.Alert("请选择所属部门！", this);
            return false;
        }
        ///////////////////////////////////////////
        if (this.TB_PASSWORD.Text.Length < 6 || this.TB_PASSWORD.Text.Length > 16)
        {
            JS.Alert("密码长度不对，请重新输入！", this);
            return false;
        }
        if (this.TB_USERNAME.Text.Length < 1 || this.TB_USERNAME.Text.Length > 15)
        {
            JS.Alert("用户名长度不对，请重新输入！", this);
            return false;
        }
        if (this.TB_USERNO.Text.Length < 1 || this.TB_USERNO.Text.Length > 15)
        {
            JS.Alert("用户工号长度不对，请重新输入！", this);
            return false;
        }
        if (this.TB_USERREALNAME.Text.Length < 1 || this.TB_USERREALNAME.Text.Length > 15)
        {
            JS.Alert("用户姓名长度不对，请重新输入！", this);
            return false;
        }
        return true;
    }

    /// <summary>
    /// 从页面获得控件值的函数，并将数据存储在对应的model中
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    private Mis.Model.ptgl.SYS_USERS Gettest_manageDataFromPage(Mis.Model.ptgl.SYS_USERS obj)
    {
        obj.DEPTID = TB_DEPTID.Text.Trim();

        obj.USERNO = TB_USERNO.Text.Trim();

        obj.USERREALNAME = TB_USERREALNAME.Text.Trim();

        obj.USERNAME = TB_USERNAME.Text.Trim();

        obj.PASSWORD = FormsAuthentication.HashPasswordForStoringInConfigFile(TB_PASSWORD.Text.Trim(), "MD5");

        obj.SEX = int.Parse(DP_SEX.SelectedValue);
        if (TB_AGE.Text.Trim() != "")
        {
            obj.AGE = int.Parse(TB_AGE.Text.Trim());
        }

        obj.PHONENO = TB_PHONENO.Text.Trim();

        obj.MOBILEPHONE = TB_MOBILEPHONE.Text.Trim();

        obj.REMARK1 = TB_REMARK1.Text.Trim();

        obj.REMARK2 = TB_REMARK2.Text.Trim();

        obj.REMARK3 = TB_REMARK3.Text.Trim();

        obj.REMARK4 = TB_REMARK4.Text.Trim();

        obj.REMARK5 = TB_REMARK5.Text.Trim();

        obj.REMARK6 = "";

        return obj;
    }


    /// <summary>
    /// 信息标准绑定下拉框dp
    /// </summary>
    private void BindDwData()
    {
        Mis.BLL.ptgl.SYS_INFODICT dic = new Mis.BLL.ptgl.SYS_INFODICT();
        //下拉框 性别
        dic.BindToDropDownList(this.DP_SEX, "0");
    }

    /// <summary>
    /// 控件是否可见
    /// </summary>
    protected void IsofVisible()
    {
        LB_DEPTID.Visible = true; //部门id
        LB_DEPTIDunit.Visible = false; //部门id
        TB_DEPTID.Visible = false; //部门id

        LB_USERNO.Visible = true; //人员工号
        LB_USERNOunit.Visible = true; //人员工号
        TB_USERNO.Visible = true; //人员工号

        LB_USERREALNAME.Visible = true; //人员真实名称
        LB_USERREALNAMEunit.Visible = true; //人员真实名称
        TB_USERREALNAME.Visible = true; //人员真实名称

        LB_USERNAME.Visible = true; //用户名
        LB_USERNAMEunit.Visible = true; //用户名
        TB_USERNAME.Visible = true; //用户名

        LB_PASSWORD.Visible = true; //人员密码
        LB_PASSWORDunit.Visible = true; //人员密码
        TB_PASSWORD.Visible = true; //人员密码

        LB_SEX.Visible = true; //性别
        LB_SEXunit.Visible = true; //性别
        DP_SEX.Visible = true; //性别

        LB_AGE.Visible = true; //年龄
        LB_AGEunit.Visible = true; //年龄
        TB_AGE.Visible = true; //年龄

    }


    protected void Bt_commit_Click(object sender, EventArgs e)
    {
        if (false == Isputvalid())
        {
            JS.Alert("输入不满足要求", this);
            return;
        }
        Mis.BLL.ptgl.SYS_USERS handle = new Mis.BLL.ptgl.SYS_USERS();
        Mis.Model.ptgl.SYS_USERS obj = new Mis.Model.ptgl.SYS_USERS();
        obj.DEPTID = TB_DEPTID.Text.Trim();

        obj.USERNO = TB_USERNO.Text.Trim();

        obj.USERREALNAME = TB_USERREALNAME.Text.Trim();

        obj.USERNAME = TB_USERNAME.Text.Trim();

        obj.PASSWORD = FormsAuthentication.HashPasswordForStoringInConfigFile(TB_PASSWORD.Text.Trim(), "MD5");
        
        obj.SEX = int.Parse(DP_SEX.SelectedValue);
        if (TB_AGE.Text.Trim() != "")
        {
            obj.AGE = int.Parse(TB_AGE.Text.Trim());
        }

        obj.PHONENO = TB_PHONENO.Text.Trim();

        obj.MOBILEPHONE = TB_MOBILEPHONE.Text.Trim();

        obj.REMARK1 = TB_REMARK1.Text.Trim();

        obj.REMARK2 = TB_REMARK2.Text.Trim();

        obj.REMARK3 = TB_REMARK3.Text.Trim();

        obj.REMARK4 = TB_REMARK4.Text.Trim();

        obj.REMARK5 = TB_REMARK5.Text.Trim();

        obj.REMARK6 = "";

        if (handle.Existsmodel(obj) == true)
        {
            JS.Alert("对不起，已经存在！", this);
            return;
        }

        int p_ResID = handle.Add(obj);
        if (0 < p_ResID)
        {

            //添加信息
            string p_ResTableName = "UserMng";
            string p_ResIDStr = p_ResID.ToString();
            this._AddResLinkInfo(p_ResTableName, p_ResIDStr);
            //
            JS.Alert("添加成功！", this);
        }
        else
            JS.Alert("添加失败！", this);
    }


    /// <summary>
    /// 清空页面控件的值
    /// </summary>
    private void Clear_test_manage()
    {
        //TB_DEPTID.Text = "";
        TB_USERNO.Text = "";
        TB_USERREALNAME.Text = "";
        TB_USERNAME.Text = "";
        TB_PASSWORD.Text = "";
        DP_SEX.SelectedValue = "1";
        TB_AGE.Text = "";
        TB_PHONENO.Text = "";
        TB_MOBILEPHONE.Text = "";
    }


    protected void Bt_clear_Click(object sender, EventArgs e)
    {
        //TB_DEPTID.Text = "";
        TB_USERNO.Text = "";
        TB_USERREALNAME.Text = "";
        TB_USERNAME.Text = "";
        TB_PASSWORD.Text = "";
        DP_SEX.SelectedValue = "1";
        TB_AGE.Text = "";
        TB_PHONENO.Text = "";
        TB_MOBILEPHONE.Text = "";
    }


    protected void Bt_return_Click(object sender, EventArgs e)
    {
        Response.Redirect("sys_usersselect.aspx");
    }
    protected void Bt_DEPARTMENT_Click(object sender, EventArgs e)
    {
        this.Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>window.open('sys_departmenttreeadd.aspx','userIndex','width=400,height=375,top=150,left=280,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,location=no,status=no').focus();</script>");

    }
}

