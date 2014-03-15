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

public partial class mip_pm_sys_rolesedit : System.Web.UI.CePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this._isallowaccess("", "8", "");
        if (!IsPostBack)
        {
            BindDwData();
            this.TB_ID.Text = this.Context.Request["id"].Trim();
            string actionstr = this.Context.Request["action"].Trim();
            if (actionstr != "edit")
            {
                IsofEnabled();
            }
            Mis.BLL.ptgl.SYS_ROLES handle = new Mis.BLL.ptgl.SYS_ROLES();
            Mis.Model.ptgl.SYS_ROLES obj = handle.GetModel(int.Parse(this.TB_ID.Text));
            TB_ID.Text = obj.ID.ToString();

            TB_ROLENO.Text = obj.ROLENO;

            TB_USERNO.Text = obj.USERNO;

            TB_DESCRIPTION.Text = obj.DESCRIPTION;

            this.DP_SYSDATATYPE.SelectedValue = obj.SYSDATATYPE;

            GetPermission();
        }
    }

    private bool IsofUpdate_Action;
    /*
        Rolemng.data.delete	角色删除数据控制点
        Rolemng.data.detail	角色详细数据控制点
        Rolemng.data.show	角色查看数据控制点
        Rolemng.data.update	角色更新数据控制点
        Rolemng.data.right	角色权限数据控制点
        Rolemng.action.delete	删除
        Rolemng.action.update	更新
        Rolemng.action.detail	详细
        Rolemng.action.add	添加
        Rolemng.action.right	分配权限

     */

    private void GetPermission()
    {
        IsofUpdate_Action = _IsAuthorizedInaction("Rolemng.action.update");
        this.Bt_commit.Enabled = IsofUpdate_Action;
    }

    /// <summary>
    /// 控件是否可见
    /// </summary>
    protected void IsofVisible()
    {
        LB_ROLENO.Visible = true; //角色编号
        LB_ROLENOunit.Visible = true; //角色编号
        TB_ROLENO.Visible = true; //角色编号

        LB_USERNO.Visible = true; //角色名称
        LB_USERNOunit.Visible = true; //角色名称
        TB_USERNO.Visible = true; //角色名称

        LB_DESCRIPTION.Visible = true; //描述
        LB_DESCRIPTIONunit.Visible = true; //描述
        TB_DESCRIPTION.Visible = true; //描述

        Bt_commit.Visible = true;
    }


    /// <summary>
    /// 控件是否可修改
    /// </summary>
    protected void IsofEnabled()
    {

        TB_ROLENO.Enabled = false;//角色编号

        TB_USERNO.Enabled = false;//角色名称

        TB_DESCRIPTION.Enabled = false;//描述
        Bt_commit.Visible = false;
    }


    /// <summary>
    /// 将gridview选定的值赋值到页面对应的控件中
    /// </summary>
    /// <param name="item"></param>
    private void Sendtest_manageDataToPage(Mis.Model.ptgl.SYS_ROLES obj)
    {
        TB_ID.Text = obj.ID.ToString();

        TB_ROLENO.Text = obj.ROLENO;

        TB_USERNO.Text = obj.USERNO;

        TB_DESCRIPTION.Text = obj.DESCRIPTION;

    }

    /// <summary>
    /// 做输入有效性判断
    /// </summary>
    /// <returns></returns>
    private bool Isputvalid()
    {
        if (this.TB_ROLENO.Text.Trim() == "")
        {
            JS.Alert("角色编号不能为空！", this);
            return false;
        }
        if (this.TB_USERNO.Text.Trim() == "")
        {
            JS.Alert("角色名称不能为空！", this);
            return false;
        }
        if (this.TB_ROLENO.Text.Length > 15)
        {
            JS.Alert("角色编号过长，长度不能超过15！", this);
            return false;
        }
        if (this.TB_USERNO.Text.Length > 15)
        {
            JS.Alert("角色名称过长，长度不能超过15！", this);
            return false;
        }
        if (this.TB_DESCRIPTION.Text.Length > 100)
        {
            JS.Alert("角色描述过长，长度不能超过100！", this);
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
        dic.BindToDropDownList(this.DP_SYSDATATYPE, "85");
    }

    protected void Bt_commit_Click(object sender, EventArgs e)
    {
        if (false == Isputvalid())
        {
            JS.Alert("输入不满足要求", this);
            return;
        }
        Mis.BLL.ptgl.SYS_ROLES handle = new Mis.BLL.ptgl.SYS_ROLES();
        Mis.Model.ptgl.SYS_ROLES obj = new Mis.Model.ptgl.SYS_ROLES();
        obj.ID = int.Parse(TB_ID.Text);
        obj = handle.GetModel(obj.ID);
        obj.ROLENO = TB_ROLENO.Text;

        obj.USERNO = TB_USERNO.Text;

        obj.SYSDATATYPE = this.DP_SYSDATATYPE.SelectedValue;

        obj.DESCRIPTION = TB_DESCRIPTION.Text;

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
        TB_ROLENO.Text = "";
        TB_USERNO.Text = "";
        TB_DESCRIPTION.Text = "";
    }
    protected void Bt_return_Click(object sender, EventArgs e)
    {
        Response.Redirect("sys_rolesselect.aspx");
    }
}


