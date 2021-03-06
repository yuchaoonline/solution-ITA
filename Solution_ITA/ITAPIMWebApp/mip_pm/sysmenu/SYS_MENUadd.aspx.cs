﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class mip_pm_SYS_MENUadd : System.Web.UI.CePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this._isallowaccess("", "5", "");
        if (!IsPostBack)
        {
            BindDwData();
            GetPermission();
        }
    }

    private bool IsofAdd_Action;
   

    /*
        Menumng.data.delete	菜单删除数据控制点
        Menumng.data.detail	菜单详细数据控制点
        Menumng.data.show	菜单查看数据控制点
        Menumng.data.update	菜单更新数据控制点
        Menumng.action.delete	菜单删除按钮
        Menumng.action.update	菜单更新按钮
        Menumng.action.detail	菜单详细按钮
        Menumng.action.add	菜单添加按钮

     */

    private void GetPermission()
    {
        IsofAdd_Action = _IsAuthorizedInaction("Menumng.action.update");
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
    private Djdw.Model.Post.SYS_MENU Gettest_manageDataFromPage(Djdw.Model.Post.SYS_MENU obj)
    {
        obj.SYSNAME = TB_SYSNAME.Text.Trim();

        obj.MOUDLENAME = TB_MOUDLENAME.Text.Trim();

        obj.SYSLEVEL = int.Parse(DP_SYSLEVEL.SelectedValue);
        obj.PARENT = TB_PARENT.Text.Trim();

        obj.URL = TB_URL.Text.Trim();

        obj.DESCRIPTION = TB_DESCRIPTION.Text.Trim();

        obj.IMG = TB_IMG.Text.Trim();

        obj.VERSION = int.Parse(DP_VERSION.SelectedValue);
        return obj;
    }


    /// <summary>
    /// 信息标准绑定下拉框dp
    /// </summary>
    private void BindDwData()
    {
        Mis.BLL.ptgl.SYS_INFODICT dic = new Mis.BLL.ptgl.SYS_INFODICT();
        //下拉框 级别
        dic.BindToDropDownList(this.DP_SYSLEVEL, "2");
        //下拉框 颁本
        dic.BindToDropDownList(this.DP_VERSION, "1");
    }

    /// <summary>
    /// 控件是否可见
    /// </summary>
    protected void IsofVisible()
    {
        LB_SYSNAME.Visible = true; //系统名称
        LB_SYSNAMEunit.Visible = true; //系统名称
        TB_SYSNAME.Visible = true; //系统名称

        LB_MOUDLENAME.Visible = true; //模块名称
        LB_MOUDLENAMEunit.Visible = true; //模块名称
        TB_MOUDLENAME.Visible = true; //模块名称

        LB_SYSLEVEL.Visible = true; //级别
        LB_SYSLEVELunit.Visible = true; //级别
        DP_SYSLEVEL.Visible = true; //级别

        LB_PARENT.Visible = true; //上一级别模块
        LB_PARENTunit.Visible = true; //上一级别模块
        TB_PARENT.Visible = true; //上一级别模块

        LB_URL.Visible = true; //url
        LB_URLunit.Visible = true; //url
        TB_URL.Visible = true; //url

        LB_DESCRIPTION.Visible = true; //描述
        LB_DESCRIPTIONunit.Visible = true; //描述
        TB_DESCRIPTION.Visible = true; //描述

        LB_IMG.Visible = true; //模块对应的图片url
        LB_IMGunit.Visible = true; //模块对应的图片url
        TB_IMG.Visible = true; //模块对应的图片url

        LB_VERSION.Visible = true; //颁本
        LB_VERSIONunit.Visible = true; //颁本
        DP_VERSION.Visible = true; //颁本

    }


    protected void Bt_commit_Click(object sender, EventArgs e)
    {
        if (false == Isputvalid())
        {
            JS.Alert("输入不满足要求", this);
            return;
        }
        Mis.BLL.ptgl.SYS_MENU handle = new Mis.BLL.ptgl.SYS_MENU();
        Djdw.Model.Post.SYS_MENU obj = new Djdw.Model.Post.SYS_MENU();
        obj.SYSNAME = TB_SYSNAME.Text.Trim();

        obj.MOUDLENAME = TB_MOUDLENAME.Text.Trim();

        obj.SYSLEVEL = int.Parse(DP_SYSLEVEL.SelectedValue);
        obj.PARENT = TB_PARENT.Text.Trim();

        obj.URL = TB_URL.Text.Trim();

        obj.DESCRIPTION = TB_DESCRIPTION.Text.Trim();

        obj.IMG = TB_IMG.Text.Trim();

        obj.VERSION = int.Parse(DP_VERSION.SelectedValue);
        
        /*if (handle.Existsmodel(obj) == true)
        {
            JS.Alert("对不起，已经存在！", this);
            return;
        }*/

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
        TB_SYSNAME.Text = "";
        TB_MOUDLENAME.Text = "";
        DP_SYSLEVEL.SelectedValue = "1";
        TB_PARENT.Text = "";
        TB_URL.Text = "";
        TB_DESCRIPTION.Text = "";
        TB_IMG.Text = "";
        DP_VERSION.SelectedValue = "1";
    }


    protected void Bt_clear_Click(object sender, EventArgs e)
    {
        TB_SYSNAME.Text = "";
        TB_MOUDLENAME.Text = "";
        DP_SYSLEVEL.SelectedValue = "1";
        TB_PARENT.Text = "";
        TB_URL.Text = "";
        TB_DESCRIPTION.Text = "";
        TB_IMG.Text = "";
        DP_VERSION.SelectedValue = "1";
    }


    protected void Bt_return_Click(object sender, EventArgs e)
    {
        Response.Redirect("SYS_MENUselect.aspx");
    }
}

