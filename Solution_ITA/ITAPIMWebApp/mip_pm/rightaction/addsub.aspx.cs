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
public partial class mip_pm_sys_moudleactionadd : System.Web.UI.CePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDwData();
            IsofVisible();
            GetPermission();
        }
    }
    
    private bool IsofAdd_Action;
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
        IsofAdd_Action = _IsAuthorizedInaction("Actionmng.action.update");
        this.Bt_commit.Enabled = IsofAdd_Action;

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
    /// 从页面获得控件值的函数，并将数据存储在对应的model中
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    private Mis.Model.ptgl.SYS_MOUDLEACTION Gettest_manageDataFromPage(Mis.Model.ptgl.SYS_MOUDLEACTION obj)
    {
        obj.MOUDLENAME = TB_MOUDLENAME.Text.Trim();

        obj.ACTION = TB_ACTION.Text.Trim();

        obj.DESCRIPTION = TB_DESCRIPTION.Text.Trim();

        return obj;
    }


    /// <summary>
    /// 信息标准绑定下拉框dp
    /// </summary>
    private void BindDwData()
    {
        string parentid = this.Context.Request["parentid"].Trim();
        this.TB_MOUDLENAME.Text = parentid;

        Mis.BLL.ptgl.SYS_MENU handle = new Mis.BLL.ptgl.SYS_MENU();
        Djdw.Model.Post.SYS_MENU model = handle.GetModel(int.Parse(parentid));
        this.TB_MOUDLENAME_INFO.Text = model.MOUDLENAME;
        this.TB_MOUDLENAME_INFO.Enabled = false;



        Mis.BLL.ptgl.SYS_INFODICT dic = new Mis.BLL.ptgl.SYS_INFODICT();
        //是否筛选数据
        dic.BindToDropDownList(this.DP_ISOFDATAFILTER, "41");
      
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

    }


    protected void Bt_commit_Click(object sender, EventArgs e)
    {
        if (false == Isputvalid())
        {
            JS.Alert("输入不满足要求", this);
            return;
        }
        Mis.BLL.ptgl.SYS_MOUDLEACTION handle = new Mis.BLL.ptgl.SYS_MOUDLEACTION();
        Mis.Model.ptgl.SYS_MOUDLEACTION obj = new Mis.Model.ptgl.SYS_MOUDLEACTION();
        obj.MOUDLENAME = TB_MOUDLENAME.Text.Trim();

        obj.ACTION = TB_ACTION.Text.Trim();

        obj.DESCRIPTION = TB_DESCRIPTION.Text.Trim();

        obj.ISOFDATAFILTER = int.Parse(this.DP_ISOFDATAFILTER.SelectedValue);

        if (handle.Existsmodel(obj) == true)
        {
            JS.Alert("对不起，已经存在！", this);
            return;
        }

        if (0 < handle.Add(obj))
        {
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
        TB_MOUDLENAME.Text = "";
        TB_ACTION.Text = "";
        TB_DESCRIPTION.Text = "";
    }


    protected void Bt_clear_Click(object sender, EventArgs e)
    {
        //TB_MOUDLENAME.Text = "";
        TB_ACTION.Text = "";
        TB_DESCRIPTION.Text = "";
    }


    protected void Bt_return_Click(object sender, EventArgs e)
    {
        //Response.Redirect("sys_moudleactionselect.aspx");
        string parentid = this.Context.Request["parentid"].Trim();
        Response.Write("<script language=javascript>window.parent.frames[\"infodict_right\"].location.href=\"subclassview.aspx?parentid=" + parentid + "\";</script>");

    }
}

