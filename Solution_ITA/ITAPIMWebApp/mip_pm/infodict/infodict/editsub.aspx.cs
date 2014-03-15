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

public partial class infodict_infodict_editsub : CePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this._isallowaccess("", "6", "");
        if (!IsPostBack)
        {
            
            BindToDropDownList();
            binddata();
            GetPermission();
        }

    }

    //private bool IsofAdd_Action;
    //private bool IsofDelete_Action;
    private bool IsofUpdate_Action;
    //private bool IsofDetail_Action;


    /*
    InfodicMng.action.delete	信息标准删除按钮
    InfodicMng.action.update	信息标准更新按钮
    InfodicMng.action.detail	信息标准详细按钮
    InfodicMng.action.add	信息标准添加按钮

     */

    private void GetPermission()
    {
        //IsofAdd_Action = _IsAuthorizedInaction("InfodicMng.action.add");

        //IsofDelete_Action = _IsAuthorizedInaction("InfodicMng.action.delete");

        IsofUpdate_Action = _IsAuthorizedInaction("InfodicMng.action.update");
        this.submit.Enabled = IsofUpdate_Action;
        //IsofDetail_Action = _IsAuthorizedInaction("InfodicMng.action.detail");
    }

    protected void submit_Click(object sender, ImageClickEventArgs e)
    {
        string id = this.Context.Request["id"].Trim();

        Djdw.Model.Post.SYS_INFODICT obj = new Djdw.Model.Post.SYS_INFODICT();
        Mis.BLL.ptgl.SYS_INFODICT handle = new Mis.BLL.ptgl.SYS_INFODICT();
        obj = handle.GetModel(int.Parse(id));
        obj.PARENTID = int.Parse(listinfoname.SelectedItem.Value);
        obj.INFONAME = infoname.Text.Trim();
        obj.INFONO = infono.Text.Trim();
        obj.DESCRIPTION = description.Text.Trim();
        obj.ACTIONPEOPLE = actionpeople.Text.Trim();


        try
        {
            handle.Update(obj);
            JS.Alert("信息标准分类修改成功", this);//信息标准分类修改成功

        }
        catch
        {
            JS.Alert("信息标准分类修改失败", this);//信息标准分类修改失败

        }

        string parentid = this.Context.Request["parentid"].Trim();
        //Response.Write("<script language=javascript>window.parent.frames[\"infodict_right\"].location.href=\"addsub.aspx?parentid=" + parentid + "\";</script>");

    }

    protected void cancle_Click(object sender, ImageClickEventArgs e)
    {
        string parentid = this.Context.Request["parentid"].Trim();
        Response.Write("<script language=javascript>window.parent.frames[\"infodict_right\"].location.href=\"subclassview.aspx?parentid=" + parentid + "\";</script>");

    }
    public void BindToDropDownList()
    {
        Mis.BLL.ptgl.SYS_INFODICT handle = new Mis.BLL.ptgl.SYS_INFODICT();
        handle.BindToDropDownList(this.listinfoname, " parentid=0 ", 2, 0);
        //Djdw.Model.Post.SYS_INFODICT obj = new Djdw.Model.Post.SYS_INFODICT();
        string parentid = this.Context.Request["parentid"].Trim();
        //obj = handle.GetModel(int.Parse(parentid));
        this.listinfoname.SelectedValue = parentid.ToString();
    }
    private void binddata()
    {
        string id = this.Context.Request["id"].Trim();
        Djdw.Model.Post.SYS_INFODICT obj = new Djdw.Model.Post.SYS_INFODICT();
        Mis.BLL.ptgl.SYS_INFODICT handle = new Mis.BLL.ptgl.SYS_INFODICT();
        obj = handle.GetModel(int.Parse(id));
        this.infoname.Text = obj.INFONAME;
        this.infono.Text = obj.INFONO;
        this.actionpeople.Text = obj.ACTIONPEOPLE;
        this.description.Text = obj.DESCRIPTION;

    }


}