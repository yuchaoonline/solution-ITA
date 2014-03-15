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
public partial class mip_pm_sys_moudleactionedit : System.Web.UI.CePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
            Mis.BLL.ptgl.SYS_MOUDLEACTION handle = new Mis.BLL.ptgl.SYS_MOUDLEACTION();
            Mis.Model.ptgl.SYS_MOUDLEACTION obj = handle.GetModel(int.Parse(this.TB_ID.Text));
            TB_ID.Text = obj.ID.ToString();

            TB_MOUDLENAME.Text = obj.MOUDLENAME;

            TB_ACTION.Text = obj.ACTION;

            TB_DESCRIPTION.Text = obj.DESCRIPTION;

            DP_ISOFDATAFILTER.SelectedValue = obj.ISOFDATAFILTER.ToString();

            Mis.BLL.ptgl.SYS_MENU menu_handle = new Mis.BLL.ptgl.SYS_MENU();
            Djdw.Model.Post.SYS_MENU menu_model = menu_handle.GetModel(int.Parse(obj.MOUDLENAME));
            this.TB_MOUDLENAME_INFO.Text = menu_model.MOUDLENAME;
            this.TB_MOUDLENAME_INFO.Enabled = false;

            GetPermission();

        }
    }

    private bool IsofUpdate_Action;


    /*
        Actionmng.data.delete	动作删除数据控制点
        Actionmng.data.detail	动作详细数据控制点
        Actionmng.data.show	动作查看数据控制点
        Actionmng.data.update	动作更行数据控制点
        Actionmng.action.delete	动作删除按钮
        Actionmng.action.update	动作更新按钮
        Actionmng.action.detail	动作详细按钮
        Actionmng.action.add	动作添加按钮

     */

    private void GetPermission()
    {
        IsofUpdate_Action = _IsAuthorizedInaction("Actionmng.action.update");

    }

    /// <summary>
    /// 控件是否可见
    /// </summary>
    protected void IsofVisible()
    {
        LB_MOUDLENAME.Visible = false; //模块名称
        LB_MOUDLENAMEunit.Visible = false; //模块名称
        TB_MOUDLENAME.Visible = false; //模块名称

        LB_ACTION.Visible = true; //动作名称
        LB_ACTIONunit.Visible = true; //动作名称
        TB_ACTION.Visible = true; //动作名称

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

        TB_MOUDLENAME.Enabled = false;//模块名称

        TB_ACTION.Enabled = false;//动作名称

        TB_DESCRIPTION.Enabled = false;//描述
        Bt_commit.Visible = false;
    }


    /// <summary>
    /// 将gridview选定的值赋值到页面对应的控件中
    /// </summary>
    /// <param name="item"></param>
    private void Sendtest_manageDataToPage(Mis.Model.ptgl.SYS_MOUDLEACTION obj)
    {
        TB_ID.Text = obj.ID.ToString();

        TB_MOUDLENAME.Text = obj.MOUDLENAME;

        TB_ACTION.Text = obj.ACTION;

        TB_DESCRIPTION.Text = obj.DESCRIPTION;

    }

    /// <summary>
    /// 做输入有效性判断
    /// </summary>
    /// <returns></returns>
    private bool Isputvalid()
    {
        return true;
    }

    /// <summary>
    /// 信息标准绑定下拉框dp
    /// </summary>
    private void BindDwData()
    {
        Mis.BLL.ptgl.SYS_INFODICT dic = new Mis.BLL.ptgl.SYS_INFODICT();
        //是否筛选数据
        dic.BindToDropDownList(this.DP_ISOFDATAFILTER, "41");
    }

    protected void Bt_commit_Click(object sender, EventArgs e)
    {

        //操作权限管理
        GetPermission();
        if (IsofUpdate_Action == false)
        {
            JS.Alert("无权限修改数据！", this);
            return;
        }

        if (false == Isputvalid())
        {
            JS.Alert("输入不满足要求", this);
            return;
        }
        Mis.BLL.ptgl.SYS_MOUDLEACTION handle = new Mis.BLL.ptgl.SYS_MOUDLEACTION();
        Mis.Model.ptgl.SYS_MOUDLEACTION obj = new Mis.Model.ptgl.SYS_MOUDLEACTION();
        obj.ID = int.Parse(TB_ID.Text);
        obj = handle.GetModel(obj.ID);
        obj.MOUDLENAME = TB_MOUDLENAME.Text;

        obj.ACTION = TB_ACTION.Text;

        obj.DESCRIPTION = TB_DESCRIPTION.Text;

        obj.ISOFDATAFILTER = int.Parse(DP_ISOFDATAFILTER.SelectedValue);

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
        TB_MOUDLENAME.Text = "";
        TB_ACTION.Text = "";
        TB_DESCRIPTION.Text = "";
    }
    protected void Bt_return_Click(object sender, EventArgs e)
    {
       // Response.Redirect("sys_moudleactionselect.aspx");
        string parentid = this.Context.Request["parentid"].Trim();
        Response.Write("<script language=javascript>window.parent.frames[\"infodict_right\"].location.href=\"subclassview.aspx?parentid=" + parentid + "\";</script>");

    }
}


