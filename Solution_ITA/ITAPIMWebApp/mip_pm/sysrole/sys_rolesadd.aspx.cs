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
public partial class mip_pm_sys_rolesadd : System.Web.UI.CePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this._isallowaccess("", "8", "");
        if (!IsPostBack)
        {
            BindDwData();
            GetPermission();
        }
    }

    private bool IsofAdd_Action;
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
        IsofAdd_Action = _IsAuthorizedInaction("Rolemng.action.update");
        this.Bt_commit.Enabled = IsofAdd_Action;
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
    /// 从页面获得控件值的函数，并将数据存储在对应的model中
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    private Mis.Model.ptgl.SYS_ROLES Gettest_manageDataFromPage(Mis.Model.ptgl.SYS_ROLES obj)
    {
        obj.ROLENO = TB_ROLENO.Text.Trim();

        obj.USERNO = TB_USERNO.Text.Trim();

        obj.DESCRIPTION = TB_DESCRIPTION.Text.Trim();

        return obj;
    }


    /// <summary>
    /// 信息标准绑定下拉框dp
    /// </summary>
    private void BindDwData()
    {
        Mis.BLL.ptgl.SYS_INFODICT dic = new Mis.BLL.ptgl.SYS_INFODICT();
        dic.BindToDropDownList(this.DP_SYSDATATYPE, "85");
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
        obj.ROLENO = TB_ROLENO.Text.Trim();

        obj.USERNO = TB_USERNO.Text.Trim();

        obj.DESCRIPTION = TB_DESCRIPTION.Text.Trim();

        obj.SYSDATATYPE = DP_SYSDATATYPE.SelectedValue;

        if (handle.Existsmodel(obj) == true)
        {
            JS.Alert("对不起，已经存在！", this);
            return;
        }

        int p_ResID = handle.Add(obj);
        if (0 < p_ResID)
        {

            //添加信息
            string p_ResTableName = "Rolemng";
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
        TB_ROLENO.Text = "";
        TB_USERNO.Text = "";
        TB_DESCRIPTION.Text = "";
    }


    protected void Bt_clear_Click(object sender, EventArgs e)
    {
        TB_ROLENO.Text = "";
        TB_USERNO.Text = "";
        TB_DESCRIPTION.Text = "";
    }


    protected void Bt_return_Click(object sender, EventArgs e)
    {
        Response.Redirect("sys_rolesselect.aspx");
    }
}

