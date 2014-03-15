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
public partial class mip_pm_sys_usersedit : System.Web.UI.CePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this._isallowaccess("", "7", "");
        if (!IsPostBack)
        {
            IsofVisible();
            BindDwData();
            this.TB_ID.Text = this.Context.Request["id"].Trim();
            string actionstr = this.Context.Request["action"].Trim();
            if (actionstr != "edit")
            {
                IsofEnabled();
            }
            Mis.BLL.ptgl.SYS_USERS handle = new Mis.BLL.ptgl.SYS_USERS();
            Mis.Model.ptgl.SYS_USERS obj = handle.GetModel(int.Parse(this.TB_ID.Text));
            TB_ID.Text = obj.ID.ToString();

            TB_DEPTID.Text = obj.DEPTID;
            TB_DEPTNAME.Text = GetDeptName(obj.DEPTID);

            TB_USERNO.Text = obj.USERNO;

            TB_USERREALNAME.Text = obj.USERREALNAME;

            TB_USERNAME.Text = obj.USERNAME;

            TB_PASSWORD.Text = obj.PASSWORD;

            DP_SEX.SelectedValue = obj.SEX.ToString();

            TB_AGE.Text = obj.AGE.ToString();

            TB_PHONENO.Text = obj.PHONENO;

            TB_MOBILEPHONE.Text = obj.MOBILEPHONE;

            TB_REMARK1.Text = obj.REMARK1;

            TB_REMARK2.Text = obj.REMARK2;

            TB_REMARK3.Text = obj.REMARK3;

            TB_REMARK4.Text = obj.REMARK4;

            TB_REMARK5.Text = obj.REMARK5;

            //TB_REMARK6.Text = obj.REMARK6;

            GetPermission();
        }
    }

    private bool IsofUpdate_Action;

    /*
        UserMng.action.delete	用户删除按钮
        UserMng.action.update	用户更新按钮
        UserMng.action.detail	用户详细按钮
        UserMng.action.add	用户添加按钮
        UserMng.action.setrole	用户设置角色按钮
        UserMng.action.dataset	用户数据集权限按钮
     */

    private void GetPermission()
    {
        IsofUpdate_Action = _IsAuthorizedInaction("UserMng.action.update");
        this.Bt_commit.Enabled = IsofUpdate_Action;
    }

    /// <summary>
    /// 控件是否可见
    /// </summary>
    protected void IsofVisible()
    {
        LB_DEPTID.Visible = true; //部门id
        LB_DEPTIDunit.Visible = true; //部门id
        TB_DEPTID.Visible = true; //部门id

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

        Bt_commit.Visible = true;
    }

    protected string GetDeptName(string p_deptid)
    {
        Mis.BLL.ptgl.SYS_DEPARTMENT handle = new Mis.BLL.ptgl.SYS_DEPARTMENT();
        Mis.Model.ptgl.SYS_DEPARTMENT model = handle.GetModel(int.Parse(p_deptid));
        return model.DEPTNAME;
    }


    /// <summary>
    /// 控件是否可修改
    /// </summary>
    protected void IsofEnabled()
    {

        TB_DEPTID.Enabled = false;//部门id
        TB_DEPTID.Visible = false;
        TB_DEPTNAME.Enabled = false;

        TB_USERNO.Enabled = false;//人员工号

        TB_USERREALNAME.Enabled = false;//人员真实名称

        TB_USERNAME.Enabled = false;//用户名

        TB_PASSWORD.Enabled = false;//人员密码
        DP_SEX.Enabled = false; //性别

        TB_AGE.Enabled = false;//年龄
        

        TB_PHONENO.Enabled = false;

        TB_MOBILEPHONE.Enabled = false;

        this.Bt_DEPARTMENT.Visible = false;

        Bt_commit.Visible = false;
    }


    /// <summary>
    /// 将gridview选定的值赋值到页面对应的控件中
    /// </summary>
    /// <param name="item"></param>
    private void Sendtest_manageDataToPage(Mis.Model.ptgl.SYS_USERS obj)
    {
        TB_ID.Text = obj.ID.ToString();

        TB_DEPTID.Text = obj.DEPTID;

        TB_USERNO.Text = obj.USERNO;

        TB_USERREALNAME.Text = obj.USERREALNAME;

        TB_USERNAME.Text = obj.USERNAME;

        TB_PASSWORD.Text = obj.PASSWORD;

        DP_SEX.SelectedValue = obj.SEX.ToString();

        TB_AGE.Text = obj.AGE.ToString();

        TB_PHONENO.Text = obj.PHONENO;

        TB_MOBILEPHONE.Text = obj.MOBILEPHONE;

        TB_REMARK1.Text = obj.REMARK1;

        TB_REMARK2.Text = obj.REMARK2;

        TB_REMARK3.Text = obj.REMARK3;

        TB_REMARK4.Text = obj.REMARK4;

        TB_REMARK5.Text = obj.REMARK5;

        //TB_REMARK6.Text = obj.REMARK6;

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
        if (this.TB_DEPTNAME.Text.Trim() == "" || this.TB_DEPTID.Text.Trim() == "")
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
    /// 信息标准绑定下拉框dp
    /// </summary>
    private void BindDwData()
    {
        Mis.BLL.ptgl.SYS_INFODICT dic = new Mis.BLL.ptgl.SYS_INFODICT();
        //下拉框 性别
        dic.BindToDropDownList(this.DP_SEX, "0");
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
        obj.ID = int.Parse(TB_ID.Text);
        obj = handle.GetModel(obj.ID);
        obj.DEPTID = TB_DEPTID.Text;

        obj.USERNO = TB_USERNO.Text;

        obj.USERREALNAME = TB_USERREALNAME.Text;

        obj.USERNAME = TB_USERNAME.Text;

        obj.PASSWORD = FormsAuthentication.HashPasswordForStoringInConfigFile(TB_PASSWORD.Text.Trim(), "MD5");

        obj.SEX = int.Parse(DP_SEX.SelectedValue);

        obj.PHONENO = TB_PHONENO.Text.Trim();

        obj.MOBILEPHONE = TB_MOBILEPHONE.Text.Trim();

        obj.REMARK1 = TB_REMARK1.Text.Trim();

        obj.REMARK2 = TB_REMARK2.Text.Trim();

        obj.REMARK3 = TB_REMARK3.Text.Trim();

        obj.REMARK4 = TB_REMARK4.Text.Trim();

        obj.REMARK5 = TB_REMARK5.Text.Trim();

        obj.REMARK6 = "";


        if (TB_AGE.Text.Trim() != "")
        {
            obj.AGE = int.Parse(TB_AGE.Text);
        }

        if (0 < handle.Update(obj))
        {
            JS.Alert("修改成功！", this);
        }
        else
            JS.Alert("修改失败！", this);
    }



    protected void Bt_clear_Click(object sender, EventArgs e)
    {
        TB_ID.Text = "";
        TB_DEPTID.Text = "";
        TB_USERNO.Text = "";
        TB_USERREALNAME.Text = "";
        TB_USERNAME.Text = "";
        TB_PASSWORD.Text = "";
        DP_SEX.SelectedValue = "1";
        TB_AGE.Text = "";

        TB_PHONENO.Text = "";

        TB_MOBILEPHONE.Text = "";

        TB_REMARK1.Text = "";

        TB_REMARK2.Text = "";

        TB_REMARK3.Text = "";

        TB_REMARK4.Text = "";

        TB_REMARK5.Text = "";

        //TB_REMARK6.Text = "";
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


