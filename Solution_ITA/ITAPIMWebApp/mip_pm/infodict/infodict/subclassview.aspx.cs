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

public partial class infodict_infodict_subclassview : CePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this._isallowaccess("", "6", "");
        if (!IsPostBack)
        {

            bindgridview();
            GetPermission();

        }

    }

    private bool IsofAdd_Action;
    private bool IsofDelete_Action;
    private bool IsofUpdate_Action;
    private bool IsofDetail_Action;


    /*
    InfodicMng.action.delete	信息标准删除按钮
    InfodicMng.action.update	信息标准更新按钮
    InfodicMng.action.detail	信息标准详细按钮
    InfodicMng.action.add	信息标准添加按钮

     */

    private void GetPermission()
    {
        IsofAdd_Action = _IsAuthorizedInaction("InfodicMng.action.update");
        this.Imbtn_add.Enabled = IsofAdd_Action;
        IsofDelete_Action = _IsAuthorizedInaction("InfodicMng.action.update");

        IsofUpdate_Action = _IsAuthorizedInaction("InfodicMng.action.update");
        IsofDetail_Action = _IsAuthorizedInaction("InfodicMng.action.detail");
    }

    private void bindgridview()
    {
        string parentid = this.Context.Request["parentid"].Trim();
        Mis.BLL.ptgl.SYS_INFODICT handle = new Mis.BLL.ptgl.SYS_INFODICT();
        DataSet dts = handle.GetList("  parentid ='" + parentid + "'");
        this.GridView1.DataSource = dts;
        GridView1.DataBind();


    }

    protected void btn_update_Command(object sender, CommandEventArgs e)
    {
        string parentid = this.Context.Request["parentid"].Trim();
        string id = e.CommandArgument.ToString();
        //操作权限管理
        GetPermission();
        if (IsofUpdate_Action == false)
        {
            JS.Alert("无修改数据权限！", this);
            return;
        }

        Response.Write("<script language=javascript>window.parent.frames[\"infodict_right\"].location.href=\"editsub.aspx?id=" + id + "&parentid=" + parentid + "\";</script>");

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bindgridview();
    }
    protected void Imbtn_add_Click(object sender, ImageClickEventArgs e)
    {
        string parentid = this.Context.Request["parentid"].Trim();
        Response.Write("<script language=javascript>window.parent.frames[\"infodict_right\"].location.href=\"addsub.aspx?parentid=" + parentid + "\";</script>");

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ImageButton btn_update = (ImageButton)e.Row.FindControl("btn_update");

        // btn_update.ToolTip = handle_resmanage.GetString("80");//修改信息标准分类信息
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor = '#d5f4fe'");
            //添加自定义属性，当鼠标移走时还原该行的背景色  
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
            e.Row.Attributes["style"] = "Cursor:hand";
        }

    }
}
